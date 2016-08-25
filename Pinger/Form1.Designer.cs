namespace Pinger
{
    partial class frmMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ipAddressControl1 = new IPAddressControlLib.IPAddressControl();
            this.gridAdresses = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAdress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новыйСписокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.columnIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnNamePC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnAdress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnIPAdres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnIndicator = new System.Windows.Forms.DataGridViewImageColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.timerRLabel = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridAdresses)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ipAddressControl1
            // 
            this.ipAddressControl1.AllowInternalTab = false;
            this.ipAddressControl1.AutoHeight = true;
            this.ipAddressControl1.BackColor = System.Drawing.SystemColors.Window;
            this.ipAddressControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ipAddressControl1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ipAddressControl1.Location = new System.Drawing.Point(320, 19);
            this.ipAddressControl1.MinimumSize = new System.Drawing.Size(87, 20);
            this.ipAddressControl1.Name = "ipAddressControl1";
            this.ipAddressControl1.ReadOnly = false;
            this.ipAddressControl1.Size = new System.Drawing.Size(101, 20);
            this.ipAddressControl1.TabIndex = 0;
            this.ipAddressControl1.Text = "0.0.0.0";
            // 
            // gridAdresses
            // 
            this.gridAdresses.AllowUserToAddRows = false;
            this.gridAdresses.AllowUserToDeleteRows = false;
            this.gridAdresses.AllowUserToResizeColumns = false;
            this.gridAdresses.AllowUserToResizeRows = false;
            this.gridAdresses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnIndex,
            this.columnNamePC,
            this.columnAdress,
            this.columnIPAdres,
            this.columnIndicator});
            this.gridAdresses.Location = new System.Drawing.Point(12, 63);
            this.gridAdresses.Name = "gridAdresses";
            this.gridAdresses.RowHeadersVisible = false;
            this.gridAdresses.Size = new System.Drawing.Size(508, 388);
            this.gridAdresses.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Поиск";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSearch.Location = new System.Drawing.Point(54, 30);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(466, 20);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.Text = "Введите наименование ресурса или его IP адрес";
            this.txtSearch.Click += new System.EventHandler(this.txtSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtAdress);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ipAddressControl1);
            this.groupBox1.Location = new System.Drawing.Point(12, 457);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(508, 74);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавить";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(427, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 49);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "IP адрес";
            // 
            // txtAdress
            // 
            this.txtAdress.Location = new System.Drawing.Point(93, 48);
            this.txtAdress.Name = "txtAdress";
            this.txtAdress.Size = new System.Drawing.Size(328, 20);
            this.txtAdress.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Адрес";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(93, 19);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(153, 20);
            this.txtName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Наименование";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(531, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйСписокToolStripMenuItem,
            this.открытьToolStripMenuItem1,
            this.сохранитьToolStripMenuItem,
            this.toolStripMenuItem2,
            this.выходToolStripMenuItem});
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.открытьToolStripMenuItem.Text = "Файл";
            // 
            // новыйСписокToolStripMenuItem
            // 
            this.новыйСписокToolStripMenuItem.Name = "новыйСписокToolStripMenuItem";
            this.новыйСписокToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.новыйСписокToolStripMenuItem.Text = "Новый";
            this.новыйСписокToolStripMenuItem.Click += new System.EventHandler(this.новыйСписокToolStripMenuItem_Click);
            // 
            // открытьToolStripMenuItem1
            // 
            this.открытьToolStripMenuItem1.Name = "открытьToolStripMenuItem1";
            this.открытьToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.открытьToolStripMenuItem1.Text = "Открыть...";
            this.открытьToolStripMenuItem1.Click += new System.EventHandler(this.открытьToolStripMenuItem1_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить...";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // timerRefresh
            // 
            this.timerRefresh.Enabled = true;
            this.timerRefresh.Interval = 60000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "json";
            this.saveFileDialog.Filter = "json|*.json";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "json";
            this.openFileDialog.Filter = "json|*.json";
            // 
            // columnIndex
            // 
            this.columnIndex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.columnIndex.FillWeight = 50F;
            this.columnIndex.Frozen = true;
            this.columnIndex.HeaderText = "№ п/п";
            this.columnIndex.Name = "columnIndex";
            this.columnIndex.ReadOnly = true;
            this.columnIndex.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnIndex.Width = 63;
            // 
            // columnNamePC
            // 
            this.columnNamePC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.columnNamePC.Frozen = true;
            this.columnNamePC.HeaderText = "Наименование";
            this.columnNamePC.Name = "columnNamePC";
            this.columnNamePC.ReadOnly = true;
            this.columnNamePC.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnNamePC.Width = 112;
            // 
            // columnAdress
            // 
            this.columnAdress.Frozen = true;
            this.columnAdress.HeaderText = "Адрес";
            this.columnAdress.Name = "columnAdress";
            this.columnAdress.ReadOnly = true;
            this.columnAdress.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnAdress.Width = 200;
            // 
            // columnIPAdres
            // 
            this.columnIPAdres.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.columnIPAdres.Frozen = true;
            this.columnIPAdres.HeaderText = "IP адрес";
            this.columnIPAdres.Name = "columnIPAdres";
            this.columnIPAdres.ReadOnly = true;
            this.columnIPAdres.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnIPAdres.Width = 80;
            // 
            // columnIndicator
            // 
            this.columnIndicator.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.columnIndicator.Frozen = true;
            this.columnIndicator.HeaderText = "Статус";
            this.columnIndicator.Name = "columnIndicator";
            this.columnIndicator.ReadOnly = true;
            this.columnIndicator.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnIndicator.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.columnIndicator.Width = 50;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 537);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(531, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(45, 17);
            this.toolStripStatusLabel.Text = "Готово";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar.Visible = false;
            // 
            // timerRLabel
            // 
            this.timerRLabel.Interval = 1000;
            this.timerRLabel.Tick += new System.EventHandler(this.timerRLabel_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 559);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridAdresses);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Пингоштука 2016";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridAdresses)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IPAddressControlLib.IPAddressControl ipAddressControl1;
        private System.Windows.Forms.DataGridView gridAdresses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.TextBox txtAdress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem новыйСписокToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnNamePC;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnAdress;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnIPAdres;
        private System.Windows.Forms.DataGridViewImageColumn columnIndicator;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.Timer timerRLabel;
    }
}

