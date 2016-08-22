namespace TODOList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridTaskList = new System.Windows.Forms.DataGridView();
            this.columnNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTask = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDeadline = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnClose = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.удалитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.завершитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.печатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.правкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.параметрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtTask = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateDeadline = new System.Windows.Forms.DateTimePicker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.gridTaskList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridTaskList
            // 
            this.gridTaskList.AllowUserToAddRows = false;
            this.gridTaskList.AllowUserToDeleteRows = false;
            this.gridTaskList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridTaskList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnNum,
            this.columnTask,
            this.columnDeadline,
            this.columnClose});
            this.gridTaskList.ContextMenuStrip = this.contextMenuStrip1;
            this.gridTaskList.Location = new System.Drawing.Point(12, 54);
            this.gridTaskList.Name = "gridTaskList";
            this.gridTaskList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTaskList.Size = new System.Drawing.Size(563, 408);
            this.gridTaskList.TabIndex = 0;
            this.gridTaskList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTaskList_CellClick);
            this.gridTaskList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTaskList_CellClick);
            this.gridTaskList.CurrentCellDirtyStateChanged += new System.EventHandler(this.gridTaskList_CurrentCellDirtyStateChanged);
            this.gridTaskList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridTaskList_KeyPress);
            // 
            // columnNum
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.NullValue = "false";
            this.columnNum.DefaultCellStyle = dataGridViewCellStyle1;
            this.columnNum.HeaderText = "Номер";
            this.columnNum.Name = "columnNum";
            this.columnNum.ReadOnly = true;
            this.columnNum.Width = 50;
            // 
            // columnTask
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.columnTask.DefaultCellStyle = dataGridViewCellStyle2;
            this.columnTask.HeaderText = "Задача";
            this.columnTask.Name = "columnTask";
            this.columnTask.ReadOnly = true;
            this.columnTask.Width = 300;
            // 
            // columnDeadline
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.columnDeadline.DefaultCellStyle = dataGridViewCellStyle3;
            this.columnDeadline.HeaderText = "Дэдлайн";
            this.columnDeadline.Name = "columnDeadline";
            this.columnDeadline.ReadOnly = true;
            // 
            // columnClose
            // 
            this.columnClose.FalseValue = "0";
            this.columnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.columnClose.HeaderText = "Завершено";
            this.columnClose.Name = "columnClose";
            this.columnClose.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnClose.TrueValue = "1";
            this.columnClose.Width = 70;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.удалитьToolStripMenuItem1,
            this.очиститьToolStripMenuItem1,
            this.завершитьToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(136, 70);
            // 
            // удалитьToolStripMenuItem1
            // 
            this.удалитьToolStripMenuItem1.Name = "удалитьToolStripMenuItem1";
            this.удалитьToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.удалитьToolStripMenuItem1.Text = "Удалить";
            this.удалитьToolStripMenuItem1.Click += new System.EventHandler(this.удалитьToolStripMenuItem1_Click);
            // 
            // очиститьToolStripMenuItem1
            // 
            this.очиститьToolStripMenuItem1.Name = "очиститьToolStripMenuItem1";
            this.очиститьToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.очиститьToolStripMenuItem1.Text = "Очистить";
            this.очиститьToolStripMenuItem1.Click += new System.EventHandler(this.очиститьToolStripMenuItem1_Click);
            // 
            // завершитьToolStripMenuItem
            // 
            this.завершитьToolStripMenuItem.Name = "завершитьToolStripMenuItem";
            this.завершитьToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.завершитьToolStripMenuItem.Text = "Завершить";
            this.завершитьToolStripMenuItem.Click += new System.EventHandler(this.завершитьToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.правкаToolStripMenuItem,
            this.параметрыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(587, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.печатьToolStripMenuItem,
            this.toolStripMenuItem1,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.открытьToolStripMenuItem.Text = "Открыть...";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить...";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // печатьToolStripMenuItem
            // 
            this.печатьToolStripMenuItem.Name = "печатьToolStripMenuItem";
            this.печатьToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.печатьToolStripMenuItem.Text = "Печать...";
            this.печатьToolStripMenuItem.Click += new System.EventHandler(this.печатьToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(138, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // правкаToolStripMenuItem
            // 
            this.правкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.очиститьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
            this.правкаToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.правкаToolStripMenuItem.Text = "Правка";
            // 
            // очиститьToolStripMenuItem
            // 
            this.очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
            this.очиститьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.очиститьToolStripMenuItem.Text = "Очистить";
            this.очиститьToolStripMenuItem.Click += new System.EventHandler(this.очиститьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // параметрыToolStripMenuItem
            // 
            this.параметрыToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.параметрыToolStripMenuItem.Image = global::TODOList.Properties.Resources.шестеренка64;
            this.параметрыToolStripMenuItem.Name = "параметрыToolStripMenuItem";
            this.параметрыToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.параметрыToolStripMenuItem.Text = " ";
            this.параметрыToolStripMenuItem.Click += new System.EventHandler(this.параметрыToolStripMenuItem_Click);
            // 
            // txtTask
            // 
            this.txtTask.Location = new System.Drawing.Point(61, 27);
            this.txtTask.Name = "txtTask";
            this.txtTask.Size = new System.Drawing.Size(272, 20);
            this.txtTask.TabIndex = 2;
            this.txtTask.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTask_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Задача:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(339, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Дэдлайн:";
            // 
            // dateDeadline
            // 
            this.dateDeadline.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDeadline.Location = new System.Drawing.Point(400, 27);
            this.dateDeadline.Name = "dateDeadline";
            this.dateDeadline.Size = new System.Drawing.Size(94, 20);
            this.dateDeadline.TabIndex = 5;
            this.dateDeadline.Value = new System.DateTime(2016, 8, 11, 14, 58, 39, 0);
            this.dateDeadline.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dateDeadline_KeyPress);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(500, 27);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 20);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnAdd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnAdd_KeyPress);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "json";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "json";
            // 
            // printDialog1
            // 
            this.printDialog1.AllowSelection = true;
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 474);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dateDeadline);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTask);
            this.Controls.Add(this.gridTaskList);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Список задач";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridTaskList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridTaskList;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.TextBox txtTask;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateDeadline;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem правкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem очиститьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTask;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDeadline;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columnClose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem очиститьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem завершитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem параметрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem печатьToolStripMenuItem;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}

