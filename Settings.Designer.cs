namespace IOU_Helper
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonLarge = new System.Windows.Forms.RadioButton();
            this.radioButtonMedium = new System.Windows.Forms.RadioButton();
            this.radioButtonSmall = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxRefresh = new System.Windows.Forms.GroupBox();
            this.radioButtonRefreshMinutes = new System.Windows.Forms.RadioButton();
            this.radioButtonRefreshSeconds = new System.Windows.Forms.RadioButton();
            this.textBoxRefresh = new System.Windows.Forms.TextBox();
            this.checkBoxRefresh = new System.Windows.Forms.CheckBox();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonDefault = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonClickSeconds = new System.Windows.Forms.RadioButton();
            this.radioButtonClickMilliseconds = new System.Windows.Forms.RadioButton();
            this.textBoxAutoClicker = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonLoadSettings = new System.Windows.Forms.Button();
            this.buttonSaveSettings = new System.Windows.Forms.Button();
            this.buttonSaveAsSettings = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBoxRefresh.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonLarge);
            this.groupBox1.Controls.Add(this.radioButtonMedium);
            this.groupBox1.Controls.Add(this.radioButtonSmall);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxHeight);
            this.groupBox1.Controls.Add(this.textBoxWidth);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(29, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(904, 209);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Client Size";
            // 
            // radioButtonLarge
            // 
            this.radioButtonLarge.AutoSize = true;
            this.radioButtonLarge.Location = new System.Drawing.Point(623, 38);
            this.radioButtonLarge.Name = "radioButtonLarge";
            this.radioButtonLarge.Size = new System.Drawing.Size(125, 36);
            this.radioButtonLarge.TabIndex = 10;
            this.radioButtonLarge.TabStop = true;
            this.radioButtonLarge.Text = "Large";
            this.radioButtonLarge.UseVisualStyleBackColor = true;
            // 
            // radioButtonMedium
            // 
            this.radioButtonMedium.AutoSize = true;
            this.radioButtonMedium.Location = new System.Drawing.Point(369, 38);
            this.radioButtonMedium.Name = "radioButtonMedium";
            this.radioButtonMedium.Size = new System.Drawing.Size(153, 36);
            this.radioButtonMedium.TabIndex = 9;
            this.radioButtonMedium.TabStop = true;
            this.radioButtonMedium.Text = "Medium";
            this.radioButtonMedium.UseVisualStyleBackColor = true;
            this.radioButtonMedium.CheckedChanged += new System.EventHandler(this.radioButtonMedium_CheckedChanged);
            // 
            // radioButtonSmall
            // 
            this.radioButtonSmall.AutoSize = true;
            this.radioButtonSmall.Location = new System.Drawing.Point(122, 38);
            this.radioButtonSmall.Name = "radioButtonSmall";
            this.radioButtonSmall.Size = new System.Drawing.Size(124, 36);
            this.radioButtonSmall.TabIndex = 8;
            this.radioButtonSmall.TabStop = true;
            this.radioButtonSmall.Text = "Small";
            this.radioButtonSmall.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(417, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 32);
            this.label6.TabIndex = 7;
            this.label6.Text = "Height :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(74, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 32);
            this.label5.TabIndex = 6;
            this.label5.Text = "Width : ";
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(549, 148);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(196, 38);
            this.textBoxHeight.TabIndex = 5;
            this.textBoxHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxHeight_KeyPress);
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(206, 148);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(196, 38);
            this.textBoxWidth.TabIndex = 4;
            this.textBoxWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxWidth_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(357, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 32);
            this.label4.TabIndex = 3;
            this.label4.Text = "Custom Size";
            // 
            // groupBoxRefresh
            // 
            this.groupBoxRefresh.Controls.Add(this.radioButtonRefreshMinutes);
            this.groupBoxRefresh.Controls.Add(this.radioButtonRefreshSeconds);
            this.groupBoxRefresh.Controls.Add(this.textBoxRefresh);
            this.groupBoxRefresh.Controls.Add(this.checkBoxRefresh);
            this.groupBoxRefresh.Location = new System.Drawing.Point(29, 252);
            this.groupBoxRefresh.Name = "groupBoxRefresh";
            this.groupBoxRefresh.Size = new System.Drawing.Size(904, 171);
            this.groupBoxRefresh.TabIndex = 1;
            this.groupBoxRefresh.TabStop = false;
            this.groupBoxRefresh.Text = "Refresh Settings";
            // 
            // radioButtonRefreshMinutes
            // 
            this.radioButtonRefreshMinutes.AutoSize = true;
            this.radioButtonRefreshMinutes.Checked = true;
            this.radioButtonRefreshMinutes.Location = new System.Drawing.Point(585, 99);
            this.radioButtonRefreshMinutes.Name = "radioButtonRefreshMinutes";
            this.radioButtonRefreshMinutes.Size = new System.Drawing.Size(152, 36);
            this.radioButtonRefreshMinutes.TabIndex = 4;
            this.radioButtonRefreshMinutes.TabStop = true;
            this.radioButtonRefreshMinutes.Text = "Minutes";
            this.radioButtonRefreshMinutes.UseVisualStyleBackColor = true;
            // 
            // radioButtonRefreshSeconds
            // 
            this.radioButtonRefreshSeconds.AutoSize = true;
            this.radioButtonRefreshSeconds.Location = new System.Drawing.Point(585, 47);
            this.radioButtonRefreshSeconds.Name = "radioButtonRefreshSeconds";
            this.radioButtonRefreshSeconds.Size = new System.Drawing.Size(163, 36);
            this.radioButtonRefreshSeconds.TabIndex = 3;
            this.radioButtonRefreshSeconds.Text = "Seconds";
            this.radioButtonRefreshSeconds.UseVisualStyleBackColor = true;
            // 
            // textBoxRefresh
            // 
            this.textBoxRefresh.Location = new System.Drawing.Point(293, 72);
            this.textBoxRefresh.Name = "textBoxRefresh";
            this.textBoxRefresh.Size = new System.Drawing.Size(233, 38);
            this.textBoxRefresh.TabIndex = 1;
            this.textBoxRefresh.Text = "40";
            this.textBoxRefresh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxRefresh_KeyPress);
            // 
            // checkBoxRefresh
            // 
            this.checkBoxRefresh.AutoSize = true;
            this.checkBoxRefresh.Location = new System.Drawing.Point(38, 75);
            this.checkBoxRefresh.Name = "checkBoxRefresh";
            this.checkBoxRefresh.Size = new System.Drawing.Size(228, 36);
            this.checkBoxRefresh.TabIndex = 0;
            this.checkBoxRefresh.Text = "Refresh every";
            this.checkBoxRefresh.UseVisualStyleBackColor = true;
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(640, 581);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(283, 60);
            this.buttonApply.TabIndex = 2;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(332, 581);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(283, 60);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonDefault
            // 
            this.buttonDefault.Location = new System.Drawing.Point(29, 581);
            this.buttonDefault.Name = "buttonDefault";
            this.buttonDefault.Size = new System.Drawing.Size(283, 60);
            this.buttonDefault.TabIndex = 4;
            this.buttonDefault.Text = "Restore Default";
            this.buttonDefault.UseVisualStyleBackColor = true;
            this.buttonDefault.Click += new System.EventHandler(this.buttonDefault_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonClickSeconds);
            this.groupBox2.Controls.Add(this.radioButtonClickMilliseconds);
            this.groupBox2.Controls.Add(this.textBoxAutoClicker);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(29, 430);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(904, 145);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Auto Clicker Settings";
            // 
            // radioButtonClickSeconds
            // 
            this.radioButtonClickSeconds.AutoSize = true;
            this.radioButtonClickSeconds.Location = new System.Drawing.Point(585, 86);
            this.radioButtonClickSeconds.Name = "radioButtonClickSeconds";
            this.radioButtonClickSeconds.Size = new System.Drawing.Size(163, 36);
            this.radioButtonClickSeconds.TabIndex = 3;
            this.radioButtonClickSeconds.Text = "Seconds";
            this.radioButtonClickSeconds.UseVisualStyleBackColor = true;
            // 
            // radioButtonClickMilliseconds
            // 
            this.radioButtonClickMilliseconds.AutoSize = true;
            this.radioButtonClickMilliseconds.Checked = true;
            this.radioButtonClickMilliseconds.Location = new System.Drawing.Point(585, 38);
            this.radioButtonClickMilliseconds.Name = "radioButtonClickMilliseconds";
            this.radioButtonClickMilliseconds.Size = new System.Drawing.Size(209, 36);
            this.radioButtonClickMilliseconds.TabIndex = 2;
            this.radioButtonClickMilliseconds.TabStop = true;
            this.radioButtonClickMilliseconds.Text = "Milliseconds";
            this.radioButtonClickMilliseconds.UseVisualStyleBackColor = true;
            // 
            // textBoxAutoClicker
            // 
            this.textBoxAutoClicker.Location = new System.Drawing.Point(293, 66);
            this.textBoxAutoClicker.Name = "textBoxAutoClicker";
            this.textBoxAutoClicker.Size = new System.Drawing.Size(229, 38);
            this.textBoxAutoClicker.TabIndex = 1;
            this.textBoxAutoClicker.Text = "100";
            this.textBoxAutoClicker.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAutoClicker_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Click every";
            // 
            // buttonLoadSettings
            // 
            this.buttonLoadSettings.Location = new System.Drawing.Point(29, 647);
            this.buttonLoadSettings.Name = "buttonLoadSettings";
            this.buttonLoadSettings.Size = new System.Drawing.Size(283, 60);
            this.buttonLoadSettings.TabIndex = 6;
            this.buttonLoadSettings.Text = "Load";
            this.buttonLoadSettings.UseVisualStyleBackColor = true;
            this.buttonLoadSettings.Click += new System.EventHandler(this.buttonLoadSettings_Click);
            // 
            // buttonSaveSettings
            // 
            this.buttonSaveSettings.Location = new System.Drawing.Point(332, 647);
            this.buttonSaveSettings.Name = "buttonSaveSettings";
            this.buttonSaveSettings.Size = new System.Drawing.Size(283, 60);
            this.buttonSaveSettings.TabIndex = 7;
            this.buttonSaveSettings.Text = "Save";
            this.buttonSaveSettings.UseVisualStyleBackColor = true;
            this.buttonSaveSettings.Click += new System.EventHandler(this.buttonSaveSettings_Click);
            // 
            // buttonSaveAsSettings
            // 
            this.buttonSaveAsSettings.Location = new System.Drawing.Point(640, 647);
            this.buttonSaveAsSettings.Name = "buttonSaveAsSettings";
            this.buttonSaveAsSettings.Size = new System.Drawing.Size(283, 60);
            this.buttonSaveAsSettings.TabIndex = 8;
            this.buttonSaveAsSettings.Text = "Save As";
            this.buttonSaveAsSettings.UseVisualStyleBackColor = true;
            this.buttonSaveAsSettings.Click += new System.EventHandler(this.buttonSaveAsSettings_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 718);
            this.Controls.Add(this.buttonSaveAsSettings);
            this.Controls.Add(this.buttonSaveSettings);
            this.Controls.Add(this.buttonLoadSettings);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonDefault);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.groupBoxRefresh);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxRefresh.ResumeLayout(false);
            this.groupBoxRefresh.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonLarge;
        private System.Windows.Forms.RadioButton radioButtonMedium;
        private System.Windows.Forms.RadioButton radioButtonSmall;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.TextBox textBoxWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBoxRefresh;
        private System.Windows.Forms.TextBox textBoxRefresh;
        private System.Windows.Forms.CheckBox checkBoxRefresh;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonDefault;
        private System.Windows.Forms.RadioButton radioButtonRefreshMinutes;
        private System.Windows.Forms.RadioButton radioButtonRefreshSeconds;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonClickSeconds;
        private System.Windows.Forms.RadioButton radioButtonClickMilliseconds;
        private System.Windows.Forms.TextBox textBoxAutoClicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonLoadSettings;
        private System.Windows.Forms.Button buttonSaveSettings;
        private System.Windows.Forms.Button buttonSaveAsSettings;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}