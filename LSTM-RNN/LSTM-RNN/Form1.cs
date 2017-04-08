﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LSTM_RNN
{
    public partial class MainWindow : Form
    {
        Thread Trainthread = null;
        public MainWindow()
        {
            InitializeComponent();           
        }
        public void UpdateProgressBar(int progress)
        {
            progressBar.Value += progress;
        }
        public void UpdateLError(string text)
        {
            LError.Text = text;
            LError.Refresh();
        }
        public void UpdateLPred(string text)
        {
            LPred.Text = text;
            LPred.Refresh();
        }
        public void UpdateLTrue(string text)
        {
            LTrue.Text = text;
            LTrue.Refresh();
        }
        public void UpdateLWiz(string text)
        {
            LWiz.Text = text;
            LWiz.Refresh();
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                            "Monika Grądzka:\t https://github.com/gradzka \n" +
                            "Robert Kazimierczak:\t https://github.com/kazimierczak-robert \n" +
                            "Krzysztof Łuczak:\t https://github.com/vizarch",
                            "Autorzy projektu");
        }

        private void AboutTS_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                            "Program jest prostym symulatorem działania sieci rekurencyjnej\n" +
                            "Long short-term memory. Pokazuje proces uczenia sieci sumowania\n" +
                            "dwóch liczb. Dodatkowo daje możliwość użytkownikowi przetestowania\n" +
                            "nauczonej sieci, czy podejrzenia szczegółów danej iteracji w procesie\n" +
                            "nauczania.\n\n" +
                            "Program oparto na artykule:\n" +
                            "https://iamtrask.github.io/2015/11/15/anyone-can-code-lstm/.\n",
                            "O programie");
        }

        private void h_node0_Click(object sender, EventArgs e)
        {
            //przy tworzeniu przyciskow
            ContextMenuStrip PopupMenu = new ContextMenuStrip();
            PopupMenu.Items.Add("000");
            PopupMenu.Items.Add("000");

            this.ContextMenuStrip = PopupMenu;
        }

        private void TrainingButton_Click(object sender, EventArgs e)
        {
            LSTM lstm;
            progressBar.Value = 0;
            int binaryDim = Decimal.ToInt32(NumBinDim.Value);
            double alpha = System.Convert.ToDouble(NumAlpha.Value);
            int hiddenDim = Decimal.ToInt32(NumHiddenDim.Value);
            int iterations = Decimal.ToInt32(NumIterations.Value);
            
            if (CHBoxRandom.Checked==true) //seed is set
            {
                lstm = new LSTM(binaryDim, alpha, hiddenDim, iterations);               
            }
            else
            {
                int seed = Decimal.ToInt32(NumRandom.Value);
                lstm = new LSTM(binaryDim, alpha, hiddenDim, iterations, seed);
            }
            progressBar.Maximum = iterations;

            //Clear labels
            LError.Text = "";
            LPred.Text = "";
            LTrue.Text = "";
            LWiz.Text = "";

            lstm.ProgressBarChanged += UpdateProgressBar;
            lstm.LErrorChanged += UpdateLError;
            lstm.LPredChanged += UpdateLPred;
            lstm.LTrueChanged += UpdateLTrue;
            lstm.LWizChanged += UpdateLWiz;

            Trainthread = new Thread(lstm.trainNetwork);
            Trainthread.Start();
            //lstm.trainNetwork();
        }

        private void CHBoxRandom_CheckedChanged(object sender, EventArgs e)
        {
            if (CHBoxRandom.Checked==true)
            {
                NumRandom.Enabled = false;
            }
            else
            {
                NumRandom.Enabled = true;
            }
        }

        private void BStop_Click(object sender, EventArgs e)
        {
            if (Trainthread!=null)
            {
                Trainthread.Abort();
            }

        }
    }
}
