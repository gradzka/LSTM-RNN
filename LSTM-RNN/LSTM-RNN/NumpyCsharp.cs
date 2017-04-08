using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSTM_RNN
{
    class NumpyCsharp
    {
        public Random random;
        public NumpyCsharp()
        {
            random = new Random(); // ustawienie ziarna generatora liczb pseudolosowych
        }
        public NumpyCsharp(int val)
        {
            random = new Random(val); // ustawienie ziarna generatora liczb pseudolosowych
        }

        public void print_2d_matrix(double[,] matrix) // pomocnicza do wyswietlania macierzy 2D
        {
            int w = matrix.GetLength(0);
            int h = matrix.GetLength(1);

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            //Console.ReadKey();
        }

        public void print_1d_matrix(double[] matrix)  // pomocnicza do wyswietlania macierzy 1D=wektora
        {
            int w = matrix.GetLength(0);

            for (int i = 0; i < w; i++)
            {
                Console.Write(matrix[i] + " ");
            }
            Console.WriteLine();
            //Console.ReadKey();
        }
        public double[,] Exp(double[,] lista)  // potegowanie e^k, gdzie k to liczby z listy
        {
            /* lista = 
             * { 
             *   {1,2,3}
             * }
             * czyli jeden wiersz i trzy kolumny
             */

            double e = Math.E;
            for (int i = 0; i < lista.Length; i++)
            {
                lista[0,i] = Math.Pow(e, lista[0,i]);
            }
            return lista;
        }
        public double[,] Transpose(double[,] matrix) // transpozycja macierzy 2D
        {
            int w = matrix.GetLength(0);
            int h = matrix.GetLength(1);

            double[,] result = new double[h, w];

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }

            return result;
        }
        public double[,] Transpose(double[] matrix) // transpozycja macierzy 1D: {1,2,3} -> { {1,0},{2,0},{3,0} }
        {
            int w = matrix.GetLength(0);

            double[,] result = new double[w, 2];

            for (int i = 0; i < w; i++)
            {
                result[i, 0] = matrix[i];
            }

            return result;
        }

        public double Abs(double num) // zwraca wartosc bezwzgledna
        {
            if (num<0)
            {
                return -1 * num;
            }
            else
            {
                return num;
            }
        }

        public double[] Abs(double[] num) // zwraca wartosc bezwzgledna - dla tablicy wartosci
        {
            for (int i = 0; i < num.Length; i++)
            {
                if (num[i] < 0)
                {
                    num[i] = -1*num[i];
                }
            }
            return num;
           
        }
        
        public double[,] Zeros_like(double[,] X)  // zwraca wyzerowana tablice o takiej samej wielkosci jak podana w argumencie
        {
            return new double[X.GetLength(0), X.GetLength(1)];
        }

        public double[] Zeros_like(double[] X)  // zwraca wyzerowana tablice o takiej samej wielkosci jak podana w argumencie
        {
            return new double[X.GetLength(0)];
        }

        public double[] Zeros(int temp) // zwraca wyzerowana tablice 1D o dlugosci temp
        {
            return new double[temp];
        }

        public double[,] Random2D(int wi, int kol) // zwraca tablice 2D wypelniona losowymi danymi z przedziału <0,1)
        {
            double[,] result = new double[wi, kol];
            for (int i = 0; i < wi; i++)
            {
                for (int j = 0; j < kol; j++)
                {
                    result[i, j] = random.NextDouble();
                }
            }
            return result;
        }

        public int Randint(int maxvalue)  // zwraca losowa liczbe typu integer z przedzialu <0,maxvalue)
        {
            return random.Next(maxvalue);
        }

        public double Round(double r)  // zaokragla liczbe do wartosci calkowitej
        {
            return Math.Round(r);
        }


        public double[,] Dot(double[,] a, double[,] b) // mnozy dwie macierze 2D
        {
            if (a.GetLength(1) == b.GetLength(0))
            {
                double[,] c = new double[a.GetLength(0), b.GetLength(1)];

                for (int i = 0; i < c.GetLength(0); i++)
                {
                    for (int j = 0; j < c.GetLength(1); j++)
                    {
                        c[i, j] = 0;
                        for (int k = 0; k < a.GetLength(1); k++) // OR k<b.GetLength(0)
                            c[i, j] = c[i, j] + a[i, k] * b[k, j];
                    }
                }
                return c;
            }
            else
            {
                Console.WriteLine("Macierze musza miec te same wymiary.");
                return null;
            }
        }
        public double Dot(double[] a, double[] b) // zwraca sume mnozenia dwoch wektorow
        {
            if (a.GetLength(0) == b.GetLength(0))
            {
                double c=0;

                for (int i = 0; i < a.GetLength(0); i++)
                {
                    c = c + a[i] * b[i];
                }
                return c;
            }
            else
            {
                Console.WriteLine("Wektory musza miec ta sama dlugosc.");
                return 0;
            }
        }

        public double[,] Unpackbits(int largest_number) // zwraca macierz 2D, z 8 bitowymi wartosciami: <0, largest_number)
        {
            /* przyklad dla (3)
             [
              [0,0,0,0,0,0,0,0],
              [0,0,0,0,0,0,0,1],
              [0,0,0,0,0,0,1,0]
             ]
             */
            int wiersz = largest_number;

            var result = new double[wiersz, 8];
            var range = Enumerable.Range(0, largest_number).ToArray();
            for (int i = 0; i < wiersz; i++)
            {
                var num = Convert.ToString(range[i], 2).PadLeft(8, '0');
                for (int j = 0; j < 8; j++)
                {
                    result[i, j] = (int)Char.GetNumericValue(num[j]);
                }
            }
            return result;
        }

        public double[,] DeepCopy(double[,] matrix)
        {
            int w = matrix.GetLength(0);
            int h = matrix.GetLength(1);

            var result = new double[w, h];

            for (int i=0;i<w;i++)
            {
                for (int j=0;j<h;j++)
                {
                    result[i, j] = matrix[i, j];
                }
            }
            return result;
        }

        public double[,] Atleast_2d(double[] matrix)
        {
            /* na wejsciu: {1,2,3}
             * na wyjsciu: { {1,2,3},{0,0,0},{0,0,0} } = 3x3, pierwszy wiersz zawiera wektor z wejscia, reszta 0
             */
            int w = matrix.GetLength(0);

            var result = new double[w, w];

            for (int k = 0; k < w; k++)
            {
                result[0, k] = matrix[k];
            }

            for (int i = 1; i < w; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    result[i, j] = 0;
                }
            }
            return result;
        }

        public double[,] Atleast_2d(double[,] matrix)
        {
            /* na wejsciu: { {1,2,3} }
             * na wyjsciu: { {1,2,3},{0,0,0},{0,0,0} } = 3x3, pierwszy wiersz zawiera pierwszy wiersz
             *                                              z wejscia, reszta 0
             */
            int w = matrix.GetLength(1); // wymiar kolumn, bo na wyjsciu bedzie macierz kwadratowa

            var result = new double[w, w];

            for (int k = 0; k < w; k++)
            {
                result[0, k] = matrix[0, k];
            }

            for (int i = 1; i < w; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    result[i, j] = 0;
                }
            }
            return result;
        }
    }
}
