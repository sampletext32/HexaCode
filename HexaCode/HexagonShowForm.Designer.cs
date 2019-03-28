namespace HexaCode
{
    partial class HexagonShowForm
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
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.buttonSaveToFile = new System.Windows.Forms.Button();
            this.numericUpDownRadius = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonGenerateFromText = new System.Windows.Forms.Button();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRadius)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBoxMain.Location = new System.Drawing.Point(272, 8);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(512, 512);
            this.pictureBoxMain.TabIndex = 0;
            this.pictureBoxMain.TabStop = false;
            this.pictureBoxMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxMain_Paint);
            // 
            // buttonSaveToFile
            // 
            this.buttonSaveToFile.Location = new System.Drawing.Point(8, 88);
            this.buttonSaveToFile.Name = "buttonSaveToFile";
            this.buttonSaveToFile.Size = new System.Drawing.Size(256, 40);
            this.buttonSaveToFile.TabIndex = 1;
            this.buttonSaveToFile.Text = "Save File";
            this.buttonSaveToFile.UseVisualStyleBackColor = true;
            this.buttonSaveToFile.Click += new System.EventHandler(this.buttonSaveToFile_Click);
            // 
            // numericUpDownRadius
            // 
            this.numericUpDownRadius.Location = new System.Drawing.Point(128, 136);
            this.numericUpDownRadius.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownRadius.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownRadius.Name = "numericUpDownRadius";
            this.numericUpDownRadius.Size = new System.Drawing.Size(136, 22);
            this.numericUpDownRadius.TabIndex = 2;
            this.numericUpDownRadius.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownRadius.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownRadius.ValueChanged += new System.EventHandler(this.numericUpDownRadius_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "R";
            // 
            // buttonGenerateFromText
            // 
            this.buttonGenerateFromText.Location = new System.Drawing.Point(8, 216);
            this.buttonGenerateFromText.Name = "buttonGenerateFromText";
            this.buttonGenerateFromText.Size = new System.Drawing.Size(256, 40);
            this.buttonGenerateFromText.TabIndex = 4;
            this.buttonGenerateFromText.Text = "Generate From Text";
            this.buttonGenerateFromText.UseVisualStyleBackColor = true;
            this.buttonGenerateFromText.Click += new System.EventHandler(this.buttonGenerateFromText_Click);
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(8, 184);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(256, 22);
            this.textBoxInput.TabIndex = 5;
            // 
            // HexagonShowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 529);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.buttonGenerateFromText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownRadius);
            this.Controls.Add(this.buttonSaveToFile);
            this.Controls.Add(this.pictureBoxMain);
            this.Name = "HexagonShowForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HexagonShowForm";
            this.Load += new System.EventHandler(this.HexagonShowForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRadius)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxMain;
        private System.Windows.Forms.Button buttonSaveToFile;
        private System.Windows.Forms.NumericUpDown numericUpDownRadius;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonGenerateFromText;
        private System.Windows.Forms.TextBox textBoxInput;
    }
}