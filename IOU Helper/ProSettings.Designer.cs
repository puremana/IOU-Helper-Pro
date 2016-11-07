namespace IOU_Helper
{
    partial class ProSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProSettings));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonOverlayColor = new System.Windows.Forms.Button();
            this.labelColor = new System.Windows.Forms.Label();
            this.comboBoxUnitXpGold = new System.Windows.Forms.ComboBox();
            this.comboBoxCardDrop = new System.Windows.Forms.ComboBox();
            this.textBoxRefreshTimer = new System.Windows.Forms.TextBox();
            this.comboBoxSigFig = new System.Windows.Forms.ComboBox();
            this.radioButtonDCYes = new System.Windows.Forms.RadioButton();
            this.radioButtonDCNo = new System.Windows.Forms.RadioButton();
            this.comboBoxAscTier = new System.Windows.Forms.ComboBox();
            this.radioButtonMOYes = new System.Windows.Forms.RadioButton();
            this.radioButtonMONo = new System.Windows.Forms.RadioButton();
            this.buttonRestore = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxCardDrop);
            this.groupBox1.Controls.Add(this.comboBoxUnitXpGold);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(41, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(848, 191);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Unit Times";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxSigFig);
            this.groupBox2.Controls.Add(this.textBoxRefreshTimer);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(41, 263);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(863, 220);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Display Settings";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.comboBoxAscTier);
            this.groupBox3.Controls.Add(this.labelColor);
            this.groupBox3.Controls.Add(this.buttonOverlayColor);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(41, 502);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(848, 369);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Other";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Xp, Gold, Party Damage Unit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Card Drop Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(324, 32);
            this.label3.TabIndex = 0;
            this.label3.Text = "Refresh Timer (seconds)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(251, 32);
            this.label4.TabIndex = 1;
            this.label4.Text = "Significant Figures";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(203, 32);
            this.label6.TabIndex = 1;
            this.label6.Text = "Ascension Tier";
            // 
            // buttonOverlayColor
            // 
            this.buttonOverlayColor.Location = new System.Drawing.Point(32, 283);
            this.buttonOverlayColor.Name = "buttonOverlayColor";
            this.buttonOverlayColor.Size = new System.Drawing.Size(249, 57);
            this.buttonOverlayColor.TabIndex = 3;
            this.buttonOverlayColor.Text = "Overlay Color";
            this.buttonOverlayColor.UseVisualStyleBackColor = true;
            this.buttonOverlayColor.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelColor
            // 
            this.labelColor.AutoSize = true;
            this.labelColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelColor.Location = new System.Drawing.Point(543, 285);
            this.labelColor.Name = "labelColor";
            this.labelColor.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.labelColor.Size = new System.Drawing.Size(125, 54);
            this.labelColor.TabIndex = 4;
            this.labelColor.Text = "label8";
            // 
            // comboBoxUnitXpGold
            // 
            this.comboBoxUnitXpGold.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUnitXpGold.FormattingEnabled = true;
            this.comboBoxUnitXpGold.Items.AddRange(new object[] {
            "Minute",
            "Hour"});
            this.comboBoxUnitXpGold.Location = new System.Drawing.Point(488, 46);
            this.comboBoxUnitXpGold.Name = "comboBoxUnitXpGold";
            this.comboBoxUnitXpGold.Size = new System.Drawing.Size(287, 39);
            this.comboBoxUnitXpGold.TabIndex = 2;
            // 
            // comboBoxCardDrop
            // 
            this.comboBoxCardDrop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCardDrop.FormattingEnabled = true;
            this.comboBoxCardDrop.Items.AddRange(new object[] {
            "Minute",
            "Hour",
            "Day"});
            this.comboBoxCardDrop.Location = new System.Drawing.Point(488, 112);
            this.comboBoxCardDrop.Name = "comboBoxCardDrop";
            this.comboBoxCardDrop.Size = new System.Drawing.Size(287, 39);
            this.comboBoxCardDrop.TabIndex = 3;
            // 
            // textBoxRefreshTimer
            // 
            this.textBoxRefreshTimer.Location = new System.Drawing.Point(488, 60);
            this.textBoxRefreshTimer.Name = "textBoxRefreshTimer";
            this.textBoxRefreshTimer.Size = new System.Drawing.Size(287, 38);
            this.textBoxRefreshTimer.TabIndex = 2;
            // 
            // comboBoxSigFig
            // 
            this.comboBoxSigFig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSigFig.FormattingEnabled = true;
            this.comboBoxSigFig.Items.AddRange(new object[] {
            "10"});
            this.comboBoxSigFig.Location = new System.Drawing.Point(488, 129);
            this.comboBoxSigFig.Name = "comboBoxSigFig";
            this.comboBoxSigFig.Size = new System.Drawing.Size(287, 39);
            this.comboBoxSigFig.TabIndex = 3;
            // 
            // radioButtonDCYes
            // 
            this.radioButtonDCYes.AutoSize = true;
            this.radioButtonDCYes.Location = new System.Drawing.Point(479, 28);
            this.radioButtonDCYes.Name = "radioButtonDCYes";
            this.radioButtonDCYes.Size = new System.Drawing.Size(101, 36);
            this.radioButtonDCYes.TabIndex = 5;
            this.radioButtonDCYes.TabStop = true;
            this.radioButtonDCYes.Text = "Yes";
            this.radioButtonDCYes.UseVisualStyleBackColor = true;
            // 
            // radioButtonDCNo
            // 
            this.radioButtonDCNo.AutoSize = true;
            this.radioButtonDCNo.Location = new System.Drawing.Point(642, 30);
            this.radioButtonDCNo.Name = "radioButtonDCNo";
            this.radioButtonDCNo.Size = new System.Drawing.Size(88, 36);
            this.radioButtonDCNo.TabIndex = 6;
            this.radioButtonDCNo.TabStop = true;
            this.radioButtonDCNo.Text = "No";
            this.radioButtonDCNo.UseVisualStyleBackColor = true;
            // 
            // comboBoxAscTier
            // 
            this.comboBoxAscTier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAscTier.FormattingEnabled = true;
            this.comboBoxAscTier.Items.AddRange(new object[] {
            "AT3",
            "AT2",
            "AT1",
            "AT0"});
            this.comboBoxAscTier.Location = new System.Drawing.Point(470, 130);
            this.comboBoxAscTier.Name = "comboBoxAscTier";
            this.comboBoxAscTier.Size = new System.Drawing.Size(287, 39);
            this.comboBoxAscTier.TabIndex = 7;
            // 
            // radioButtonMOYes
            // 
            this.radioButtonMOYes.AutoSize = true;
            this.radioButtonMOYes.Location = new System.Drawing.Point(478, 26);
            this.radioButtonMOYes.Name = "radioButtonMOYes";
            this.radioButtonMOYes.Size = new System.Drawing.Size(101, 36);
            this.radioButtonMOYes.TabIndex = 8;
            this.radioButtonMOYes.TabStop = true;
            this.radioButtonMOYes.Text = "Yes";
            this.radioButtonMOYes.UseVisualStyleBackColor = true;
            // 
            // radioButtonMONo
            // 
            this.radioButtonMONo.AutoSize = true;
            this.radioButtonMONo.Location = new System.Drawing.Point(642, 27);
            this.radioButtonMONo.Name = "radioButtonMONo";
            this.radioButtonMONo.Size = new System.Drawing.Size(88, 36);
            this.radioButtonMONo.TabIndex = 9;
            this.radioButtonMONo.TabStop = true;
            this.radioButtonMONo.Text = "No";
            this.radioButtonMONo.UseVisualStyleBackColor = true;
            // 
            // buttonRestore
            // 
            this.buttonRestore.Location = new System.Drawing.Point(49, 887);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.Size = new System.Drawing.Size(252, 65);
            this.buttonRestore.TabIndex = 3;
            this.buttonRestore.Text = "Restore Default";
            this.buttonRestore.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(331, 887);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(252, 65);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(622, 887);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(252, 65);
            this.buttonApply.TabIndex = 5;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButtonDCYes);
            this.groupBox4.Controls.Add(this.radioButtonDCNo);
            this.groupBox4.Location = new System.Drawing.Point(8, 37);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(767, 80);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Double Cards";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioButtonMOYes);
            this.groupBox5.Controls.Add(this.radioButtonMONo);
            this.groupBox5.Location = new System.Drawing.Point(8, 194);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(767, 74);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Move Overlay on Resize";
            // 
            // ProSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 975);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonRestore);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pro Settings";
            this.Load += new System.EventHandler(this.ProSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonOverlayColor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.ComboBox comboBoxUnitXpGold;
        private System.Windows.Forms.ComboBox comboBoxCardDrop;
        private System.Windows.Forms.ComboBox comboBoxSigFig;
        private System.Windows.Forms.TextBox textBoxRefreshTimer;
        private System.Windows.Forms.RadioButton radioButtonMONo;
        private System.Windows.Forms.RadioButton radioButtonMOYes;
        private System.Windows.Forms.ComboBox comboBoxAscTier;
        private System.Windows.Forms.RadioButton radioButtonDCNo;
        private System.Windows.Forms.RadioButton radioButtonDCYes;
        private System.Windows.Forms.Button buttonRestore;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}