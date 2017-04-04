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
        /*
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

            double[,] output = new double[x.GetLength(0), x.GetLength(1)];

            double[] oneRow = new double[x.GetLength(1)];

            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    oneRow[j] = x[i,j];
                }
                oneRow = numpy.Exp(oneRow);
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    output[i, j] = oneRow[j];
                }
            }

            for (int i = 0; i < output.GetLength(0); i++)
            {
                for (int j = 0; j < output.GetLength(1); j++)
                {
                    output[i, j] = 1 / (1 + output[i,j]);
                }
            }
            return output;
        }
        /*
        //convert output of sigmoid function to its derivative
        double[,] sigmoid_output_to_derivative(double[] x)
        {
            double[] output = new double[x.Count()];
            for (int i = 0; i < x.Count(); i++)
            {
                output[i] = x[i] * (1 - x[i]);
            }
            return output;
        }*/

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

            //TODO
        }

    }
}
