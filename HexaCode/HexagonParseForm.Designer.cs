namespace HexaCode
{
    partial class HexagonParseForm
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
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownSplitColorCoefficient = new System.Windows.Forms.NumericUpDown();
            this.buttonTrimToBlack = new System.Windows.Forms.Button();
            this.buttonAddBorder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownBorderSize = new System.Windows.Forms.NumericUpDown();
            this.buttonGetHexagonRadius = new System.Windows.Forms.Button();
            this.buttonCompleteParse = new System.Windows.Forms.Button();
            this.buttonSplitColors = new System.Windows.Forms.Button();
            this.buttonFindPart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSplitColorCoefficient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBorderSize)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Location = new System.Drawing.Point(8, 8);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(256, 40);
            this.buttonOpenFile.TabIndex = 5;
            this.buttonOpenFile.Text = "Open File";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBoxMain.Location = new System.Drawing.Point(272, 8);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(560, 560);
            this.pictureBoxMain.TabIndex = 4;
            this.pictureBoxMain.TabStop = false;
            this.pictureBoxMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxMain_Paint);
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Location = new System.Drawing.Point(8, 352);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.Size = new System.Drawing.Size(256, 216);
            this.richTextBoxLog.TabIndex = 6;
            this.richTextBoxLog.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Color Split Coefficient * 1000";
            // 
            // numericUpDownSplitColorCoefficient
            // 
            this.numericUpDownSplitColorCoefficient.Location = new System.Drawing.Point(200, 56);
            this.numericUpDownSplitColorCoefficient.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownSplitColorCoefficient.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownSplitColorCoefficient.Name = "numericUpDownSplitColorCoefficient";
            this.numericUpDownSplitColorCoefficient.Size = new System.Drawing.Size(64, 22);
            this.numericUpDownSplitColorCoefficient.TabIndex = 8;
            this.numericUpDownSplitColorCoefficient.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownSplitColorCoefficient.Value = new decimal(new int[] {
            700,
            0,
            0,
            0});
            // 
            // buttonTrimToBlack
            // 
            this.buttonTrimToBlack.Location = new System.Drawing.Point(8, 120);
            this.buttonTrimToBlack.Name = "buttonTrimToBlack";
            this.buttonTrimToBlack.Size = new System.Drawing.Size(256, 32);
            this.buttonTrimToBlack.TabIndex = 10;
            this.buttonTrimToBlack.Text = "Trim To Black";
            this.buttonTrimToBlack.UseVisualStyleBackColor = true;
            this.buttonTrimToBlack.Click += new System.EventHandler(this.buttonTrimToBlack_Click);
            // 
            // buttonAddBorder
            // 
            this.buttonAddBorder.Location = new System.Drawing.Point(160, 160);
            this.buttonAddBorder.Name = "buttonAddBorder";
            this.buttonAddBorder.Size = new System.Drawing.Size(104, 48);
            this.buttonAddBorder.TabIndex = 11;
            this.buttonAddBorder.Text = "Add Border";
            this.buttonAddBorder.UseVisualStyleBackColor = true;
            this.buttonAddBorder.Click += new System.EventHandler(this.buttonAddBorder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Border Size";
            // 
            // numericUpDownBorderSize
            // 
            this.numericUpDownBorderSize.Location = new System.Drawing.Point(8, 184);
            this.numericUpDownBorderSize.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownBorderSize.Name = "numericUpDownBorderSize";
            this.numericUpDownBorderSize.Size = new System.Drawing.Size(144, 22);
            this.numericUpDownBorderSize.TabIndex = 12;
            this.numericUpDownBorderSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownBorderSize.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // buttonGetHexagonRadius
            // 
            this.buttonGetHexagonRadius.Location = new System.Drawing.Point(8, 216);
            this.buttonGetHexagonRadius.Name = "buttonGetHexagonRadius";
            this.buttonGetHexagonRadius.Size = new System.Drawing.Size(256, 32);
            this.buttonGetHexagonRadius.TabIndex = 14;
            this.buttonGetHexagonRadius.Text = "Get Hexagon Radius";
            this.buttonGetHexagonRadius.UseVisualStyleBackColor = true;
            this.buttonGetHexagonRadius.Click += new System.EventHandler(this.buttonGetHexagonRadius_Click);
            // 
            // buttonCompleteParse
            // 
            this.buttonCompleteParse.Location = new System.Drawing.Point(8, 256);
            this.buttonCompleteParse.Name = "buttonCompleteParse";
            this.buttonCompleteParse.Size = new System.Drawing.Size(256, 40);
            this.buttonCompleteParse.TabIndex = 15;
            this.buttonCompleteParse.Text = "Complete Parse";
            this.buttonCompleteParse.UseVisualStyleBackColor = true;
            this.buttonCompleteParse.Click += new System.EventHandler(this.buttonCompleteParse_Click);
            // 
            // buttonSplitColors
            // 
            this.buttonSplitColors.Location = new System.Drawing.Point(8, 80);
            this.buttonSplitColors.Name = "buttonSplitColors";
            this.buttonSplitColors.Size = new System.Drawing.Size(256, 32);
            this.buttonSplitColors.TabIndex = 7;
            this.buttonSplitColors.Text = "Split Colors";
            this.buttonSplitColors.UseVisualStyleBackColor = true;
            this.buttonSplitColors.Click += new System.EventHandler(this.buttonSplitColors_Click);
            // 
            // buttonFindPart
            // 
            this.buttonFindPart.Location = new System.Drawing.Point(8, 304);
            this.buttonFindPart.Name = "buttonFindPart";
            this.buttonFindPart.Size = new System.Drawing.Size(256, 40);
            this.buttonFindPart.TabIndex = 16;
            this.buttonFindPart.Text = "Find Part";
            this.buttonFindPart.UseVisualStyleBackColor = true;
            this.buttonFindPart.Click += new System.EventHandler(this.buttonFindPart_Click);
            // 
            // HexagonParseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 577);
            this.Controls.Add(this.buttonFindPart);
            this.Controls.Add(this.buttonCompleteParse);
            this.Controls.Add(this.buttonGetHexagonRadius);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownBorderSize);
            this.Controls.Add(this.buttonAddBorder);
            this.Controls.Add(this.buttonTrimToBlack);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownSplitColorCoefficient);
            this.Controls.Add(this.buttonSplitColors);
            this.Controls.Add(this.richTextBoxLog);
            this.Controls.Add(this.buttonOpenFile);
            this.Controls.Add(this.pictureBoxMain);
            this.Name = "HexagonParseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HexagonParseForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSplitColorCoefficient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBorderSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.PictureBox pictureBoxMain;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownSplitColorCoefficient;
        private System.Windows.Forms.Button buttonTrimToBlack;
        private System.Windows.Forms.Button buttonAddBorder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownBorderSize;
        private System.Windows.Forms.Button buttonGetHexagonRadius;
        private System.Windows.Forms.Button buttonCompleteParse;
        private System.Windows.Forms.Button buttonSplitColors;
        private System.Windows.Forms.Button buttonFindPart;
    }
}