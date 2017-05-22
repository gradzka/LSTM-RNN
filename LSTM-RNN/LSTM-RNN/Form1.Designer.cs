namespace LSTM_RNN
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.GBTreining = new System.Windows.Forms.GroupBox();
            this.ChBSaveTraining = new System.Windows.Forms.CheckBox();
            this.GBSeed = new System.Windows.Forms.GroupBox();
            this.CHBoxRandom = new System.Windows.Forms.CheckBox();
            this.NumRandom = new System.Windows.Forms.NumericUpDown();
            this.LCOutputDim = new System.Windows.Forms.Label();
            this.LCInputDim = new System.Windows.Forms.Label();
            this.NumIterations = new System.Windows.Forms.NumericUpDown();
            this.NumHiddenDim = new System.Windows.Forms.NumericUpDown();
            this.NumAlpha = new System.Windows.Forms.NumericUpDown();
            this.NumBinDim = new System.Windows.Forms.NumericUpDown();
            this.LTIterations = new System.Windows.Forms.Label();
            this.LOutputDim = new System.Windows.Forms.Label();
            this.LHiddenDim = new System.Windows.Forms.Label();
            this.LInputDim = new System.Windows.Forms.Label();
            this.LAlpha = new System.Windows.Forms.Label();
            this.LBinDim = new System.Windows.Forms.Label();
            this.TrainingButton = new System.Windows.Forms.Button();
            this.GBResult = new System.Windows.Forms.GroupBox();
            this.LWiz = new System.Windows.Forms.Label();
            this.LTrue = new System.Windows.Forms.Label();
            this.LPred = new System.Windows.Forms.Label();
            this.LError = new System.Windows.Forms.Label();
            this.LCWiz = new System.Windows.Forms.Label();
            this.LCTrue = new System.Windows.Forms.Label();
            this.LCPred = new System.Windows.Forms.Label();
            this.LCError = new System.Windows.Forms.Label();
            this.GBTest = new System.Windows.Forms.GroupBox();
            this.NumL2 = new System.Windows.Forms.NumericUpDown();
            this.NumL1 = new System.Windows.Forms.NumericUpDown();
            this.LNo1 = new System.Windows.Forms.Label();
            this.LNo2 = new System.Windows.Forms.Label();
            this.TestButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.BPreview = new System.Windows.Forms.Button();
            this.LOBitNo = new System.Windows.Forms.Label();
            this.LOIterations = new System.Windows.Forms.Label();
            this.GBOptions = new System.Windows.Forms.GroupBox();
            this.NumOptBitNo = new System.Windows.Forms.NumericUpDown();
            this.NumOptIterations = new System.Windows.Forms.NumericUpDown();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.KontaktTS = new System.Windows.Forms.ToolStripButton();
            this.AboutTS = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.TestStrip = new System.Windows.Forms.ToolStripDropDownButton();
            this.Test2 = new System.Windows.Forms.ToolStripMenuItem();
            this.GBTreining.SuspendLayout();
            this.GBSeed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumRandom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumIterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumHiddenDim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumBinDim)).BeginInit();
            this.GBResult.SuspendLayout();
            this.GBTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumL2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumL1)).BeginInit();
            this.GBOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumOptBitNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumOptIterations)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GBTreining
            // 
            this.GBTreining.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.GBTreining.Controls.Add(this.ChBSaveTraining);
            this.GBTreining.Controls.Add(this.GBSeed);
            this.GBTreining.Controls.Add(this.LCOutputDim);
            this.GBTreining.Controls.Add(this.LCInputDim);
            this.GBTreining.Controls.Add(this.NumIterations);
            this.GBTreining.Controls.Add(this.NumHiddenDim);
            this.GBTreining.Controls.Add(this.NumAlpha);
            this.GBTreining.Controls.Add(this.NumBinDim);
            this.GBTreining.Controls.Add(this.LTIterations);
            this.GBTreining.Controls.Add(this.LOutputDim);
            this.GBTreining.Controls.Add(this.LHiddenDim);
            this.GBTreining.Controls.Add(this.LInputDim);
            this.GBTreining.Controls.Add(this.LAlpha);
            this.GBTreining.Controls.Add(this.LBinDim);
            this.GBTreining.Controls.Add(this.TrainingButton);
            this.GBTreining.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GBTreining.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GBTreining.Location = new System.Drawing.Point(12, 48);
            this.GBTreining.Name = "GBTreining";
            this.GBTreining.Size = new System.Drawing.Size(287, 242);
            this.GBTreining.TabIndex = 0;
            this.GBTreining.TabStop = false;
            this.GBTreining.Text = "TRENING";
            // 
            // ChBSaveTraining
            // 
            this.ChBSaveTraining.AutoSize = true;
            this.ChBSaveTraining.Location = new System.Drawing.Point(14, 214);
            this.ChBSaveTraining.Name = "ChBSaveTraining";
            this.ChBSaveTraining.Size = new System.Drawing.Size(124, 18);
            this.ChBSaveTraining.TabIndex = 6;
            this.ChBSaveTraining.Text = "Zapisz trening";
            this.ChBSaveTraining.UseVisualStyleBackColor = true;
            // 
            // GBSeed
            // 
            this.GBSeed.Controls.Add(this.CHBoxRandom);
            this.GBSeed.Controls.Add(this.NumRandom);
            this.GBSeed.Location = new System.Drawing.Point(9, 19);
            this.GBSeed.Name = "GBSeed";
            this.GBSeed.Size = new System.Drawing.Size(270, 48);
            this.GBSeed.TabIndex = 4;
            this.GBSeed.TabStop = false;
            this.GBSeed.Text = "Seed";
            this.ToolTip.SetToolTip(this.GBSeed, "Ziarno pseudolosowego generatora");
            // 
            // CHBoxRandom
            // 
            this.CHBoxRandom.AutoSize = true;
            this.CHBoxRandom.Location = new System.Drawing.Point(33, 21);
            this.CHBoxRandom.Name = "CHBoxRandom";
            this.CHBoxRandom.Size = new System.Drawing.Size(68, 18);
            this.CHBoxRandom.TabIndex = 1;
            this.CHBoxRandom.Text = "Random";
            this.CHBoxRandom.UseVisualStyleBackColor = true;
            this.CHBoxRandom.CheckedChanged += new System.EventHandler(this.CHBoxRandom_CheckedChanged);
            // 
            // NumRandom
            // 
            this.NumRandom.Location = new System.Drawing.Point(128, 19);
            this.NumRandom.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.NumRandom.Name = "NumRandom";
            this.NumRandom.Size = new System.Drawing.Size(114, 20);
            this.NumRandom.TabIndex = 2;
            this.NumRandom.ThousandsSeparator = true;
            // 
            // LCOutputDim
            // 
            this.LCOutputDim.AutoSize = true;
            this.LCOutputDim.Location = new System.Drawing.Point(141, 161);
            this.LCOutputDim.Name = "LCOutputDim";
            this.LCOutputDim.Size = new System.Drawing.Size(14, 14);
            this.LCOutputDim.TabIndex = 25;
            this.LCOutputDim.Text = "1";
            // 
            // LCInputDim
            // 
            this.LCInputDim.AutoSize = true;
            this.LCInputDim.Location = new System.Drawing.Point(140, 118);
            this.LCInputDim.Name = "LCInputDim";
            this.LCInputDim.Size = new System.Drawing.Size(14, 14);
            this.LCInputDim.TabIndex = 12;
            this.LCInputDim.Text = "2";
            // 
            // NumIterations
            // 
            this.NumIterations.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumIterations.Location = new System.Drawing.Point(137, 182);
            this.NumIterations.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NumIterations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumIterations.Name = "NumIterations";
            this.NumIterations.Size = new System.Drawing.Size(114, 20);
            this.NumIterations.TabIndex = 6;
            this.NumIterations.ThousandsSeparator = true;
            this.NumIterations.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // NumHiddenDim
            // 
            this.NumHiddenDim.Location = new System.Drawing.Point(137, 138);
            this.NumHiddenDim.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.NumHiddenDim.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumHiddenDim.Name = "NumHiddenDim";
            this.NumHiddenDim.Size = new System.Drawing.Size(114, 20);
            this.NumHiddenDim.TabIndex = 5;
            this.NumHiddenDim.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // NumAlpha
            // 
            this.NumAlpha.DecimalPlaces = 2;
            this.NumAlpha.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.NumAlpha.Location = new System.Drawing.Point(137, 95);
            this.NumAlpha.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumAlpha.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.NumAlpha.Name = "NumAlpha";
            this.NumAlpha.Size = new System.Drawing.Size(114, 20);
            this.NumAlpha.TabIndex = 4;
            this.NumAlpha.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // NumBinDim
            // 
            this.NumBinDim.Location = new System.Drawing.Point(137, 73);
            this.NumBinDim.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.NumBinDim.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NumBinDim.Name = "NumBinDim";
            this.NumBinDim.Size = new System.Drawing.Size(114, 20);
            this.NumBinDim.TabIndex = 3;
            this.NumBinDim.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // LTIterations
            // 
            this.LTIterations.AutoSize = true;
            this.LTIterations.Location = new System.Drawing.Point(32, 184);
            this.LTIterations.Name = "LTIterations";
            this.LTIterations.Size = new System.Drawing.Size(84, 14);
            this.LTIterations.TabIndex = 18;
            this.LTIterations.Text = "Iterations:";
            this.ToolTip.SetToolTip(this.LTIterations, "Liczba iteracji procesu\r\nnauczania sieci");
            // 
            // LOutputDim
            // 
            this.LOutputDim.AutoSize = true;
            this.LOutputDim.Location = new System.Drawing.Point(25, 162);
            this.LOutputDim.Name = "LOutputDim";
            this.LOutputDim.Size = new System.Drawing.Size(91, 14);
            this.LOutputDim.TabIndex = 17;
            this.LOutputDim.Text = "Output dim.:";
            this.ToolTip.SetToolTip(this.LOutputDim, "Liczba węzłów wyjściowych");
            // 
            // LHiddenDim
            // 
            this.LHiddenDim.AutoSize = true;
            this.LHiddenDim.Location = new System.Drawing.Point(25, 140);
            this.LHiddenDim.Name = "LHiddenDim";
            this.LHiddenDim.Size = new System.Drawing.Size(91, 14);
            this.LHiddenDim.TabIndex = 16;
            this.LHiddenDim.Text = "Hidden dim.:";
            this.ToolTip.SetToolTip(this.LHiddenDim, "Liczba węzłów w warstwie ukrytej");
            // 
            // LInputDim
            // 
            this.LInputDim.AutoSize = true;
            this.LInputDim.Location = new System.Drawing.Point(32, 118);
            this.LInputDim.Name = "LInputDim";
            this.LInputDim.Size = new System.Drawing.Size(84, 14);
            this.LInputDim.TabIndex = 15;
            this.LInputDim.Text = "Input dim.:";
            this.ToolTip.SetToolTip(this.LInputDim, "Liczba węzłów wejściowych");
            // 
            // LAlpha
            // 
            this.LAlpha.AutoSize = true;
            this.LAlpha.Location = new System.Drawing.Point(67, 97);
            this.LAlpha.Name = "LAlpha";
            this.LAlpha.Size = new System.Drawing.Size(49, 14);
            this.LAlpha.TabIndex = 14;
            this.LAlpha.Text = "Alpha:";
            this.ToolTip.SetToolTip(this.LAlpha, "Współczynnik nauczania sieci");
            // 
            // LBinDim
            // 
            this.LBinDim.AutoSize = true;
            this.LBinDim.Location = new System.Drawing.Point(27, 75);
            this.LBinDim.Name = "LBinDim";
            this.LBinDim.Size = new System.Drawing.Size(91, 14);
            this.LBinDim.TabIndex = 13;
            this.LBinDim.Text = "Binary dim.:";
            this.ToolTip.SetToolTip(this.LBinDim, "Maksymalna liczba bitów\r\nliczby wyjściowej");
            // 
            // TrainingButton
            // 
            this.TrainingButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.TrainingButton.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TrainingButton.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TrainingButton.Location = new System.Drawing.Point(156, 213);
            this.TrainingButton.Name = "TrainingButton";
            this.TrainingButton.Size = new System.Drawing.Size(95, 23);
            this.TrainingButton.TabIndex = 7;
            this.TrainingButton.Text = "Trenuj";
            this.ToolTip.SetToolTip(this.TrainingButton, "Rozpocznij trenowanie sieci\r\nz zadanymi parametrami.");
            this.TrainingButton.UseVisualStyleBackColor = false;
            this.TrainingButton.Click += new System.EventHandler(this.TrainingButton_Click);
            // 
            // GBResult
            // 
            this.GBResult.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.GBResult.Controls.Add(this.LWiz);
            this.GBResult.Controls.Add(this.LTrue);
            this.GBResult.Controls.Add(this.LPred);
            this.GBResult.Controls.Add(this.LError);
            this.GBResult.Controls.Add(this.LCWiz);
            this.GBResult.Controls.Add(this.LCTrue);
            this.GBResult.Controls.Add(this.LCPred);
            this.GBResult.Controls.Add(this.LCError);
            this.GBResult.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GBResult.Location = new System.Drawing.Point(12, 296);
            this.GBResult.Name = "GBResult";
            this.GBResult.Size = new System.Drawing.Size(287, 82);
            this.GBResult.TabIndex = 1;
            this.GBResult.TabStop = false;
            this.GBResult.Text = "WYNIK";
            // 
            // LWiz
            // 
            this.LWiz.Location = new System.Drawing.Point(53, 63);
            this.LWiz.Name = "LWiz";
            this.LWiz.Size = new System.Drawing.Size(226, 14);
            this.LWiz.TabIndex = 11;
            this.LWiz.Text = "0+0=0";
            // 
            // LTrue
            // 
            this.LTrue.Location = new System.Drawing.Point(52, 45);
            this.LTrue.Name = "LTrue";
            this.LTrue.Size = new System.Drawing.Size(227, 14);
            this.LTrue.TabIndex = 10;
            this.LTrue.Text = "0";
            // 
            // LPred
            // 
            this.LPred.Location = new System.Drawing.Point(52, 31);
            this.LPred.Name = "LPred";
            this.LPred.Size = new System.Drawing.Size(227, 14);
            this.LPred.TabIndex = 9;
            this.LPred.Text = "0";
            // 
            // LError
            // 
            this.LError.Location = new System.Drawing.Point(52, 17);
            this.LError.Name = "LError";
            this.LError.Size = new System.Drawing.Size(227, 14);
            this.LError.TabIndex = 8;
            this.LError.Text = "0";
            // 
            // LCWiz
            // 
            this.LCWiz.AutoSize = true;
            this.LCWiz.Location = new System.Drawing.Point(8, 63);
            this.LCWiz.Name = "LCWiz";
            this.LCWiz.Size = new System.Drawing.Size(42, 14);
            this.LCWiz.TabIndex = 7;
            this.LCWiz.Text = "Wiz.:";
            this.ToolTip.SetToolTip(this.LCWiz, "Wizualizacja wyniku\r\ndziałania sieci");
            // 
            // LCTrue
            // 
            this.LCTrue.AutoSize = true;
            this.LCTrue.Location = new System.Drawing.Point(7, 45);
            this.LCTrue.Name = "LCTrue";
            this.LCTrue.Size = new System.Drawing.Size(42, 14);
            this.LCTrue.TabIndex = 6;
            this.LCTrue.Text = "True:";
            this.ToolTip.SetToolTip(this.LCTrue, "Prawidłowy wynik");
            // 
            // LCPred
            // 
            this.LCPred.AutoSize = true;
            this.LCPred.Location = new System.Drawing.Point(7, 31);
            this.LCPred.Name = "LCPred";
            this.LCPred.Size = new System.Drawing.Size(49, 14);
            this.LCPred.TabIndex = 5;
            this.LCPred.Text = "Pred.:";
            this.ToolTip.SetToolTip(this.LCPred, "Wynik przewidziany przez sieć");
            // 
            // LCError
            // 
            this.LCError.AutoSize = true;
            this.LCError.Location = new System.Drawing.Point(7, 17);
            this.LCError.Name = "LCError";
            this.LCError.Size = new System.Drawing.Size(49, 14);
            this.LCError.TabIndex = 4;
            this.LCError.Text = "Error:";
            this.ToolTip.SetToolTip(this.LCError, "Współczynnik błędu iteracji");
            // 
            // GBTest
            // 
            this.GBTest.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.GBTest.Controls.Add(this.NumL2);
            this.GBTest.Controls.Add(this.NumL1);
            this.GBTest.Controls.Add(this.LNo1);
            this.GBTest.Controls.Add(this.LNo2);
            this.GBTest.Controls.Add(this.TestButton);
            this.GBTest.Enabled = false;
            this.GBTest.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GBTest.Location = new System.Drawing.Point(12, 385);
            this.GBTest.Name = "GBTest";
            this.GBTest.Size = new System.Drawing.Size(287, 98);
            this.GBTest.TabIndex = 2;
            this.GBTest.TabStop = false;
            this.GBTest.Text = "TEST";
            // 
            // NumL2
            // 
            this.NumL2.Location = new System.Drawing.Point(137, 43);
            this.NumL2.Name = "NumL2";
            this.NumL2.Size = new System.Drawing.Size(114, 20);
            this.NumL2.TabIndex = 9;
            // 
            // NumL1
            // 
            this.NumL1.Location = new System.Drawing.Point(137, 17);
            this.NumL1.Name = "NumL1";
            this.NumL1.Size = new System.Drawing.Size(114, 20);
            this.NumL1.TabIndex = 8;
            // 
            // LNo1
            // 
            this.LNo1.AutoSize = true;
            this.LNo1.Location = new System.Drawing.Point(33, 20);
            this.LNo1.Name = "LNo1";
            this.LNo1.Size = new System.Drawing.Size(77, 14);
            this.LNo1.TabIndex = 13;
            this.LNo1.Text = "Liczba 1.:";
            this.ToolTip.SetToolTip(this.LNo1, "1. liczba wejściowa");
            // 
            // LNo2
            // 
            this.LNo2.AutoSize = true;
            this.LNo2.Location = new System.Drawing.Point(33, 45);
            this.LNo2.Name = "LNo2";
            this.LNo2.Size = new System.Drawing.Size(77, 14);
            this.LNo2.TabIndex = 12;
            this.LNo2.Text = "Liczba 2.:";
            this.ToolTip.SetToolTip(this.LNo2, "2. liczba wejściowa");
            // 
            // TestButton
            // 
            this.TestButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.TestButton.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TestButton.Location = new System.Drawing.Point(30, 69);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(221, 23);
            this.TestButton.TabIndex = 10;
            this.TestButton.Text = "Testuj";
            this.ToolTip.SetToolTip(this.TestButton, "Testuj sieć ze swoimi parametrami.");
            this.TestButton.UseVisualStyleBackColor = false;
            this.TestButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(0, 503);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(872, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 3;
            // 
            // BPreview
            // 
            this.BPreview.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BPreview.Location = new System.Drawing.Point(237, 13);
            this.BPreview.Name = "BPreview";
            this.BPreview.Size = new System.Drawing.Size(95, 44);
            this.BPreview.TabIndex = 13;
            this.BPreview.Text = "Podgląd treningu";
            this.ToolTip.SetToolTip(this.BPreview, "Podejrzyj szczegóły iteracji\r\ndla zadanego bitu");
            this.BPreview.UseVisualStyleBackColor = false;
            this.BPreview.Click += new System.EventHandler(this.BPreview_Click);
            // 
            // LOBitNo
            // 
            this.LOBitNo.AutoSize = true;
            this.LOBitNo.Location = new System.Drawing.Point(62, 38);
            this.LOBitNo.Name = "LOBitNo";
            this.LOBitNo.Size = new System.Drawing.Size(63, 14);
            this.LOBitNo.TabIndex = 16;
            this.LOBitNo.Text = "Nr bitu:";
            this.ToolTip.SetToolTip(this.LOBitNo, "Numer bitu dodawanych\r\nliczb wejściowych");
            // 
            // LOIterations
            // 
            this.LOIterations.AutoSize = true;
            this.LOIterations.Location = new System.Drawing.Point(54, 15);
            this.LOIterations.Name = "LOIterations";
            this.LOIterations.Size = new System.Drawing.Size(70, 14);
            this.LOIterations.TabIndex = 15;
            this.LOIterations.Text = "Iteracja:";
            this.ToolTip.SetToolTip(this.LOIterations, "Wybrana iteracja\r\ntrenowania sieci");
            // 
            // GBOptions
            // 
            this.GBOptions.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.GBOptions.Controls.Add(this.NumOptBitNo);
            this.GBOptions.Controls.Add(this.NumOptIterations);
            this.GBOptions.Controls.Add(this.BPreview);
            this.GBOptions.Controls.Add(this.LOBitNo);
            this.GBOptions.Controls.Add(this.LOIterations);
            this.GBOptions.Enabled = false;
            this.GBOptions.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GBOptions.Location = new System.Drawing.Point(424, 419);
            this.GBOptions.Name = "GBOptions";
            this.GBOptions.Size = new System.Drawing.Size(341, 64);
            this.GBOptions.TabIndex = 4;
            this.GBOptions.TabStop = false;
            this.GBOptions.Text = "OPCJE";
            // 
            // NumOptBitNo
            // 
            this.NumOptBitNo.Location = new System.Drawing.Point(129, 37);
            this.NumOptBitNo.Name = "NumOptBitNo";
            this.NumOptBitNo.Size = new System.Drawing.Size(97, 20);
            this.NumOptBitNo.TabIndex = 12;
            // 
            // NumOptIterations
            // 
            this.NumOptIterations.Location = new System.Drawing.Point(129, 13);
            this.NumOptIterations.Name = "NumOptIterations";
            this.NumOptIterations.Size = new System.Drawing.Size(97, 20);
            this.NumOptIterations.TabIndex = 11;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.KontaktTS,
            this.AboutTS,
            this.toolStripLabel1,
            this.TestStrip});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.toolStrip1.ShowItemToolTips = false;
            this.toolStrip1.Size = new System.Drawing.Size(872, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // KontaktTS
            // 
            this.KontaktTS.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.KontaktTS.AutoToolTip = false;
            this.KontaktTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.KontaktTS.Image = ((System.Drawing.Image)(resources.GetObject("KontaktTS.Image")));
            this.KontaktTS.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.KontaktTS.Name = "KontaktTS";
            this.KontaktTS.Size = new System.Drawing.Size(52, 22);
            this.KontaktTS.Text = "Kontakt";
            this.KontaktTS.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // AboutTS
            // 
            this.AboutTS.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.AboutTS.AutoToolTip = false;
            this.AboutTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AboutTS.Image = ((System.Drawing.Image)(resources.GetObject("AboutTS.Image")));
            this.AboutTS.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.AboutTS.Name = "AboutTS";
            this.AboutTS.Size = new System.Drawing.Size(78, 22);
            this.AboutTS.Text = "O programie";
            this.AboutTS.Click += new System.EventHandler(this.AboutTS_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 22);
            // 
            // TestStrip
            // 
            this.TestStrip.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TestStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TestStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Test2});
            this.TestStrip.Image = ((System.Drawing.Image)(resources.GetObject("TestStrip.Image")));
            this.TestStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TestStrip.Name = "TestStrip";
            this.TestStrip.Size = new System.Drawing.Size(41, 22);
            this.TestStrip.Text = "Test";
            // 
            // Test2
            // 
            this.Test2.Name = "Test2";
            this.Test2.Size = new System.Drawing.Size(183, 22);
            this.Test2.Text = "Test pełnego zakresu";
            this.Test2.Click += new System.EventHandler(this.testowanie_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LSTM_RNN.Properties.Resources.szata2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(872, 541);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.GBOptions);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.GBTest);
            this.Controls.Add(this.GBResult);
            this.Controls.Add(this.GBTreining);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LSTM-RNN";
            this.GBTreining.ResumeLayout(false);
            this.GBTreining.PerformLayout();
            this.GBSeed.ResumeLayout(false);
            this.GBSeed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumRandom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumIterations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumHiddenDim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumBinDim)).EndInit();
            this.GBResult.ResumeLayout(false);
            this.GBResult.PerformLayout();
            this.GBTest.ResumeLayout(false);
            this.GBTest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumL2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumL1)).EndInit();
            this.GBOptions.ResumeLayout(false);
            this.GBOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumOptBitNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumOptIterations)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GBTreining;
        private System.Windows.Forms.Button TrainingButton;
        private System.Windows.Forms.GroupBox GBResult;
        private System.Windows.Forms.GroupBox GBTest;
        private System.Windows.Forms.Button TestButton;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Label LCWiz;
        private System.Windows.Forms.Label LCTrue;
        private System.Windows.Forms.Label LCPred;
        private System.Windows.Forms.Label LCError;
        private System.Windows.Forms.Label LTIterations;
        private System.Windows.Forms.Label LOutputDim;
        private System.Windows.Forms.Label LHiddenDim;
        private System.Windows.Forms.Label LInputDim;
        private System.Windows.Forms.Label LAlpha;
        private System.Windows.Forms.Label LBinDim;
        private System.Windows.Forms.NumericUpDown NumIterations;
        private System.Windows.Forms.NumericUpDown NumHiddenDim;
        private System.Windows.Forms.NumericUpDown NumAlpha;
        private System.Windows.Forms.NumericUpDown NumBinDim;
        private System.Windows.Forms.NumericUpDown NumRandom;
        private System.Windows.Forms.Label LNo1;
        private System.Windows.Forms.Label LNo2;
        private System.Windows.Forms.NumericUpDown NumL2;
        private System.Windows.Forms.NumericUpDown NumL1;
        private System.Windows.Forms.GroupBox GBSeed;
        private System.Windows.Forms.CheckBox CHBoxRandom;
        private System.Windows.Forms.Label LCOutputDim;
        private System.Windows.Forms.Label LCInputDim;
        private System.Windows.Forms.GroupBox GBOptions;
        private System.Windows.Forms.NumericUpDown NumOptBitNo;
        private System.Windows.Forms.NumericUpDown NumOptIterations;
        private System.Windows.Forms.Button BPreview;
        private System.Windows.Forms.Label LOBitNo;
        private System.Windows.Forms.Label LOIterations;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton KontaktTS;
        private System.Windows.Forms.ToolStripButton AboutTS;
        public System.Windows.Forms.Label LWiz;
        public System.Windows.Forms.Label LTrue;
        public System.Windows.Forms.Label LPred;
        public System.Windows.Forms.Label LError;
        public System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripDropDownButton TestStrip;
        private System.Windows.Forms.ToolStripMenuItem Test2;
        private System.Windows.Forms.CheckBox ChBSaveTraining;
    }
}

