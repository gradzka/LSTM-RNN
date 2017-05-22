using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LSTM_RNN
{
    class Iteration
    {
        public string Error;
        public string Pred;
        public string True;
        public string Wiz;
        public Dictionary<int, BitInfo> bitListInfo;

        //before, after - propagation
        public double[,] synapse0Before;
        public double[,] synapse0After;
        public double[,] synapse1Before;
        public double[,] synapse1After;
        public double[,] synapseHBefore;
        public double[,] synapseHAfter;
        public Iteration()
        {
            bitListInfo = new Dictionary<int, BitInfo>();
        }
    }
    class BitInfo
    {
        public double[,] inputLayer; //X
        public double[,] hiddenLayer;
        public double[,] predOutputLayer;
    }

    static class Test
    {
        public static StreamWriter file;

        public static void saveToFile(int a, int b, int pred_c, int c)
        {
            var valid = "F";
            if (pred_c == c)
            {
                valid = "T";
            }
            file.WriteLine(a.ToString() + "\t" + b.ToString() + "\t" + pred_c.ToString() + "\t" + c.ToString() + "\t" + valid);
        }
    }

    class LSTM
    {
        NumpyCsharp numpy;
        int binaryDim;
        public int largestNumber;

        //input variables
        double alpha;
        const int inputDim = 2;
        int hiddenDim;
        const int outputDim = 1;
        int loop;
        double[,] synapse0;
        double[,] synapse1;
        double[,] synapseH;
        public Dictionary<int, Iteration> lstmHistory;

        //without seed in numpy
        public LSTM(int binaryDim, double alpha, int hiddenDim, int iterations)
        {
            numpy = new NumpyCsharp();
            this.binaryDim = binaryDim;
            largestNumber = (1 << binaryDim);
            this.alpha = alpha;
            this.hiddenDim = hiddenDim;
            this.loop = iterations;
            lstmHistory = new Dictionary<int, Iteration>();
        }
        //with seed in numpy
        public LSTM(int binaryDim, double alpha, int hiddenDim, int iterations, int seed)
        {
            numpy = new NumpyCsharp(seed);
            this.binaryDim = binaryDim;
            largestNumber = (1 << binaryDim);
            this.alpha = alpha;
            this.hiddenDim = hiddenDim;
            this.loop = iterations;
            lstmHistory = new Dictionary<int, Iteration>();
        }

        public int getHidDim()
        {
            return hiddenDim;
        }

        //compute sigmoid nonlinearity
        double[,] sigmoid(double[,] x)
        {
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    x[i, j] *= (-1);
                }
            }

            double[,] output = numpy.Exp(x);

            for (int i = 0; i < output.GetLength(0); i++)
            {
                for (int j = 0; j < output.GetLength(1); j++)
                {
                    output[i, j] = 1 / (1 + output[i, j]);
                }
            }
            return output;
        }

        //convert output of sigmoid function to its derivative
        double[,] sigmoidOutputToDerivative(double[,] x)
        {
            double[,] output = new double[x.GetLength(0), x.GetLength(1)];
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    output[i, j] = x[i, j] * (1 - x[i, j]);
                }
            }
            return output;
        }

        double[] numberToBitArray(int x, int binaryDim)
        {
            string s = Convert.ToString(x, 2); //Convert to binary in a string

            double[] bits = s.PadLeft(binaryDim, '0') // Add 0's from left
                         .Select(c => double.Parse(c.ToString())) // convert each char to int
                         .ToArray(); // Convert IEnumerable from select to Array

            return bits;
        }

        double[,] addTables(double[,] t1, double[,] t2)
        {
            if (t1.GetLength(0) == t2.GetLength(0) && t1.GetLength(1) == t2.GetLength(1))
            {
                double[,] result = new double[t1.GetLength(0), t1.GetLength(1)];
                for (int i = 0; i < t1.GetLength(0); i++)
                {
                    for (int j = 0; j < t1.GetLength(1); j++)
                    {
                        result[i, j] = t1[i, j] + t2[i, j];
                    }
                }
                return result;
            }
            else { return null; }
        }

        double[,] subTables(double[,] t1, double[,] t2)
        {
            if (t1.GetLength(0) == t2.GetLength(0) && t1.GetLength(1) == t2.GetLength(1))
            {
                double[,] result = new double[t1.GetLength(0), t1.GetLength(1)];
                for (int i = 0; i < t1.GetLength(0); i++)
                {
                    for (int j = 0; j < t1.GetLength(1); j++)
                    {
                        result[i, j] = t1[i, j] - t2[i, j];
                    }
                }
                return result;
            }
            else { return null; }
        }

        double[,] multiplyTable(double[,] t1, double val)
        {
            double[,] result = new double[t1.GetLength(0), t1.GetLength(1)];
            for (int i = 0; i < t1.GetLength(0); i++)
            {
                for (int j = 0; j < t1.GetLength(1); j++)
                {
                    result[i, j] = t1[i, j] * val;
                }
            }
            return result;
        }

        double[,] multiplyTable(double[,] t1, double[,] t2)
        {
            if (t1.GetLength(0) == t2.GetLength(0) && t1.GetLength(1) == t2.GetLength(1))
            {
                double[,] result = new double[t1.GetLength(0), t1.GetLength(1)];
                for (int i = 0; i < t1.GetLength(0); i++)
                {
                    for (int j = 0; j < t1.GetLength(1); j++)
                    {
                        result[i, j] = t1[i, j] * t2[i, j];
                    }
                }
                return result;
            }
            else { return null; }
        }

        double[,] oneToTwoDimensions(double[] array)
        {
            double[,] newArray = new double[1, array.Length];
            for (int i = 0; i < array.Length; ++i)
                newArray[0, i] = array[i];
            return newArray;
        }

        double[] getRow(double[,] array, int row)
        {
            double[] newArray = new double[array.GetLength(1)];
            for (int i = 0; i < array.GetLength(1); ++i)
                newArray[i] = array[row, i];
            return newArray;
        }
        //Console.Write("Pred: "); numpy.print_1d_matrix(d); Console.WriteLine("");
        string getStringFrom1dMatrix(double[] d)
        {
            string Matrix1dString = string.Empty;
            foreach(double elem in d)
            {
                Matrix1dString += elem.ToString() + " ";
            }
            Matrix1dString=Matrix1dString.Remove(Matrix1dString.Length - 1, 1);
            return Matrix1dString;
        }

        internal delegate void UpdateProgressBarDelegate();
        internal event UpdateProgressBarDelegate UpdateProgressBar;

        internal delegate void UpdateLErrorDelegate(string text);
        internal event UpdateLErrorDelegate UpdateLError;

        internal delegate void UpdateLPredDelegate(string text);
        internal event UpdateLPredDelegate UpdateLPred;

        internal delegate void UpdateLTrueDelegate(string text);
        internal event UpdateLTrueDelegate UpdateLTrue;

        internal delegate void UpdateLWizDelegate(string text);
        internal event UpdateLWizDelegate UpdateLWiz;

        internal void trainNetwork(Boolean ifChecked)
        {
            //initialize neural network weights
            synapse0 = numpy.Random2D(inputDim, hiddenDim);
            synapse1 = numpy.Random2D(hiddenDim, outputDim);
            synapseH = numpy.Random2D(hiddenDim, hiddenDim);

            double[,] synapse0Update = numpy.ZerosLike(synapse0);
            double[,] synapse1Update = numpy.ZerosLike(synapse1);
            double[,] synapseHUpdate = numpy.ZerosLike(synapseH);

            int aInt, bInt, cInt, outResult;
            double[] a, b, c, d, prevLayer1;
            double overallError;
            ArrayList layer2Deltas, layer1Values;
            double[,] X, y, layer1, layer2, layer2Error, layer2Delta, layer1Delta;

            Iteration oneIteration;
            if (ifChecked == true)
            {
                //test1-loop-alpha
                string name = "trening-" + loop + "-" + alpha + ".txt";
                Test.file = new StreamWriter(name, append: true);
            }

            //training logic
            for (int j = 0; j < loop; j++)
            {
                oneIteration = new Iteration();
                for (int i = 0; i < binaryDim; i++)
                {
                    oneIteration.bitListInfo.Add(i, new BitInfo());
                }

                //generate a simple addition problem (a + b = c)
                aInt = numpy.Randint(largestNumber / 2);       //int version
                a = numberToBitArray(aInt, binaryDim);    //binary encoding

                bInt = numpy.Randint(largestNumber / 2);       //int version
                b = numberToBitArray(bInt, binaryDim);    //binary encoding

                //true answer
                cInt = aInt + bInt;
                c = numberToBitArray(cInt, binaryDim);

                //where we'll store our best guess (binary encoded)
                d = numpy.ZerosLike(c);

                overallError = 0;

                layer2Deltas = new ArrayList();
                layer1Values = new ArrayList();
                layer1Values.Add(numpy.Zeros(hiddenDim));

                //moving along the positions in the binary encoding
                for (int position = 0; position < binaryDim; position++)
                {
                    //generate input and output
                    X = new double[1, inputDim] { { a[binaryDim - position - 1], b[binaryDim - position - 1] } };
                    oneIteration.bitListInfo[position].inputLayer = numpy.DeepCopy(X);
                    y = new double[1, outputDim] { { c[binaryDim - position - 1] } };
                    y = numpy.Transpose(y);

                    //hidden layer (input ~+ prev_hidden)
                    layer1 = sigmoid(addTables(numpy.Dot(X, synapse0), numpy.Dot(oneToTwoDimensions((double[])layer1Values[layer1Values.Count - 1]), synapseH)));
                    oneIteration.bitListInfo[position].hiddenLayer = numpy.DeepCopy(layer1);

                    //output layer (new binary representation)
                    layer2 = sigmoid(numpy.Dot(layer1, synapse1));
                    oneIteration.bitListInfo[position].predOutputLayer = numpy.DeepCopy(layer2);

                    //did we miss?... if so, by how much?
                    layer2Error = subTables(y, layer2);
                    layer2Deltas.Add(numpy.Dot((layer2Error), sigmoidOutputToDerivative(layer2)));
                    overallError += numpy.Abs(getRow(layer2Error, 0))[0];

                    //decode estimate so we can print it out
                    d[binaryDim - position - 1] = numpy.Round(layer2[0, 0]);

                    //store hidden layer so we can use it in the next timestep
                    layer1Values.Add(getRow(numpy.DeepCopy(layer1), 0));
                }

                double[] futureLayer1Delta = numpy.Zeros(hiddenDim);

                for (int position = 0; position < binaryDim; position++)
                {
                    X = new double[1, inputDim] { { a[position], b[position] } };
                    layer1 = oneToTwoDimensions((double[])layer1Values[layer1Values.Count - position - 1]);
                    prevLayer1 = (double[])layer1Values[layer1Values.Count - position - 2];

                    //error at output layer
                    layer2Delta = (double[,])layer2Deltas[layer2Deltas.Count - position - 1];
                    //error at hidden layer

                    layer1Delta = multiplyTable(addTables((numpy.Dot(oneToTwoDimensions(futureLayer1Delta), numpy.Transpose(synapseH))), numpy.Dot(layer2Delta, numpy.Transpose(synapse1))), sigmoidOutputToDerivative(layer1));

                    //let's update all our weights so we can try again

                    synapse1Update = addTables(synapse1Update, numpy.Dot(numpy.Transpose(layer1), layer2Delta));
                    synapseHUpdate = addTables(synapseHUpdate, numpy.Dot(numpy.Transpose(oneToTwoDimensions(prevLayer1)), layer1Delta));
                    synapse0Update = addTables(synapse0Update, numpy.Dot(numpy.Transpose(X), layer1Delta));

                    futureLayer1Delta = getRow(layer1Delta, 0);
                }

                oneIteration.synapse0Before = numpy.DeepCopy(synapse0);
                oneIteration.synapse1Before = numpy.DeepCopy(synapse1);
                oneIteration.synapseHBefore = numpy.DeepCopy(synapseH);

                if (j>0 && j<loop)
                {
                    lstmHistory[j - 1].synapse0After = oneIteration.synapse0Before;
                    lstmHistory[j - 1].synapse1After = oneIteration.synapse1Before;
                    lstmHistory[j - 1].synapseHAfter = oneIteration.synapseHBefore;
                }

                synapse0 = addTables(synapse0, multiplyTable(synapse0Update, alpha));
                synapse1 = addTables(synapse1, multiplyTable(synapse1Update, alpha));
                synapseH = addTables(synapseH, multiplyTable(synapseHUpdate, alpha));

                if (j == loop - 1)
                {
                    oneIteration.synapse0After = numpy.DeepCopy(synapse0);
                    oneIteration.synapse1After = numpy.DeepCopy(synapse1);
                    oneIteration.synapseHAfter = numpy.DeepCopy(synapseH);
                }

                synapse0Update = multiplyTable(synapse0Update, 0);
                synapse1Update = multiplyTable(synapse1Update, 0);
                synapseHUpdate = multiplyTable(synapseHUpdate, 0);

                //print out progress
                outResult = 0;
                for (int i = 0; i < d.Length; i++)
                {
                    outResult += (int)d[d.Length - 1 - i] * (1 << i);
                }

                oneIteration.Error = overallError.ToString();
                oneIteration.Pred = getStringFrom1dMatrix(d);
                oneIteration.True = getStringFrom1dMatrix(c);
                oneIteration.Wiz = aInt.ToString() + " + " + bInt.ToString() + " = " + outResult.ToString();
                lstmHistory.Add(j, oneIteration);

                if (ifChecked == true)
                {
                    Test.saveToFile(aInt, bInt, outResult, cInt);
                }
                


                if (j % 1000 == 0 || (j==loop-1))
                {
                    UpdateLError(overallError.ToString());
                    UpdateLPred(getStringFrom1dMatrix(d));
                    UpdateLTrue(getStringFrom1dMatrix(c));
                    UpdateLWiz(aInt.ToString() + " + " + bInt.ToString() + " = " + outResult.ToString());
                }


                //OnProgressBarChanged();
                UpdateProgressBar();
                Application.DoEvents();
                if (ifChecked == true)
                {
                    Test.file.Flush();
                }
            }
        }

        internal void testNetwork(int aInt, int bInt)
        {
            int cInt, outResult;
            double[] a, b, c, d;
            double overallError;
            ArrayList layer2Deltas, layer1Values;
            double[,] X, y, layer1, layer2, layer2Error;

            a = numberToBitArray(aInt, binaryDim);    //binary encoding
            b = numberToBitArray(bInt, binaryDim);    //binary encoding
            //true answer
            cInt = aInt + bInt;
            c = numberToBitArray(cInt, binaryDim);

            //where we'll store our best guess (binary encoded)
            d = numpy.ZerosLike(c);

            overallError = 0;

            layer2Deltas = new ArrayList();
            layer1Values = new ArrayList();
            layer1Values.Add(numpy.Zeros(hiddenDim));

            //moving along the positions in the binary encoding
            for (int position = 0; position < binaryDim; position++)
            {
                //generate input and output
                X = new double[1, inputDim] { { a[binaryDim - position - 1], b[binaryDim - position - 1] } };
                y = new double[1, outputDim] { { c[binaryDim - position - 1] } };
                y = numpy.Transpose(y);

                //hidden layer (input ~+ prev_hidden)
                layer1 = sigmoid(addTables(numpy.Dot(X, synapse0), numpy.Dot(oneToTwoDimensions((double[])layer1Values[layer1Values.Count - 1]), synapseH)));

                //output layer (new binary representation)
                layer2 = sigmoid(numpy.Dot(layer1, synapse1));

                //did we miss?... if so, by how much?
                layer2Error = subTables(y, layer2);
                layer2Deltas.Add(numpy.Dot((layer2Error), sigmoidOutputToDerivative(layer2)));
                overallError += numpy.Abs(getRow(layer2Error, 0))[0];

                //decode estimate so we can print it out
                d[binaryDim - position - 1] = numpy.Round(layer2[0, 0]);

                //store hidden layer so we can use it in the next timestep
                layer1Values.Add(getRow(numpy.DeepCopy(layer1), 0));
            }

            //print out progress
            outResult = 0;
            for (int i = 0; i < d.Length; i++)
            {
                outResult += (int)d[d.Length - 1 - i] * (1 << i);
            }

            UpdateLError(overallError.ToString());
            UpdateLPred(getStringFrom1dMatrix(d));
            UpdateLTrue(getStringFrom1dMatrix(c));
            UpdateLWiz(aInt.ToString() + " + " + bInt.ToString() + " = " + outResult.ToString());

            Application.DoEvents();
        }

        internal void testNetworkForTests() // test pelnego zakresu
        {
            Test.file = new StreamWriter("testPZ-"+ this.loop + "-" + this.alpha + ".txt", append: true);
            int tmp = largestNumber;
            for (int first = 0; first < tmp; first++)
            {
                for (int second = 0; second < tmp; second++)
                {
                    int aInt = first;
                    int bInt = second;
                    int cInt, outResult;
                    double[] a, b, c, d;
                    double overallError;
                    ArrayList layer2Deltas, layer1Values;
                    double[,] X, y, layer1, layer2, layer2Error;

                    a = numberToBitArray(aInt, binaryDim);    //binary encoding
                    b = numberToBitArray(bInt, binaryDim);    //binary encoding
                                                              //true answer
                    cInt = aInt + bInt;
                    c = numberToBitArray(cInt, binaryDim);

                    //where we'll store our best guess (binary encoded)
                    d = numpy.ZerosLike(c);

                    overallError = 0;

                    layer2Deltas = new ArrayList();
                    layer1Values = new ArrayList();
                    layer1Values.Add(numpy.Zeros(hiddenDim));

                    //moving along the positions in the binary encoding
                    for (int position = 0; position < binaryDim; position++)
                    {
                        //generate input and output
                        X = new double[1, inputDim] { { a[binaryDim - position - 1], b[binaryDim - position - 1] } };
                        y = new double[1, outputDim] { { c[binaryDim - position - 1] } };
                        y = numpy.Transpose(y);

                        //hidden layer (input ~+ prev_hidden)
                        layer1 = sigmoid(addTables(numpy.Dot(X, synapse0), numpy.Dot(oneToTwoDimensions((double[])layer1Values[layer1Values.Count - 1]), synapseH)));

                        //output layer (new binary representation)
                        layer2 = sigmoid(numpy.Dot(layer1, synapse1));

                        //did we miss?... if so, by how much?
                        layer2Error = subTables(y, layer2);
                        layer2Deltas.Add(numpy.Dot((layer2Error), sigmoidOutputToDerivative(layer2)));
                        overallError += numpy.Abs(getRow(layer2Error, 0))[0];

                        //decode estimate so we can print it out
                        d[binaryDim - position - 1] = numpy.Round(layer2[0, 0]);

                        //store hidden layer so we can use it in the next timestep
                        layer1Values.Add(getRow(numpy.DeepCopy(layer1), 0));
                    }

                    //print out progress
                    outResult = 0;
                    for (int i = 0; i < d.Length; i++)
                    {
                        outResult += (int)d[d.Length - 1 - i] * (1 << i);
                    }

                    Test.saveToFile(aInt, bInt, outResult, cInt);
                    UpdateProgressBar();

                }
            }
            Test.file.Close();
        }

    }
}
