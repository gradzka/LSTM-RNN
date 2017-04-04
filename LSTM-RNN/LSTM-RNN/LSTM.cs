using System;
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
        int input_dim;
        int hidden_dim;
        int output_dim;

        LSTM()
        {
            numpy = new NumpyCsharp(0);
            binary_dim = 8;
            largest_number = (1 << binary_dim);
            alpha = 0.1;
            input_dim = 2;
            hidden_dim = 16;
            output_dim = 1;
        }

        void setSeed(int seed)
        {
            numpy = new NumpyCsharp(seed);
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
                    output[i, j] = 1 / (1 + output[i,j]);
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
                    output[i,j] = x[i,j] * (1 - x[i,j]);
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

        void trainNetwork()
        {
            //initialize neural network weights

            double[,] synapse_0 = numpy.Random2D(input_dim, hidden_dim);
            double[,] synapse_1 = numpy.Random2D(hidden_dim, output_dim);
            double[,] synapse_h = numpy.Random2D(hidden_dim, hidden_dim);

            double[,] synapse_0_update = numpy.Zeros_like(synapse_0);
            double[,] synapse_1_update = numpy.Zeros_like(synapse_1);
            double[,] synapse_h_update = numpy.Zeros_like(synapse_h);

            //training logic
            for (int j = 0; j < 10000; j++)
            {
                //generate a simple addition problem (a + b = c)
                int a_int = numpy.Randint(largest_number / 2);       //int version
                double[] a = numberToBitArray(a_int, binary_dim);    //binary encoding

                int b_int = numpy.Randint(largest_number / 2);       //int version
                double[] b = numberToBitArray(b_int, binary_dim);    //binary encoding

                //true answer
                int c_int = a_int + b_int;
                double[] c = numberToBitArray(a_int, binary_dim);

                //where we'll store our best guess (binary encoded)
                /*double[] d = numpy.Zeros_like(c);

                double overallError = 0;


                layer_2_deltas = list()
                layer_1_values = list()
                layer_1_values.append(np.zeros(hidden_dim))

                //moving along the positions in the binary encoding
                for (int position=0; position < binary_dim; position++)
                { 
                    //generate input and output
                    X = np.array([[a[binary_dim - position - 1], b[binary_dim - position - 1]]])
                    y = np.array([[c[binary_dim - position - 1]]]).T

                    //hidden layer (input ~+ prev_hidden)
                    layer_1 = sigmoid(np.dot(X, synapse_0) + np.dot(layer_1_values[-1], synapse_h))

                    //output layer (new binary representation)
                    layer_2 = sigmoid(np.dot(layer_1, synapse_1))

                    //did we miss?... if so, by how much?
                    layer_2_error = y - layer_2
                    layer_2_deltas.append((layer_2_error) * sigmoid_output_to_derivative(layer_2))
                    overallError += np.abs(layer_2_error[0])

                    //decode estimate so we can print it out
                    d[binary_dim - position - 1] = np.round(layer_2[0][0])

                    //store hidden layer so we can use it in the next timestep
                    layer_1_values.append(copy.deepcopy(layer_1))
                }

                future_layer_1_delta = np.zeros(hidden_dim)

                for (int position=0; position < binary_dim; position++)
                {
                    X = np.array([[a[position], b[position]]])
                    layer_1 = layer_1_values[-position - 1]
                    prev_layer_1 = layer_1_values[-position - 2]

                    //error at output layer
                    layer_2_delta = layer_2_deltas[-position - 1]
                    //#error at hidden layer
                    layer_1_delta = (future_layer_1_delta.dot(synapse_h.T) + layer_2_delta.dot(synapse_1.T)) * sigmoid_output_to_derivative(layer_1)

                    //let's update all our weights so we can try again
                    synapse_1_update += np.atleast_2d(layer_1).T.dot(layer_2_delta)
                    synapse_h_update += np.atleast_2d(prev_layer_1).T.dot(layer_1_delta)
                    synapse_0_update += X.T.dot(layer_1_delta)

                    future_layer_1_delta = layer_1_delta
                }

                synapse_0 += synapse_0_update * alpha
                synapse_1 += synapse_1_update * alpha
                synapse_h += synapse_h_update * alpha

                synapse_0_update *= 0
                synapse_1_update *= 0
                synapse_h_update *= 0

                //print out progress
                if (j % 1000 == 0)
                {
                    Console.WriteLine("Error: " + overallError.ToString());
                    Console.WriteLine("Pred: " + d.ToString());
                    Console.WriteLine("True: " + c.ToString());

                    int out = 0;
                    for index, x in enumerate(reversed(d)):
                        out += x * pow(2, index)
                    Console.WriteLine(a_int.ToString() + " + " + b_int.ToString() + " = " + out.ToString());
                    Console.WriteLine("------------");
                }*/
            }

        }

    }
}
