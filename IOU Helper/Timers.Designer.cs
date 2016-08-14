namespace IOU_Helper
{
    partial class Timers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Timers));
            this.comboBoxUsers = new System.Windows.Forms.ComboBox();
            this.textBoxHours = new System.Windows.Forms.TextBox();
            this.textBoxMinutes = new System.Windows.Forms.TextBox();
            this.buttonCreateTimer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxTimers = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonDeleteAll = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonEnable = new System.Windows.Forms.Button();
            this.buttonDisable = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxUsers
            // 
            this.comboBoxUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUsers.FormattingEnabled = true;
            this.comboBoxUsers.Location = new System.Drawing.Point(528, 162);
            this.comboBoxUsers.Name = "comboBoxUsers";
            this.comboBoxUsers.Size = new System.Drawing.Size(363, 39);
            this.comboBoxUsers.TabIndex = 0;
            // 
            // textBoxHours
            // 
            this.textBoxHours.Location = new System.Drawing.Point(528, 278);
            this.textBoxHours.Name = "textBoxHours";
            this.textBoxHours.Size = new System.Drawing.Size(163, 38);
            this.textBoxHours.TabIndex = 1;
            this.textBoxHours.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxHours_KeyPress);
            // 
            // textBoxMinutes
            // 
            this.textBoxMinutes.Location = new System.Drawing.Point(724, 278);
            this.textBoxMinutes.Name = "textBoxMinutes";
            this.textBoxMinutes.Size = new System.Drawing.Size(167, 38);
            this.textBoxMinutes.TabIndex = 2;
            this.textBoxMinutes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMinutes_KeyPress);
            // 
            // buttonCreateTimer
            // 
            this.buttonCreateTimer.Location = new System.Drawing.Point(597, 381);
            this.buttonCreateTimer.Name = "buttonCreateTimer";
            this.buttonCreateTimer.Size = new System.Drawing.Size(223, 49);
            this.buttonCreateTimer.TabIndex = 3;
            this.buttonCreateTimer.Text = "Create Timer";
            this.buttonCreateTimer.UseVisualStyleBackColor = true;
            this.buttonCreateTimer.Click += new System.EventHandler(this.buttonCreateTimer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(528, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Hours";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(752, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 32);
            this.label2.TabIndex = 5;
            this.label2.Text = "Minutes";
            // 
            // listBoxTimers
            // 
            this.listBoxTimers.FormattingEnabled = true;
            this.listBoxTimers.ItemHeight = 31;
            this.listBoxTimers.Location = new System.Drawing.Point(36, 94);
            this.listBoxTimers.Name = "listBoxTimers";
            this.listBoxTimers.Size = new System.Drawing.Size(423, 407);
            this.listBoxTimers.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(144, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 32);
            this.label3.TabIndex = 7;
            this.label3.Text = "List Of Timers";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(612, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(221, 32);
            this.label4.TabIndex = 8;
            this.label4.Text = "Add New Timer";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(46, 589);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(178, 46);
            this.buttonDelete.TabIndex = 9;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonDeleteAll
            // 
            this.buttonDeleteAll.Location = new System.Drawing.Point(237, 589);
            this.buttonDeleteAll.Name = "buttonDeleteAll";
            this.buttonDeleteAll.Size = new System.Drawing.Size(207, 46);
            this.buttonDeleteAll.TabIndex = 10;
            this.buttonDeleteAll.Text = "Delete All";
            this.buttonDeleteAll.UseVisualStyleBackColor = true;
            this.buttonDeleteAll.Click += new System.EventHandler(this.buttonDeleteAll_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(602, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(226, 32);
            this.label5.TabIndex = 11;
            this.label5.Text = "Select Character";
            // 
            // buttonEnable
            // 
            this.buttonEnable.Location = new System.Drawing.Point(46, 525);
            this.buttonEnable.Name = "buttonEnable";
            this.buttonEnable.Size = new System.Drawing.Size(178, 46);
            this.buttonEnable.TabIndex = 12;
            this.buttonEnable.Text = "Enable";
            this.buttonEnable.UseVisualStyleBackColor = true;
            this.buttonEnable.Click += new System.EventHandler(this.buttonEnable_Click);
            // 
            // buttonDisable
            // 
            this.buttonDisable.Location = new System.Drawing.Point(237, 525);
            this.buttonDisable.Name = "buttonDisable";
            this.buttonDisable.Size = new System.Drawing.Size(207, 46);
            this.buttonDisable.TabIndex = 13;
            this.buttonDisable.Text = "Disable";
            this.buttonDisable.UseVisualStyleBackColor = true;
            this.buttonDisable.Click += new System.EventHandler(this.buttonDisable_Click);
            // 
            // Timers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 666);
            this.Controls.Add(this.buttonDisable);
            this.Controls.Add(this.buttonEnable);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonDeleteAll);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxTimers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCreateTimer);
            this.Controls.Add(this.textBoxMinutes);
            this.Controls.Add(this.textBoxHours);
            this.Controls.Add(this.comboBoxUsers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Timers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Timers";
            this.Load += new System.EventHandler(this.Timers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxUsers;
        private System.Windows.Forms.TextBox textBoxHours;
        private System.Windows.Forms.TextBox textBoxMinutes;
        private System.Windows.Forms.Button buttonCreateTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxTimers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonDeleteAll;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonEnable;
        private System.Windows.Forms.Button buttonDisable;
    }
}