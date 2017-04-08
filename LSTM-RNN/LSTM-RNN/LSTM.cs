using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LSTM_RNN
{
    class LSTM
    {
        NumpyCsharp numpy;
        int binary_dim;
        int largest_number;

        //input variables
        double alpha;
        const int input_dim = 2;
        int hidden_dim;
        const int output_dim = 1;
        int loop;

        public event Action<int> ProgressBarChanged;
        public event Action<string> LErrorChanged;
        public event Action<string> LPredChanged;
        public event Action<string> LTrueChanged;
        public event Action<string> LWizChanged;

        //without seed in numpy
        public LSTM(int binaryDim, double alpha, int hiddenDim, int iterations)
        {
            numpy = new NumpyCsharp();
            this.binary_dim = binaryDim;
            largest_number = (1 << binaryDim);
            this.alpha = alpha;
            this.hidden_dim = hiddenDim;
            this.loop = iterations;
        }
        //with seed in numpy
        public LSTM(int binaryDim, double alpha, int hiddenDim, int iterations, int seed)
        {
            numpy = new NumpyCsharp(seed);
            this.binary_dim = binaryDim;
            largest_number = (1 << binaryDim);
            this.alpha = alpha;
            this.hidden_dim = hiddenDim;
            this.loop = iterations;
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
        double[,] sigmoid_output_to_derivative(double[,] x)
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

        double[] numberToBitArray(int x, int binary_dim)
        {
            string s = Convert.ToString(x, 2); //Convert to binary in a string

            double[] bits = s.PadLeft(binary_dim, '0') // Add 0's from left
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

        private void OnProgressBarChanged()
        {
            var action = ProgressBarChanged;
            if (action != null)
            {
                action(1);
            }
        }
        private void OnLErrorChanged(string value)
        {
            var action = LErrorChanged;
            if (action != null)
            {
                action(value);
            }
        }
        private void OnLPredChanged(string value)
        {
            var action = LPredChanged;
            if (action != null)
            {
                action(value);
            }
        }
        private void OnLTrueChanged(string value)
        {
            var action = LTrueChanged;
            if (action != null)
            {
                action(value);
            }
        }
        private void OnLWizChanged(string value)
        {
            var action = LWizChanged;
            if (action != null)
            {
                action(value);
            }
        }

        public void trainNetwork()
        {
            MainWindow mw = new MainWindow();
            mw.progressBar.Value = 0;
            mw.progressBar.Maximum = loop;
            

            //initialize neural network weights
            double[,] synapse_0 = numpy.Random2D(input_dim, hidden_dim);
            double[,] synapse_1 = numpy.Random2D(hidden_dim, output_dim);
            double[,] synapse_h = numpy.Random2D(hidden_dim, hidden_dim);

            double[,] synapse_0_update = numpy.Zeros_like(synapse_0);
            double[,] synapse_1_update = numpy.Zeros_like(synapse_1);
            double[,] synapse_h_update = numpy.Zeros_like(synapse_h);

            int a_int, b_int, c_int, out_result;
            double[] a, b, c, d, prev_layer_1;
            double overallError;
            ArrayList layer_2_deltas, layer_1_values;
            double[,] X, y, layer_1, layer_2, layer_2_error, layer_2_delta, layer_1_delta;

            //training logic
            for (int j = 0; j < loop; j++)
            {
                //generate a simple addition problem (a + b = c)
                a_int = numpy.Randint(largest_number / 2);       //int version
                a = numberToBitArray(a_int, binary_dim);    //binary encoding

                b_int = numpy.Randint(largest_number / 2);       //int version
                b = numberToBitArray(b_int, binary_dim);    //binary encoding

                //true answer
                c_int = a_int + b_int;
                c = numberToBitArray(c_int, binary_dim);

                //where we'll store our best guess (binary encoded)
                d = numpy.Zeros_like(c);

                overallError = 0;

                layer_2_deltas = new ArrayList();
                layer_1_values = new ArrayList();
                layer_1_values.Add(numpy.Zeros(hidden_dim));

                //moving along the positions in the binary encoding
                for (int position = 0; position < binary_dim; position++)
                {
                    //generate input and output
                    X = new double[1, input_dim] { { a[binary_dim - position - 1], b[binary_dim - position - 1] } };
                    y = new double[1, output_dim] { { c[binary_dim - position - 1] } };
                    y = numpy.Transpose(y);

                    //hidden layer (input ~+ prev_hidden)
                    layer_1 = sigmoid(addTables(numpy.Dot(X, synapse_0), numpy.Dot(oneToTwoDimensions((double[])layer_1_values[layer_1_values.Count - 1]), synapse_h)));

                    //output layer (new binary representation)
                    layer_2 = sigmoid(numpy.Dot(layer_1, synapse_1));

                    //did we miss?... if so, by how much?
                    layer_2_error = subTables(y, layer_2);
                    layer_2_deltas.Add(numpy.Dot((layer_2_error), sigmoid_output_to_derivative(layer_2)));
                    overallError += numpy.Abs(getRow(layer_2_error, 0))[0];

                    //decode estimate so we can print it out
                    d[binary_dim - position - 1] = numpy.Round(layer_2[0, 0]);

                    //store hidden layer so we can use it in the next timestep
                    layer_1_values.Add(getRow(numpy.DeepCopy(layer_1), 0));
                }

                double[] future_layer_1_delta = numpy.Zeros(hidden_dim);

                for (int position = 0; position < binary_dim; position++)
                {
                    X = new double[1, input_dim] { { a[position], b[position] } };
                    layer_1 = oneToTwoDimensions((double[])layer_1_values[layer_1_values.Count - position - 1]);
                    prev_layer_1 = (double[])layer_1_values[layer_1_values.Count - position - 2];

                    //error at output layer
                    layer_2_delta = (double[,])layer_2_deltas[layer_2_deltas.Count - position - 1];
                    //error at hidden layer

                    layer_1_delta = multiplyTable(addTables((numpy.Dot(oneToTwoDimensions(future_layer_1_delta), numpy.Transpose(synapse_h))), numpy.Dot(layer_2_delta, numpy.Transpose(synapse_1))), sigmoid_output_to_derivative(layer_1));

                    //let's update all our weights so we can try again

                    synapse_1_update = addTables(synapse_1_update, numpy.Dot(numpy.Transpose(layer_1), layer_2_delta));
                    synapse_h_update = addTables(synapse_h_update, numpy.Dot(numpy.Transpose(oneToTwoDimensions(prev_layer_1)), layer_1_delta));
                    synapse_0_update = addTables(synapse_0_update, numpy.Dot(numpy.Transpose(X), layer_1_delta));

                    future_layer_1_delta = getRow(layer_1_delta, 0);
                }

                synapse_0 = addTables(synapse_0, multiplyTable(synapse_0_update, alpha));
                synapse_1 = addTables(synapse_1, multiplyTable(synapse_1_update, alpha));
                synapse_h = addTables(synapse_h, multiplyTable(synapse_h_update, alpha));

                synapse_0_update = multiplyTable(synapse_0_update, 0);
                synapse_1_update = multiplyTable(synapse_1_update, 0);
                synapse_h_update = multiplyTable(synapse_h_update, 0);

                //print out progress
                if (j % 1000 == 0 || (j==loop-1))
                {
                    //Console.WriteLine("Error: " + overallError.ToString());
                    OnLErrorChanged(overallError.ToString());
                    //Console.Write("Pred: "); numpy.print_1d_matrix(d); Console.WriteLine("");
                    OnLPredChanged(getStringFrom1dMatrix(d));
                    //Console.Write("True: "); numpy.print_1d_matrix(c); Console.WriteLine("");
                    OnLTrueChanged(getStringFrom1dMatrix(c));

                    out_result = 0;
                    for (int i = 0; i < d.Length; i++)
                    {
                        out_result += (int)d[d.Length - 1 - i] * (1 << i);
                    }
                    OnLWizChanged(a_int.ToString() + " + " + b_int.ToString() + " = " + out_result.ToString());
                    //Console.WriteLine(a_int.ToString() + " + " + b_int.ToString() + " = " + out_result.ToString());
                    //Console.WriteLine("------------");
                }
                OnProgressBarChanged();
            }
        }
    }
}
