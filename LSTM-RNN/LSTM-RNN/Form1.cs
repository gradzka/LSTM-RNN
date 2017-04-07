using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LSTM_RNN
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
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

    }
}
