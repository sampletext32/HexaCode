namespace HexaCode
{
    partial class FormAdmin
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageParts = new System.Windows.Forms.TabPage();
            this.tabPageCountries = new System.Windows.Forms.TabPage();
            this.tabPageManufacturers = new System.Windows.Forms.TabPage();
            this.buttonSelectAllParts = new System.Windows.Forms.Button();
            this.buttonUpdatePart = new System.Windows.Forms.Button();
            this.buttonInsertPart = new System.Windows.Forms.Button();
            this.listBoxParts = new System.Windows.Forms.ListBox();
            this.textBoxPartId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxPartCountry = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxPartManufacturer = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPartName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBoxPartTechnicalData = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxPartLifetime = new System.Windows.Forms.TextBox();
            this.textBoxPartCount = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPageParts.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageParts);
            this.tabControl1.Controls.Add(this.tabPageCountries);
            this.tabControl1.Controls.Add(this.tabPageManufacturers);
            this.tabControl1.Location = new System.Drawing.Point(8, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(712, 632);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageParts
            // 
            this.tabPageParts.BackColor = System.Drawing.Color.LightGray;
            this.tabPageParts.Controls.Add(this.textBoxPartCount);
            this.tabPageParts.Controls.Add(this.textBoxPartLifetime);
            this.tabPageParts.Controls.Add(this.label7);
            this.tabPageParts.Controls.Add(this.label6);
            this.tabPageParts.Controls.Add(this.richTextBoxPartTechnicalData);
            this.tabPageParts.Controls.Add(this.label5);
            this.tabPageParts.Controls.Add(this.textBoxPartName);
            this.tabPageParts.Controls.Add(this.label4);
            this.tabPageParts.Controls.Add(this.comboBoxPartManufacturer);
            this.tabPageParts.Controls.Add(this.label3);
            this.tabPageParts.Controls.Add(this.comboBoxPartCountry);
            this.tabPageParts.Controls.Add(this.label2);
            this.tabPageParts.Controls.Add(this.label1);
            this.tabPageParts.Controls.Add(this.textBoxPartId);
            this.tabPageParts.Controls.Add(this.listBoxParts);
            this.tabPageParts.Controls.Add(this.buttonInsertPart);
            this.tabPageParts.Controls.Add(this.buttonUpdatePart);
            this.tabPageParts.Controls.Add(this.buttonSelectAllParts);
            this.tabPageParts.Location = new System.Drawing.Point(4, 25);
            this.tabPageParts.Name = "tabPageParts";
            this.tabPageParts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageParts.Size = new System.Drawing.Size(704, 603);
            this.tabPageParts.TabIndex = 0;
            this.tabPageParts.Text = "Parts";
            // 
            // tabPageCountries
            // 
            this.tabPageCountries.BackColor = System.Drawing.Color.LightGray;
            this.tabPageCountries.Location = new System.Drawing.Point(4, 25);
            this.tabPageCountries.Name = "tabPageCountries";
            this.tabPageCountries.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCountries.Size = new System.Drawing.Size(1384, 603);
            this.tabPageCountries.TabIndex = 1;
            this.tabPageCountries.Text = "Countries";
            // 
            // tabPageManufacturers
            // 
            this.tabPageManufacturers.BackColor = System.Drawing.Color.LightGray;
            this.tabPageManufacturers.Location = new System.Drawing.Point(4, 25);
            this.tabPageManufacturers.Name = "tabPageManufacturers";
            this.tabPageManufacturers.Size = new System.Drawing.Size(1384, 603);
            this.tabPageManufacturers.TabIndex = 2;
            this.tabPageManufacturers.Text = "Manufacturers";
            // 
            // buttonSelectAllParts
            // 
            this.buttonSelectAllParts.Location = new System.Drawing.Point(8, 8);
            this.buttonSelectAllParts.Name = "buttonSelectAllParts";
            this.buttonSelectAllParts.Size = new System.Drawing.Size(224, 32);
            this.buttonSelectAllParts.TabIndex = 0;
            this.buttonSelectAllParts.Text = "SelectAll";
            this.buttonSelectAllParts.UseVisualStyleBackColor = true;
            this.buttonSelectAllParts.Click += new System.EventHandler(this.buttonSelectAllParts_Click);
            // 
            // buttonUpdatePart
            // 
            this.buttonUpdatePart.Location = new System.Drawing.Point(240, 8);
            this.buttonUpdatePart.Name = "buttonUpdatePart";
            this.buttonUpdatePart.Size = new System.Drawing.Size(224, 32);
            this.buttonUpdatePart.TabIndex = 1;
            this.buttonUpdatePart.Text = "Update";
            this.buttonUpdatePart.UseVisualStyleBackColor = true;
            // 
            // buttonInsertPart
            // 
            this.buttonInsertPart.Location = new System.Drawing.Point(472, 8);
            this.buttonInsertPart.Name = "buttonInsertPart";
            this.buttonInsertPart.Size = new System.Drawing.Size(224, 32);
            this.buttonInsertPart.TabIndex = 2;
            this.buttonInsertPart.Text = "Insert";
            this.buttonInsertPart.UseVisualStyleBackColor = true;
            // 
            // listBoxParts
            // 
            this.listBoxParts.FormattingEnabled = true;
            this.listBoxParts.ItemHeight = 16;
            this.listBoxParts.Location = new System.Drawing.Point(8, 48);
            this.listBoxParts.Name = "listBoxParts";
            this.listBoxParts.Size = new System.Drawing.Size(224, 548);
            this.listBoxParts.TabIndex = 3;
            this.listBoxParts.SelectedIndexChanged += new System.EventHandler(this.listBoxParts_SelectedIndexChanged);
            // 
            // textBoxPartId
            // 
            this.textBoxPartId.Location = new System.Drawing.Point(352, 48);
            this.textBoxPartId.Name = "textBoxPartId";
            this.textBoxPartId.Size = new System.Drawing.Size(344, 22);
            this.textBoxPartId.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(328, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Country";
            // 
            // comboBoxPartCountry
            // 
            this.comboBoxPartCountry.FormattingEnabled = true;
            this.comboBoxPartCountry.Location = new System.Drawing.Point(352, 80);
            this.comboBoxPartCountry.Name = "comboBoxPartCountry";
            this.comboBoxPartCountry.Size = new System.Drawing.Size(344, 24);
            this.comboBoxPartCountry.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(248, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Manufacturer";
            // 
            // comboBoxPartManufacturer
            // 
            this.comboBoxPartManufacturer.FormattingEnabled = true;
            this.comboBoxPartManufacturer.Location = new System.Drawing.Point(352, 112);
            this.comboBoxPartManufacturer.Name = "comboBoxPartManufacturer";
            this.comboBoxPartManufacturer.Size = new System.Drawing.Size(344, 24);
            this.comboBoxPartManufacturer.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(296, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Name";
            // 
            // textBoxPartName
            // 
            this.textBoxPartName.Location = new System.Drawing.Point(352, 144);
            this.textBoxPartName.Name = "textBoxPartName";
            this.textBoxPartName.Size = new System.Drawing.Size(344, 22);
            this.textBoxPartName.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(240, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Technical Data";
            // 
            // richTextBoxPartTechnicalData
            // 
            this.richTextBoxPartTechnicalData.Location = new System.Drawing.Point(352, 176);
            this.richTextBoxPartTechnicalData.Name = "richTextBoxPartTechnicalData";
            this.richTextBoxPartTechnicalData.Size = new System.Drawing.Size(344, 208);
            this.richTextBoxPartTechnicalData.TabIndex = 13;
            this.richTextBoxPartTechnicalData.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(288, 392);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Lifetime";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(296, 424);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Count";
            // 
            // textBoxPartLifetime
            // 
            this.textBoxPartLifetime.Location = new System.Drawing.Point(352, 392);
            this.textBoxPartLifetime.Name = "textBoxPartLifetime";
            this.textBoxPartLifetime.Size = new System.Drawing.Size(344, 22);
            this.textBoxPartLifetime.TabIndex = 16;
            // 
            // textBoxPartCount
            // 
            this.textBoxPartCount.Location = new System.Drawing.Point(352, 424);
            this.textBoxPartCount.Name = "textBoxPartCount";
            this.textBoxPartCount.Size = new System.Drawing.Size(344, 22);
            this.textBoxPartCount.TabIndex = 17;
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 654);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormAdmin";
            this.Text = "FormAdmin";
            this.Load += new System.EventHandler(this.FormAdmin_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageParts.ResumeLayout(false);
            this.tabPageParts.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageParts;
        private System.Windows.Forms.TabPage tabPageCountries;
        private System.Windows.Forms.TabPage tabPageManufacturers;
        private System.Windows.Forms.Button buttonSelectAllParts;
        private System.Windows.Forms.Button buttonInsertPart;
        private System.Windows.Forms.Button buttonUpdatePart;
        private System.Windows.Forms.ListBox listBoxParts;
        private System.Windows.Forms.RichTextBox richTextBoxPartTechnicalData;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPartName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxPartManufacturer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxPartCountry;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPartId;
        private System.Windows.Forms.TextBox textBoxPartLifetime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxPartCount;
    }
}