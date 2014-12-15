namespace TestUI
{
    partial class MEE
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
            this.B_Open = new System.Windows.Forms.Button();
            this.B_Save = new System.Windows.Forms.Button();
            this.NUP_Forme1 = new System.Windows.Forms.NumericUpDown();
            this.LBL_Item1 = new System.Windows.Forms.Label();
            this.LBL_Forme1 = new System.Windows.Forms.Label();
            this.GB_MEvo1 = new System.Windows.Forms.GroupBox();
            this.NUP_Item1 = new System.Windows.Forms.NumericUpDown();
            this.GB_MEvo2 = new System.Windows.Forms.GroupBox();
            this.NUP_Item2 = new System.Windows.Forms.NumericUpDown();
            this.LBL_Forme2 = new System.Windows.Forms.Label();
            this.LBL_Item2 = new System.Windows.Forms.Label();
            this.NUP_Forme2 = new System.Windows.Forms.NumericUpDown();
            this.CHK_MEvo1 = new System.Windows.Forms.CheckBox();
            this.CHK_MEvo2 = new System.Windows.Forms.CheckBox();
            this.CB_Species = new System.Windows.Forms.ComboBox();
            this.GB_MEvo3 = new System.Windows.Forms.GroupBox();
            this.NUP_Item3 = new System.Windows.Forms.NumericUpDown();
            this.LBL_Forme3 = new System.Windows.Forms.Label();
            this.LBL_Item3 = new System.Windows.Forms.Label();
            this.NUP_Forme3 = new System.Windows.Forms.NumericUpDown();
            this.CHK_MEvo3 = new System.Windows.Forms.CheckBox();
            this.LBL_GameMode = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NUP_Forme1)).BeginInit();
            this.GB_MEvo1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUP_Item1)).BeginInit();
            this.GB_MEvo2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUP_Item2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUP_Forme2)).BeginInit();
            this.GB_MEvo3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUP_Item3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUP_Forme3)).BeginInit();
            this.SuspendLayout();
            // 
            // B_Open
            // 
            this.B_Open.Location = new System.Drawing.Point(174, 10);
            this.B_Open.Name = "B_Open";
            this.B_Open.Size = new System.Drawing.Size(75, 23);
            this.B_Open.TabIndex = 4;
            this.B_Open.Text = "Open";
            this.B_Open.UseVisualStyleBackColor = true;
            this.B_Open.Click += new System.EventHandler(this.B_Open_Click);
            // 
            // B_Save
            // 
            this.B_Save.Enabled = false;
            this.B_Save.Location = new System.Drawing.Point(174, 39);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(75, 23);
            this.B_Save.TabIndex = 5;
            this.B_Save.Text = "Save";
            this.B_Save.UseVisualStyleBackColor = true;
            this.B_Save.Click += new System.EventHandler(this.B_Save_Click);
            // 
            // NUP_Forme1
            // 
            this.NUP_Forme1.Enabled = false;
            this.NUP_Forme1.Location = new System.Drawing.Point(9, 81);
            this.NUP_Forme1.Maximum = new decimal(new int[] {
            26,
            0,
            0,
            0});
            this.NUP_Forme1.Name = "NUP_Forme1";
            this.NUP_Forme1.Size = new System.Drawing.Size(36, 20);
            this.NUP_Forme1.TabIndex = 8;
            // 
            // LBL_Item1
            // 
            this.LBL_Item1.AutoSize = true;
            this.LBL_Item1.Enabled = false;
            this.LBL_Item1.Location = new System.Drawing.Point(6, 20);
            this.LBL_Item1.Name = "LBL_Item1";
            this.LBL_Item1.Size = new System.Drawing.Size(27, 13);
            this.LBL_Item1.TabIndex = 9;
            this.LBL_Item1.Text = "Item";
            // 
            // LBL_Forme1
            // 
            this.LBL_Forme1.AutoSize = true;
            this.LBL_Forme1.Enabled = false;
            this.LBL_Forme1.Location = new System.Drawing.Point(6, 65);
            this.LBL_Forme1.Name = "LBL_Forme1";
            this.LBL_Forme1.Size = new System.Drawing.Size(30, 13);
            this.LBL_Forme1.TabIndex = 10;
            this.LBL_Forme1.Text = "Form";
            // 
            // GB_MEvo1
            // 
            this.GB_MEvo1.Controls.Add(this.NUP_Item1);
            this.GB_MEvo1.Controls.Add(this.LBL_Forme1);
            this.GB_MEvo1.Controls.Add(this.LBL_Item1);
            this.GB_MEvo1.Controls.Add(this.NUP_Forme1);
            this.GB_MEvo1.Enabled = false;
            this.GB_MEvo1.Location = new System.Drawing.Point(12, 91);
            this.GB_MEvo1.Name = "GB_MEvo1";
            this.GB_MEvo1.Size = new System.Drawing.Size(75, 109);
            this.GB_MEvo1.TabIndex = 11;
            this.GB_MEvo1.TabStop = false;
            this.GB_MEvo1.Text = "Evolution 1";
            // 
            // NUP_Item1
            // 
            this.NUP_Item1.Enabled = false;
            this.NUP_Item1.Location = new System.Drawing.Point(9, 36);
            this.NUP_Item1.Maximum = new decimal(new int[] {
            775,
            0,
            0,
            0});
            this.NUP_Item1.Name = "NUP_Item1";
            this.NUP_Item1.Size = new System.Drawing.Size(50, 20);
            this.NUP_Item1.TabIndex = 11;
            // 
            // GB_MEvo2
            // 
            this.GB_MEvo2.Controls.Add(this.NUP_Item2);
            this.GB_MEvo2.Controls.Add(this.LBL_Forme2);
            this.GB_MEvo2.Controls.Add(this.LBL_Item2);
            this.GB_MEvo2.Controls.Add(this.NUP_Forme2);
            this.GB_MEvo2.Location = new System.Drawing.Point(93, 91);
            this.GB_MEvo2.Name = "GB_MEvo2";
            this.GB_MEvo2.Size = new System.Drawing.Size(75, 109);
            this.GB_MEvo2.TabIndex = 12;
            this.GB_MEvo2.TabStop = false;
            this.GB_MEvo2.Text = "Evolution 2";
            // 
            // NUP_Item2
            // 
            this.NUP_Item2.Enabled = false;
            this.NUP_Item2.Location = new System.Drawing.Point(9, 36);
            this.NUP_Item2.Maximum = new decimal(new int[] {
            775,
            0,
            0,
            0});
            this.NUP_Item2.Name = "NUP_Item2";
            this.NUP_Item2.Size = new System.Drawing.Size(50, 20);
            this.NUP_Item2.TabIndex = 11;
            // 
            // LBL_Forme2
            // 
            this.LBL_Forme2.AutoSize = true;
            this.LBL_Forme2.Enabled = false;
            this.LBL_Forme2.Location = new System.Drawing.Point(6, 65);
            this.LBL_Forme2.Name = "LBL_Forme2";
            this.LBL_Forme2.Size = new System.Drawing.Size(30, 13);
            this.LBL_Forme2.TabIndex = 10;
            this.LBL_Forme2.Text = "Form";
            // 
            // LBL_Item2
            // 
            this.LBL_Item2.AutoSize = true;
            this.LBL_Item2.Enabled = false;
            this.LBL_Item2.Location = new System.Drawing.Point(6, 20);
            this.LBL_Item2.Name = "LBL_Item2";
            this.LBL_Item2.Size = new System.Drawing.Size(27, 13);
            this.LBL_Item2.TabIndex = 9;
            this.LBL_Item2.Text = "Item";
            // 
            // NUP_Forme2
            // 
            this.NUP_Forme2.Enabled = false;
            this.NUP_Forme2.Location = new System.Drawing.Point(9, 81);
            this.NUP_Forme2.Maximum = new decimal(new int[] {
            26,
            0,
            0,
            0});
            this.NUP_Forme2.Name = "NUP_Forme2";
            this.NUP_Forme2.Size = new System.Drawing.Size(36, 20);
            this.NUP_Forme2.TabIndex = 8;
            // 
            // CHK_MEvo1
            // 
            this.CHK_MEvo1.AutoSize = true;
            this.CHK_MEvo1.Enabled = false;
            this.CHK_MEvo1.Location = new System.Drawing.Point(12, 68);
            this.CHK_MEvo1.Name = "CHK_MEvo1";
            this.CHK_MEvo1.Size = new System.Drawing.Size(65, 17);
            this.CHK_MEvo1.TabIndex = 13;
            this.CHK_MEvo1.Text = "Enabled";
            this.CHK_MEvo1.UseVisualStyleBackColor = true;
            this.CHK_MEvo1.CheckedChanged += new System.EventHandler(this.CHK_MEvo1_CheckedChanged);
            // 
            // CHK_MEvo2
            // 
            this.CHK_MEvo2.AutoSize = true;
            this.CHK_MEvo2.Enabled = false;
            this.CHK_MEvo2.Location = new System.Drawing.Point(93, 68);
            this.CHK_MEvo2.Name = "CHK_MEvo2";
            this.CHK_MEvo2.Size = new System.Drawing.Size(65, 17);
            this.CHK_MEvo2.TabIndex = 14;
            this.CHK_MEvo2.Text = "Enabled";
            this.CHK_MEvo2.UseVisualStyleBackColor = true;
            this.CHK_MEvo2.CheckedChanged += new System.EventHandler(this.CHK_MEvo2_CheckedChanged);
            // 
            // CB_Species
            // 
            this.CB_Species.Enabled = false;
            this.CB_Species.FormattingEnabled = true;
            this.CB_Species.Location = new System.Drawing.Point(12, 12);
            this.CB_Species.Name = "CB_Species";
            this.CB_Species.Size = new System.Drawing.Size(156, 21);
            this.CB_Species.TabIndex = 15;
            this.CB_Species.SelectedIndexChanged += new System.EventHandler(this.CB_Species_SelectedIndexChanged);
            this.CB_Species.SelectedValueChanged += new System.EventHandler(this.CB_Species_SelectedValueChanged);
            // 
            // GB_MEvo3
            // 
            this.GB_MEvo3.Controls.Add(this.NUP_Item3);
            this.GB_MEvo3.Controls.Add(this.LBL_Forme3);
            this.GB_MEvo3.Controls.Add(this.LBL_Item3);
            this.GB_MEvo3.Controls.Add(this.NUP_Forme3);
            this.GB_MEvo3.Enabled = false;
            this.GB_MEvo3.Location = new System.Drawing.Point(174, 91);
            this.GB_MEvo3.Name = "GB_MEvo3";
            this.GB_MEvo3.Size = new System.Drawing.Size(75, 109);
            this.GB_MEvo3.TabIndex = 13;
            this.GB_MEvo3.TabStop = false;
            this.GB_MEvo3.Text = "Evolution 3";
            // 
            // NUP_Item3
            // 
            this.NUP_Item3.Enabled = false;
            this.NUP_Item3.Location = new System.Drawing.Point(9, 36);
            this.NUP_Item3.Maximum = new decimal(new int[] {
            775,
            0,
            0,
            0});
            this.NUP_Item3.Name = "NUP_Item3";
            this.NUP_Item3.Size = new System.Drawing.Size(50, 20);
            this.NUP_Item3.TabIndex = 11;
            // 
            // LBL_Forme3
            // 
            this.LBL_Forme3.AutoSize = true;
            this.LBL_Forme3.Enabled = false;
            this.LBL_Forme3.Location = new System.Drawing.Point(6, 65);
            this.LBL_Forme3.Name = "LBL_Forme3";
            this.LBL_Forme3.Size = new System.Drawing.Size(30, 13);
            this.LBL_Forme3.TabIndex = 10;
            this.LBL_Forme3.Text = "Form";
            // 
            // LBL_Item3
            // 
            this.LBL_Item3.AutoSize = true;
            this.LBL_Item3.Enabled = false;
            this.LBL_Item3.Location = new System.Drawing.Point(6, 20);
            this.LBL_Item3.Name = "LBL_Item3";
            this.LBL_Item3.Size = new System.Drawing.Size(27, 13);
            this.LBL_Item3.TabIndex = 9;
            this.LBL_Item3.Text = "Item";
            // 
            // NUP_Forme3
            // 
            this.NUP_Forme3.Enabled = false;
            this.NUP_Forme3.Location = new System.Drawing.Point(9, 81);
            this.NUP_Forme3.Maximum = new decimal(new int[] {
            26,
            0,
            0,
            0});
            this.NUP_Forme3.Name = "NUP_Forme3";
            this.NUP_Forme3.Size = new System.Drawing.Size(36, 20);
            this.NUP_Forme3.TabIndex = 8;
            // 
            // CHK_MEvo3
            // 
            this.CHK_MEvo3.AutoSize = true;
            this.CHK_MEvo3.Enabled = false;
            this.CHK_MEvo3.Location = new System.Drawing.Point(174, 68);
            this.CHK_MEvo3.Name = "CHK_MEvo3";
            this.CHK_MEvo3.Size = new System.Drawing.Size(65, 17);
            this.CHK_MEvo3.TabIndex = 16;
            this.CHK_MEvo3.Text = "Enabled";
            this.CHK_MEvo3.UseVisualStyleBackColor = true;
            this.CHK_MEvo3.CheckedChanged += new System.EventHandler(this.CHK_MEvo3_CheckedChanged);
            // 
            // LBL_GameMode
            // 
            this.LBL_GameMode.AutoSize = true;
            this.LBL_GameMode.Enabled = false;
            this.LBL_GameMode.Location = new System.Drawing.Point(9, 36);
            this.LBL_GameMode.Name = "LBL_GameMode";
            this.LBL_GameMode.Size = new System.Drawing.Size(70, 13);
            this.LBL_GameMode.TabIndex = 17;
            this.LBL_GameMode.Text = "Game mode: ";
            // 
            // MEE
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 212);
            this.Controls.Add(this.LBL_GameMode);
            this.Controls.Add(this.CHK_MEvo3);
            this.Controls.Add(this.GB_MEvo3);
            this.Controls.Add(this.CB_Species);
            this.Controls.Add(this.CHK_MEvo2);
            this.Controls.Add(this.CHK_MEvo1);
            this.Controls.Add(this.GB_MEvo2);
            this.Controls.Add(this.B_Save);
            this.Controls.Add(this.B_Open);
            this.Controls.Add(this.GB_MEvo1);
            this.Name = "MEE";
            this.Text = "Mega Evo Editor";
            ((System.ComponentModel.ISupportInitialize)(this.NUP_Forme1)).EndInit();
            this.GB_MEvo1.ResumeLayout(false);
            this.GB_MEvo1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUP_Item1)).EndInit();
            this.GB_MEvo2.ResumeLayout(false);
            this.GB_MEvo2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUP_Item2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUP_Forme2)).EndInit();
            this.GB_MEvo3.ResumeLayout(false);
            this.GB_MEvo3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUP_Item3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUP_Forme3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_Open;
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.NumericUpDown NUP_Forme1;
        private System.Windows.Forms.Label LBL_Item1;
        private System.Windows.Forms.Label LBL_Forme1;
        private System.Windows.Forms.GroupBox GB_MEvo1;
        private System.Windows.Forms.NumericUpDown NUP_Item1;
        private System.Windows.Forms.GroupBox GB_MEvo2;
        private System.Windows.Forms.NumericUpDown NUP_Item2;
        private System.Windows.Forms.Label LBL_Forme2;
        private System.Windows.Forms.Label LBL_Item2;
        private System.Windows.Forms.NumericUpDown NUP_Forme2;
        private System.Windows.Forms.CheckBox CHK_MEvo1;
        private System.Windows.Forms.CheckBox CHK_MEvo2;
        private System.Windows.Forms.ComboBox CB_Species;
        private System.Windows.Forms.GroupBox GB_MEvo3;
        private System.Windows.Forms.NumericUpDown NUP_Item3;
        private System.Windows.Forms.Label LBL_Forme3;
        private System.Windows.Forms.Label LBL_Item3;
        private System.Windows.Forms.NumericUpDown NUP_Forme3;
        private System.Windows.Forms.CheckBox CHK_MEvo3;
        private System.Windows.Forms.Label LBL_GameMode;
    }
}

