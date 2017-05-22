using System;
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
        LSTM lstm;
        //List<Button> buttonList = new List<Button>();
        Dictionary<string, Button> buttonDict=new Dictionary<string,Button>();

        public MainWindow()
        {
            InitializeComponent();
        }

        public void updateProgressBar()
        {
            progressBar.Value += 1;
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

        private void UpdateProgressBar()
        {
            progressBar.Value += 1;
        }

        private void UpdateLError(string text)
        {
            LError.Text = text;
        }
        private void UpdateLPred(string text)
        {
            LPred.Text = text;
        }
        private void UpdateLTrue(string text)
        {
            LTrue.Text = text;
        }
        private void UpdateLWiz(string text)
        {
            LWiz.Text = text;
        }
        void HiddenLayer()
        {
            for (int i = 0; i < 3; i++)
            {
                //buttonList.Add(new Button());
                if (i==0)
                {
                    buttonDict.Add("inputNode1", new Button());
                    buttonDict.Last().Value.Location = new System.Drawing.Point(555, 277);
                    buttonDict.Last().Value.Name = "inputNode1";
                    buttonDict.Last().Value.BackColor = System.Drawing.Color.DarkSeaGreen;
                }
                else if (i==1)
                {
                    buttonDict.Add("inputNode2", new Button());
                    buttonDict.Last().Value.Location = new System.Drawing.Point(589, 277);
                    buttonDict.Last().Value.Name = "inputNode2";
                    buttonDict.Last().Value.BackColor = System.Drawing.Color.DarkSeaGreen;
                }
                else if (i==2)
                {
                    buttonDict.Add("outputNode", new Button());
                    buttonDict.Last().Value.Location = new System.Drawing.Point(572, 67);
                    buttonDict.Last().Value.Name = "outputNode";
                    buttonDict.Last().Value.BackColor = System.Drawing.Color.Silver;
                }

                buttonDict.Last().Value.Size = new System.Drawing.Size(28, 28);
                buttonDict.Last().Value.TabIndex = 6;
                buttonDict.Last().Value.Text = " ";
                //ToolTip.SetToolTip(buttonDict.Last().Value, "000000");
                buttonDict.Last().Value.UseVisualStyleBackColor = false;
                buttonDict.Last().Value.Click += new System.EventHandler(node_Click);
                this.Controls.Add(buttonDict.Last().Value);
            }
           
            int HidDim = lstm.getHidDim();
            int halfWay = HidDim / 2 - 1;
            int startPosition = 0;

            if (HidDim % 2 == 0) //even
            {
                startPosition = 556 - (halfWay * 34);
            }
            else //odd
            {
                startPosition = 573 - ((halfWay + 1) * 34);
            }
            string buttonName = string.Empty;
            for (int i = 0; i < HidDim; i++)
            {
                buttonName = "hiddenNode" + i;
                buttonDict.Add(buttonName,new Button());
                buttonDict.Last().Value.Location = new System.Drawing.Point(startPosition + i * 34, 166);
                buttonDict.Last().Value.Name = buttonName;
                buttonDict.Last().Value.Size = new System.Drawing.Size(28, 28);
                buttonDict.Last().Value.TabIndex = 6;
                buttonDict.Last().Value.Text = i.ToString();
                this.TrainingButton.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                //ToolTip.SetToolTip(buttonDict.Last().Value, "000000");
                buttonDict.Last().Value.BackColor = System.Drawing.Color.Peru;
                buttonDict.Last().Value.UseVisualStyleBackColor = false;
                buttonDict.Last().Value.Click += new System.EventHandler(node_Click);
                this.Controls.Add(buttonDict.Last().Value);
            }
        }
        private void TrainingButton_Click(object sender, EventArgs e)
        {        
            foreach (var item in buttonDict)
            {
                this.Controls.Remove(item.Value);
            }
            buttonDict.Clear();

            GBOptions.Enabled = false;
            GBTest.Enabled = false;
            progressBar.Value = 0;
            NumOptIterations.Maximum = NumIterations.Value - 1;
            NumOptBitNo.Maximum = NumBinDim.Value - 1;
            NumL1.Maximum = 1 << Decimal.ToInt32(NumBinDim.Value) - 1;
            NumL2.Maximum = 1 << Decimal.ToInt32(NumBinDim.Value) - 1;


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

            //Trainthread = new Thread(lstm.trainNetwork);
            //Trainthread.Start();
            lstm.UpdateProgressBar += UpdateProgressBar;
            lstm.UpdateLError += UpdateLError;
            lstm.UpdateLPred += UpdateLPred;
            lstm.UpdateLTrue += UpdateLTrue;
            lstm.UpdateLWiz += UpdateLWiz;

            //Controls
            HiddenLayer();

            lstm.trainNetwork(ChBSaveTraining.Checked);
            GBOptions.Enabled = true;
            GBTest.Enabled = true;

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

        private void node_Click(object sender, EventArgs e)
        {
            int iteration = Decimal.ToInt32(NumOptIterations.Value);
            int bitNo = Decimal.ToInt32(NumOptBitNo.Value);

            Button button = buttonDict[(sender as Button).Name];
            ContextMenuStrip PopupMenu = new ContextMenuStrip();
            ToolStripMenuItem submenu1;
            ToolStripMenuItem submenu2;

            submenu1 = new ToolStripMenuItem();
            submenu1.Text = "Przed propag. wst.";

            submenu2 = new ToolStripMenuItem();
            submenu2.Text = "Po propag. wst.";

            for (int i = 0; i < lstm.getHidDim(); i++)
            {
                if (button.Name == "outputNode")
                {
                    //item = new ToolStripMenuItem();
                    //item.Text = lstm.lstmHistory[iteration].synapse1Before[i, 0].ToString();
                    submenu1.DropDownItems.Add(new ToolStripMenuItem(lstm.lstmHistory[iteration].synapse1Before[i, 0].ToString()));
                    submenu2.DropDownItems.Add(new ToolStripMenuItem(lstm.lstmHistory[iteration].synapse1After[i, 0].ToString()));

                    //PopupMenu.Items.Add(lstm.lstmHistory[iteration].synapse1Before[i, 0].ToString());
                }
                else if (button.Name == "inputNode1")
                {
                    submenu1.DropDownItems.Add(new ToolStripMenuItem(lstm.lstmHistory[iteration].synapse0Before[0, i].ToString()));
                    submenu2.DropDownItems.Add(new ToolStripMenuItem(lstm.lstmHistory[iteration].synapse0After[0, i].ToString()));

                    //PopupMenu.Items.Add(lstm.lstmHistory[iteration].synapse0Before[0, i].ToString());
                }
                else if (button.Name == "inputNode2")
                {
                    submenu1.DropDownItems.Add(new ToolStripMenuItem(lstm.lstmHistory[iteration].synapse0Before[1, i].ToString()));
                    submenu2.DropDownItems.Add(new ToolStripMenuItem(lstm.lstmHistory[iteration].synapse0After[1, i].ToString()));

                    //PopupMenu.Items.Add(lstm.lstmHistory[iteration].synapse0Before[1, i].ToString());
                }
                else if (button.Name.Contains("hiddenNode"))
                {
                    submenu1.DropDownItems.Add(new ToolStripMenuItem(lstm.lstmHistory[iteration].synapseHBefore[Int32.Parse(button.Name.Remove(0, 10)), i].ToString()));
                    submenu2.DropDownItems.Add(new ToolStripMenuItem(lstm.lstmHistory[iteration].synapseHAfter[Int32.Parse(button.Name.Remove(0, 10)), i].ToString()));
                    //PopupMenu.Items.Add(lstm.lstmHistory[iteration].synapseHBefore[Int32.Parse(button.Name.Remove(0,10)), i].ToString());
                }
            }
            PopupMenu.Items.Add(submenu1);
            PopupMenu.Items.Add(submenu2);
            PopupMenu.Show(button, new Point(0, button.Height));
            //this.ContextMenuStrip = PopupMenu;
        }
        private void BPreview_Click(object sender, EventArgs e)
        {
            int iteration = Decimal.ToInt32(NumOptIterations.Value);
            int bitNo = Decimal.ToInt32(NumOptBitNo.Value);

            //Nodes values
            //output, inputs
            ToolTip.SetToolTip(buttonDict["outputNode"], lstm.lstmHistory[iteration].bitListInfo[bitNo].predOutputLayer[0, 0].ToString());
            ToolTip.SetToolTip(buttonDict["inputNode1"], lstm.lstmHistory[iteration].bitListInfo[bitNo].inputLayer[0, 0].ToString());
            ToolTip.SetToolTip(buttonDict["inputNode2"], lstm.lstmHistory[iteration].bitListInfo[bitNo].inputLayer[0, 1].ToString());

            //hiddens
            string buttonName = string.Empty;
            for (int i=0;i<buttonDict.Count-3;i++)
            {
                ToolTip.SetToolTip(buttonDict["hiddenNode" + i.ToString()], lstm.lstmHistory[iteration].bitListInfo[bitNo].hiddenLayer[0, i].ToString());
            }

            //Console
            LError.Text = lstm.lstmHistory[iteration].Error.ToString();
            LPred.Text = lstm.lstmHistory[iteration].Pred.ToString();
            LTrue.Text = lstm.lstmHistory[iteration].True.ToString();
            LWiz.Text = lstm.lstmHistory[iteration].Wiz.ToString();           
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            lstm.testNetwork(Int32.Parse(NumL1.Text), Int32.Parse(NumL2.Text));
        }

        private void testowanie_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Wykonaj ten test po wytrenowaniu sieci !!!\nPowiadomimy Cię o zakończeniu testu.",
                "Test pełnego zakresu", MessageBoxButtons.OKCancel);
            if (res == DialogResult.OK)
            {
                progressBar.Value = 0;
                progressBar.Maximum = lstm.largestNumber * lstm.largestNumber;
                lstm.testNetworkForTests();
                MessageBox.Show("Test ukończony.", "Test pełnego zakresu");
            }
        }
    }
}
