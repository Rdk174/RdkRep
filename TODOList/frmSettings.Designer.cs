namespace TODOList
{
    partial class frmSettings
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listExample = new System.Windows.Forms.ListBox();
            this.btnExpired = new System.Windows.Forms.Button();
            this.btnClosed = new System.Windows.Forms.Button();
            this.btnRow2 = new System.Windows.Forms.Button();
            this.btnRow1 = new System.Windows.Forms.Button();
            this.lbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFont = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.lblExpiredColor = new System.Windows.Forms.Label();
            this.lblClosedColor = new System.Windows.Forms.Label();
            this.lblRow2Color = new System.Windows.Forms.Label();
            this.lblRow1Color = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.lblFont = new System.Windows.Forms.Label();
            this.btnToDefault = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRow1Color);
            this.groupBox1.Controls.Add(this.lblRow2Color);
            this.groupBox1.Controls.Add(this.lblClosedColor);
            this.groupBox1.Controls.Add(this.lblExpiredColor);
            this.groupBox1.Controls.Add(this.btnExpired);
            this.groupBox1.Controls.Add(this.btnClosed);
            this.groupBox1.Controls.Add(this.btnRow2);
            this.groupBox1.Controls.Add(this.btnRow1);
            this.groupBox1.Controls.Add(this.lbl);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(18, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 137);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Цвета";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listExample);
            this.groupBox2.Location = new System.Drawing.Point(342, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(194, 166);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Образец";
            // 
            // listExample
            // 
            this.listExample.FormattingEnabled = true;
            this.listExample.IntegralHeight = false;
            this.listExample.Items.AddRange(new object[] {
            "Строка1",
            "Строка2",
            "Завершенная задача",
            "Просроченная задача"});
            this.listExample.Location = new System.Drawing.Point(6, 19);
            this.listExample.Name = "listExample";
            this.listExample.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listExample.Size = new System.Drawing.Size(182, 134);
            this.listExample.TabIndex = 3;
            this.listExample.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listExample_DrawItem);
            this.listExample.SelectedIndexChanged += new System.EventHandler(this.listExample_SelectedIndexChanged);
            // 
            // btnExpired
            // 
            this.btnExpired.Location = new System.Drawing.Point(268, 105);
            this.btnExpired.Name = "btnExpired";
            this.btnExpired.Size = new System.Drawing.Size(25, 21);
            this.btnExpired.TabIndex = 2;
            this.btnExpired.Text = "->";
            this.btnExpired.UseVisualStyleBackColor = true;
            this.btnExpired.Click += new System.EventHandler(this.btnExpired_Click);
            // 
            // btnClosed
            // 
            this.btnClosed.Location = new System.Drawing.Point(268, 79);
            this.btnClosed.Name = "btnClosed";
            this.btnClosed.Size = new System.Drawing.Size(25, 21);
            this.btnClosed.TabIndex = 2;
            this.btnClosed.Text = "->";
            this.btnClosed.UseVisualStyleBackColor = true;
            this.btnClosed.Click += new System.EventHandler(this.btnClosed_Click);
            // 
            // btnRow2
            // 
            this.btnRow2.Location = new System.Drawing.Point(268, 52);
            this.btnRow2.Name = "btnRow2";
            this.btnRow2.Size = new System.Drawing.Size(25, 21);
            this.btnRow2.TabIndex = 2;
            this.btnRow2.Text = "->";
            this.btnRow2.UseVisualStyleBackColor = true;
            this.btnRow2.Click += new System.EventHandler(this.btnRow2_Click);
            // 
            // btnRow1
            // 
            this.btnRow1.Location = new System.Drawing.Point(268, 25);
            this.btnRow1.Name = "btnRow1";
            this.btnRow1.Size = new System.Drawing.Size(25, 21);
            this.btnRow1.TabIndex = 2;
            this.btnRow1.Text = "->";
            this.btnRow1.UseVisualStyleBackColor = true;
            this.btnRow1.Click += new System.EventHandler(this.btnRow1_Click);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(6, 109);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(118, 13);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "Просроченная задача";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Завершенная задача";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Строка 2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Строка 1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Шрифт";
            // 
            // btnFont
            // 
            this.btnFont.Location = new System.Drawing.Point(286, 165);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(25, 21);
            this.btnFont.TabIndex = 2;
            this.btnFont.Text = "->";
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // lblExpiredColor
            // 
            this.lblExpiredColor.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblExpiredColor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblExpiredColor.Location = new System.Drawing.Point(130, 105);
            this.lblExpiredColor.Name = "lblExpiredColor";
            this.lblExpiredColor.Size = new System.Drawing.Size(132, 21);
            this.lblExpiredColor.TabIndex = 4;
            // 
            // lblClosedColor
            // 
            this.lblClosedColor.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblClosedColor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblClosedColor.Location = new System.Drawing.Point(130, 79);
            this.lblClosedColor.Name = "lblClosedColor";
            this.lblClosedColor.Size = new System.Drawing.Size(132, 21);
            this.lblClosedColor.TabIndex = 5;
            // 
            // lblRow2Color
            // 
            this.lblRow2Color.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblRow2Color.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblRow2Color.Location = new System.Drawing.Point(130, 52);
            this.lblRow2Color.Name = "lblRow2Color";
            this.lblRow2Color.Size = new System.Drawing.Size(132, 21);
            this.lblRow2Color.TabIndex = 6;
            this.lblRow2Color.Click += new System.EventHandler(this.label8_Click);
            // 
            // lblRow1Color
            // 
            this.lblRow1Color.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblRow1Color.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblRow1Color.Location = new System.Drawing.Point(130, 25);
            this.lblRow1Color.Name = "lblRow1Color";
            this.lblRow1Color.Size = new System.Drawing.Size(132, 21);
            this.lblRow1Color.TabIndex = 7;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(298, 202);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "Применить";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(379, 202);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(461, 202);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblFont
            // 
            this.lblFont.Location = new System.Drawing.Point(71, 169);
            this.lblFont.Name = "lblFont";
            this.lblFont.Size = new System.Drawing.Size(209, 26);
            this.lblFont.TabIndex = 7;
            this.lblFont.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblFont.Click += new System.EventHandler(this.lblFont_Click);
            // 
            // btnToDefault
            // 
            this.btnToDefault.Location = new System.Drawing.Point(12, 202);
            this.btnToDefault.Name = "btnToDefault";
            this.btnToDefault.Size = new System.Drawing.Size(75, 23);
            this.btnToDefault.TabIndex = 6;
            this.btnToDefault.Text = "Сбросить";
            this.btnToDefault.UseVisualStyleBackColor = true;
            this.btnToDefault.Click += new System.EventHandler(this.btnToDefault_Click);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 237);
            this.Controls.Add(this.lblFont);
            this.Controls.Add(this.btnToDefault);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnFont);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.Name = "frmSettings";
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listExample;
        private System.Windows.Forms.Button btnExpired;
        private System.Windows.Forms.Button btnClosed;
        private System.Windows.Forms.Button btnRow2;
        private System.Windows.Forms.Button btnRow1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label lblRow2Color;
        private System.Windows.Forms.Label lblClosedColor;
        private System.Windows.Forms.Label lblExpiredColor;
        private System.Windows.Forms.Label lblRow1Color;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.Label lblFont;
        private System.Windows.Forms.Button btnToDefault;
    }
}