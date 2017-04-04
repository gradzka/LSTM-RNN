using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LSTM_RNN
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Kontakt());
            // NumpyCsharp.NumpyCsharp np = new NumpyCsharp.NumpyCsharp(0); // [Krzysiek] obiekt biblioteki
        }
    }
}
