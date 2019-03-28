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
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageParts = new System.Windows.Forms.TabPage();
            this.buttonConvertPartFromCode = new System.Windows.Forms.Button();
            this.buttonConvertPartToCode = new System.Windows.Forms.Button();
            this.buttonCancelEditingPart = new System.Windows.Forms.Button();
            this.textBoxPartCount = new System.Windows.Forms.TextBox();
            this.textBoxPartLifetime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.richTextBoxPartTechnicalData = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPartName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxPartManufacturer = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxPartCountry = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPartId = new System.Windows.Forms.TextBox();
            this.listBoxParts = new System.Windows.Forms.ListBox();
            this.buttonInsertPart = new System.Windows.Forms.Button();
            this.buttonUpdatePart = new System.Windows.Forms.Button();
            this.tabPageCountries = new System.Windows.Forms.TabPage();
            this.buttonCancelEditingCountry = new System.Windows.Forms.Button();
            this.textBoxCountryName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxCountryId = new System.Windows.Forms.TextBox();
            this.buttonInsertCountry = new System.Windows.Forms.Button();
            this.buttonUpdateCountry = new System.Windows.Forms.Button();
            this.listBoxCountries = new System.Windows.Forms.ListBox();
            this.tabPageManufacturers = new System.Windows.Forms.TabPage();
            this.buttonCancelEditingManufacturer = new System.Windows.Forms.Button();
            this.textBoxManufacturerName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxManufacturerId = new System.Windows.Forms.TextBox();
            this.buttonInsertManufacturer = new System.Windows.Forms.Button();
            this.buttonUpdateManufacturer = new System.Windows.Forms.Button();
            this.listBoxManufacturers = new System.Windows.Forms.ListBox();
            this.tabControlMain.SuspendLayout();
            this.tabPageParts.SuspendLayout();
            this.tabPageCountries.SuspendLayout();
            this.tabPageManufacturers.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageParts);
            this.tabControlMain.Controls.Add(this.tabPageCountries);
            this.tabControlMain.Controls.Add(this.tabPageManufacturers);
            this.tabControlMain.HotTrack = true;
            this.tabControlMain.Location = new System.Drawing.Point(8, 8);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(712, 632);
            this.tabControlMain.TabIndex = 0;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // tabPageParts
            // 
            this.tabPageParts.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabPageParts.Controls.Add(this.buttonConvertPartFromCode);
            this.tabPageParts.Controls.Add(this.buttonConvertPartToCode);
            this.tabPageParts.Controls.Add(this.buttonCancelEditingPart);
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
            this.tabPageParts.Location = new System.Drawing.Point(4, 25);
            this.tabPageParts.Name = "tabPageParts";
            this.tabPageParts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageParts.Size = new System.Drawing.Size(704, 603);
            this.tabPageParts.TabIndex = 0;
            this.tabPageParts.Text = "Parts";
            // 
            // buttonConvertPartFromCode
            // 
            this.buttonConvertPartFromCode.Location = new System.Drawing.Point(352, 552);
            this.buttonConvertPartFromCode.Name = "buttonConvertPartFromCode";
            this.buttonConvertPartFromCode.Size = new System.Drawing.Size(344, 40);
            this.buttonConvertPartFromCode.TabIndex = 20;
            this.buttonConvertPartFromCode.Text = "Convert From Code";
            this.buttonConvertPartFromCode.UseVisualStyleBackColor = true;
            this.buttonConvertPartFromCode.Click += new System.EventHandler(this.buttonConvertPartFromCode_Click);
            // 
            // buttonConvertPartToCode
            // 
            this.buttonConvertPartToCode.Location = new System.Drawing.Point(352, 504);
            this.buttonConvertPartToCode.Name = "buttonConvertPartToCode";
            this.buttonConvertPartToCode.Size = new System.Drawing.Size(344, 40);
            this.buttonConvertPartToCode.TabIndex = 19;
            this.buttonConvertPartToCode.Text = "Convert To Code";
            this.buttonConvertPartToCode.UseVisualStyleBackColor = true;
            this.buttonConvertPartToCode.Click += new System.EventHandler(this.buttonConvertPartToCode_Click);
            // 
            // buttonCancelEditingPart
            // 
            this.buttonCancelEditingPart.Enabled = false;
            this.buttonCancelEditingPart.Location = new System.Drawing.Point(584, 456);
            this.buttonCancelEditingPart.Name = "buttonCancelEditingPart";
            this.buttonCancelEditingPart.Size = new System.Drawing.Size(115, 40);
            this.buttonCancelEditingPart.TabIndex = 18;
            this.buttonCancelEditingPart.Text = "Cancel";
            this.buttonCancelEditingPart.UseVisualStyleBackColor = true;
            this.buttonCancelEditingPart.Click += new System.EventHandler(this.buttonCancelEditingPart_Click);
            // 
            // textBoxPartCount
            // 
            this.textBoxPartCount.Location = new System.Drawing.Point(352, 424);
            this.textBoxPartCount.Name = "textBoxPartCount";
            this.textBoxPartCount.Size = new System.Drawing.Size(344, 22);
            this.textBoxPartCount.TabIndex = 17;
            // 
            // textBoxPartLifetime
            // 
            this.textBoxPartLifetime.Location = new System.Drawing.Point(352, 392);
            this.textBoxPartLifetime.Name = "textBoxPartLifetime";
            this.textBoxPartLifetime.Size = new System.Drawing.Size(344, 22);
            this.textBoxPartLifetime.TabIndex = 16;
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(280, 392);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Lifetime";
            // 
            // richTextBoxPartTechnicalData
            // 
            this.richTextBoxPartTechnicalData.Location = new System.Drawing.Point(352, 176);
            this.richTextBoxPartTechnicalData.Name = "richTextBoxPartTechnicalData";
            this.richTextBoxPartTechnicalData.Size = new System.Drawing.Size(344, 208);
            this.richTextBoxPartTechnicalData.TabIndex = 13;
            this.richTextBoxPartTechnicalData.Text = "";
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
            // textBoxPartName
            // 
            this.textBoxPartName.Location = new System.Drawing.Point(352, 144);
            this.textBoxPartName.Name = "textBoxPartName";
            this.textBoxPartName.Size = new System.Drawing.Size(344, 22);
            this.textBoxPartName.TabIndex = 11;
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
            // comboBoxPartManufacturer
            // 
            this.comboBoxPartManufacturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPartManufacturer.FormattingEnabled = true;
            this.comboBoxPartManufacturer.Location = new System.Drawing.Point(352, 112);
            this.comboBoxPartManufacturer.Name = "comboBoxPartManufacturer";
            this.comboBoxPartManufacturer.Size = new System.Drawing.Size(344, 24);
            this.comboBoxPartManufacturer.TabIndex = 9;
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
            // comboBoxPartCountry
            // 
            this.comboBoxPartCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPartCountry.FormattingEnabled = true;
            this.comboBoxPartCountry.Location = new System.Drawing.Point(352, 80);
            this.comboBoxPartCountry.Name = "comboBoxPartCountry";
            this.comboBoxPartCountry.Size = new System.Drawing.Size(344, 24);
            this.comboBoxPartCountry.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Country";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(320, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Id";
            // 
            // textBoxPartId
            // 
            this.textBoxPartId.Enabled = false;
            this.textBoxPartId.Location = new System.Drawing.Point(352, 48);
            this.textBoxPartId.Name = "textBoxPartId";
            this.textBoxPartId.Size = new System.Drawing.Size(344, 22);
            this.textBoxPartId.TabIndex = 4;
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
            // buttonInsertPart
            // 
            this.buttonInsertPart.Location = new System.Drawing.Point(464, 456);
            this.buttonInsertPart.Name = "buttonInsertPart";
            this.buttonInsertPart.Size = new System.Drawing.Size(104, 40);
            this.buttonInsertPart.TabIndex = 2;
            this.buttonInsertPart.Text = "Insert";
            this.buttonInsertPart.UseVisualStyleBackColor = true;
            this.buttonInsertPart.Click += new System.EventHandler(this.buttonInsertPart_Click);
            // 
            // buttonUpdatePart
            // 
            this.buttonUpdatePart.Location = new System.Drawing.Point(352, 456);
            this.buttonUpdatePart.Name = "buttonUpdatePart";
            this.buttonUpdatePart.Size = new System.Drawing.Size(96, 40);
            this.buttonUpdatePart.TabIndex = 1;
            this.buttonUpdatePart.Text = "Update";
            this.buttonUpdatePart.UseVisualStyleBackColor = true;
            this.buttonUpdatePart.Click += new System.EventHandler(this.buttonUpdatePart_Click);
            // 
            // tabPageCountries
            // 
            this.tabPageCountries.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabPageCountries.Controls.Add(this.buttonCancelEditingCountry);
            this.tabPageCountries.Controls.Add(this.textBoxCountryName);
            this.tabPageCountries.Controls.Add(this.label8);
            this.tabPageCountries.Controls.Add(this.label9);
            this.tabPageCountries.Controls.Add(this.textBoxCountryId);
            this.tabPageCountries.Controls.Add(this.buttonInsertCountry);
            this.tabPageCountries.Controls.Add(this.buttonUpdateCountry);
            this.tabPageCountries.Controls.Add(this.listBoxCountries);
            this.tabPageCountries.Location = new System.Drawing.Point(4, 25);
            this.tabPageCountries.Name = "tabPageCountries";
            this.tabPageCountries.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCountries.Size = new System.Drawing.Size(704, 603);
            this.tabPageCountries.TabIndex = 1;
            this.tabPageCountries.Text = "Countries";
            // 
            // buttonCancelEditingCountry
            // 
            this.buttonCancelEditingCountry.Enabled = false;
            this.buttonCancelEditingCountry.Location = new System.Drawing.Point(592, 120);
            this.buttonCancelEditingCountry.Name = "buttonCancelEditingCountry";
            this.buttonCancelEditingCountry.Size = new System.Drawing.Size(107, 40);
            this.buttonCancelEditingCountry.TabIndex = 19;
            this.buttonCancelEditingCountry.Text = "Cancel";
            this.buttonCancelEditingCountry.UseVisualStyleBackColor = true;
            this.buttonCancelEditingCountry.Click += new System.EventHandler(this.buttonCancelEditingCountry_Click);
            // 
            // textBoxCountryName
            // 
            this.textBoxCountryName.Location = new System.Drawing.Point(352, 88);
            this.textBoxCountryName.Name = "textBoxCountryName";
            this.textBoxCountryName.Size = new System.Drawing.Size(344, 22);
            this.textBoxCountryName.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(296, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(320, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 17);
            this.label9.TabIndex = 13;
            this.label9.Text = "Id";
            // 
            // textBoxCountryId
            // 
            this.textBoxCountryId.Enabled = false;
            this.textBoxCountryId.Location = new System.Drawing.Point(352, 56);
            this.textBoxCountryId.Name = "textBoxCountryId";
            this.textBoxCountryId.Size = new System.Drawing.Size(344, 22);
            this.textBoxCountryId.TabIndex = 12;
            // 
            // buttonInsertCountry
            // 
            this.buttonInsertCountry.Location = new System.Drawing.Point(472, 120);
            this.buttonInsertCountry.Name = "buttonInsertCountry";
            this.buttonInsertCountry.Size = new System.Drawing.Size(104, 40);
            this.buttonInsertCountry.TabIndex = 7;
            this.buttonInsertCountry.Text = "Insert";
            this.buttonInsertCountry.UseVisualStyleBackColor = true;
            this.buttonInsertCountry.Click += new System.EventHandler(this.buttonInsertCountry_Click);
            // 
            // buttonUpdateCountry
            // 
            this.buttonUpdateCountry.Location = new System.Drawing.Point(352, 120);
            this.buttonUpdateCountry.Name = "buttonUpdateCountry";
            this.buttonUpdateCountry.Size = new System.Drawing.Size(104, 40);
            this.buttonUpdateCountry.TabIndex = 6;
            this.buttonUpdateCountry.Text = "Update";
            this.buttonUpdateCountry.UseVisualStyleBackColor = true;
            this.buttonUpdateCountry.Click += new System.EventHandler(this.buttonUpdateCountry_Click);
            // 
            // listBoxCountries
            // 
            this.listBoxCountries.FormattingEnabled = true;
            this.listBoxCountries.ItemHeight = 16;
            this.listBoxCountries.Location = new System.Drawing.Point(8, 48);
            this.listBoxCountries.Name = "listBoxCountries";
            this.listBoxCountries.Size = new System.Drawing.Size(224, 548);
            this.listBoxCountries.TabIndex = 4;
            this.listBoxCountries.SelectedIndexChanged += new System.EventHandler(this.listBoxCountries_SelectedIndexChanged);
            // 
            // tabPageManufacturers
            // 
            this.tabPageManufacturers.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabPageManufacturers.Controls.Add(this.buttonCancelEditingManufacturer);
            this.tabPageManufacturers.Controls.Add(this.textBoxManufacturerName);
            this.tabPageManufacturers.Controls.Add(this.label10);
            this.tabPageManufacturers.Controls.Add(this.label11);
            this.tabPageManufacturers.Controls.Add(this.textBoxManufacturerId);
            this.tabPageManufacturers.Controls.Add(this.buttonInsertManufacturer);
            this.tabPageManufacturers.Controls.Add(this.buttonUpdateManufacturer);
            this.tabPageManufacturers.Controls.Add(this.listBoxManufacturers);
            this.tabPageManufacturers.Location = new System.Drawing.Point(4, 25);
            this.tabPageManufacturers.Name = "tabPageManufacturers";
            this.tabPageManufacturers.Size = new System.Drawing.Size(704, 603);
            this.tabPageManufacturers.TabIndex = 2;
            this.tabPageManufacturers.Text = "Manufacturers";
            // 
            // buttonCancelEditingManufacturer
            // 
            this.buttonCancelEditingManufacturer.Enabled = false;
            this.buttonCancelEditingManufacturer.Location = new System.Drawing.Point(592, 120);
            this.buttonCancelEditingManufacturer.Name = "buttonCancelEditingManufacturer";
            this.buttonCancelEditingManufacturer.Size = new System.Drawing.Size(107, 40);
            this.buttonCancelEditingManufacturer.TabIndex = 19;
            this.buttonCancelEditingManufacturer.Text = "Cancel";
            this.buttonCancelEditingManufacturer.UseVisualStyleBackColor = true;
            this.buttonCancelEditingManufacturer.Click += new System.EventHandler(this.buttonCancelEditingManufacturer_Click);
            // 
            // textBoxManufacturerName
            // 
            this.textBoxManufacturerName.Location = new System.Drawing.Point(352, 88);
            this.textBoxManufacturerName.Name = "textBoxManufacturerName";
            this.textBoxManufacturerName.Size = new System.Drawing.Size(344, 22);
            this.textBoxManufacturerName.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(296, 88);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 17);
            this.label10.TabIndex = 14;
            this.label10.Text = "Name";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(320, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(19, 17);
            this.label11.TabIndex = 13;
            this.label11.Text = "Id";
            // 
            // textBoxManufacturerId
            // 
            this.textBoxManufacturerId.Enabled = false;
            this.textBoxManufacturerId.Location = new System.Drawing.Point(352, 56);
            this.textBoxManufacturerId.Name = "textBoxManufacturerId";
            this.textBoxManufacturerId.Size = new System.Drawing.Size(344, 22);
            this.textBoxManufacturerId.TabIndex = 12;
            // 
            // buttonInsertManufacturer
            // 
            this.buttonInsertManufacturer.Location = new System.Drawing.Point(472, 120);
            this.buttonInsertManufacturer.Name = "buttonInsertManufacturer";
            this.buttonInsertManufacturer.Size = new System.Drawing.Size(104, 40);
            this.buttonInsertManufacturer.TabIndex = 11;
            this.buttonInsertManufacturer.Text = "Insert";
            this.buttonInsertManufacturer.UseVisualStyleBackColor = true;
            // 
            // buttonUpdateManufacturer
            // 
            this.buttonUpdateManufacturer.Location = new System.Drawing.Point(352, 120);
            this.buttonUpdateManufacturer.Name = "buttonUpdateManufacturer";
            this.buttonUpdateManufacturer.Size = new System.Drawing.Size(104, 40);
            this.buttonUpdateManufacturer.TabIndex = 10;
            this.buttonUpdateManufacturer.Text = "Update";
            this.buttonUpdateManufacturer.UseVisualStyleBackColor = true;
            this.buttonUpdateManufacturer.Click += new System.EventHandler(this.buttonUpdateManufacturer_Click);
            // 
            // listBoxManufacturers
            // 
            this.listBoxManufacturers.FormattingEnabled = true;
            this.listBoxManufacturers.ItemHeight = 16;
            this.listBoxManufacturers.Location = new System.Drawing.Point(8, 47);
            this.listBoxManufacturers.Name = "listBoxManufacturers";
            this.listBoxManufacturers.Size = new System.Drawing.Size(224, 548);
            this.listBoxManufacturers.TabIndex = 8;
            this.listBoxManufacturers.SelectedIndexChanged += new System.EventHandler(this.listBoxManufacturers_SelectedIndexChanged);
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 654);
            this.Controls.Add(this.tabControlMain);
            this.Name = "FormAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAdmin";
            this.Load += new System.EventHandler(this.FormAdmin_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageParts.ResumeLayout(false);
            this.tabPageParts.PerformLayout();
            this.tabPageCountries.ResumeLayout(false);
            this.tabPageCountries.PerformLayout();
            this.tabPageManufacturers.ResumeLayout(false);
            this.tabPageManufacturers.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageParts;
        private System.Windows.Forms.TabPage tabPageCountries;
        private System.Windows.Forms.TabPage tabPageManufacturers;
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
        private System.Windows.Forms.Button buttonInsertCountry;
        private System.Windows.Forms.Button buttonUpdateCountry;
        private System.Windows.Forms.ListBox listBoxCountries;
        private System.Windows.Forms.Button buttonInsertManufacturer;
        private System.Windows.Forms.Button buttonUpdateManufacturer;
        private System.Windows.Forms.ListBox listBoxManufacturers;
        private System.Windows.Forms.TextBox textBoxCountryName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxCountryId;
        private System.Windows.Forms.TextBox textBoxManufacturerName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxManufacturerId;
        private System.Windows.Forms.Button buttonCancelEditingPart;
        private System.Windows.Forms.Button buttonCancelEditingCountry;
        private System.Windows.Forms.Button buttonCancelEditingManufacturer;
        private System.Windows.Forms.Button buttonConvertPartFromCode;
        private System.Windows.Forms.Button buttonConvertPartToCode;
    }
}