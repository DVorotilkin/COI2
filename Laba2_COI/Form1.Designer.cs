namespace Laba1_COI
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьИзображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фильтрацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьАддитивныйШумToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьАддитивныйШумToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьШумToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.сглаживанияСоВзвешиваниемОтсчетовПоОбратномуГрадиентуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сглаживаниеМетодомКближайшихСоседейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сглаживанияПоНаиболееОднороднойОкрестностиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.эффективностьМетодаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.посмотретьИсходноеИзображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.DownConsole = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.фильтрацияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1028, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьИзображениеToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // загрузитьИзображениеToolStripMenuItem
            // 
            this.загрузитьИзображениеToolStripMenuItem.Name = "загрузитьИзображениеToolStripMenuItem";
            this.загрузитьИзображениеToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.загрузитьИзображениеToolStripMenuItem.Text = "Загрузить изображение";
            this.загрузитьИзображениеToolStripMenuItem.Click += new System.EventHandler(this.загрузитьИзображениеToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // фильтрацияToolStripMenuItem
            // 
            this.фильтрацияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьАддитивныйШумToolStripMenuItem,
            this.toolStripSeparator1,
            this.сглаживанияСоВзвешиваниемОтсчетовПоОбратномуГрадиентуToolStripMenuItem,
            this.сглаживаниеМетодомКближайшихСоседейToolStripMenuItem,
            this.сглаживанияПоНаиболееОднороднойОкрестностиToolStripMenuItem,
            this.toolStripSeparator2,
            this.эффективностьМетодаToolStripMenuItem,
            this.посмотретьИсходноеИзображениеToolStripMenuItem});
            this.фильтрацияToolStripMenuItem.Enabled = false;
            this.фильтрацияToolStripMenuItem.Name = "фильтрацияToolStripMenuItem";
            this.фильтрацияToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.фильтрацияToolStripMenuItem.Text = "Фильтрация";
            // 
            // добавитьАддитивныйШумToolStripMenuItem
            // 
            this.добавитьАддитивныйШумToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьАддитивныйШумToolStripMenuItem1,
            this.удалитьШумToolStripMenuItem});
            this.добавитьАддитивныйШумToolStripMenuItem.Name = "добавитьАддитивныйШумToolStripMenuItem";
            this.добавитьАддитивныйШумToolStripMenuItem.Size = new System.Drawing.Size(440, 22);
            this.добавитьАддитивныйШумToolStripMenuItem.Text = "Шум";
            // 
            // добавитьАддитивныйШумToolStripMenuItem1
            // 
            this.добавитьАддитивныйШумToolStripMenuItem1.Name = "добавитьАддитивныйШумToolStripMenuItem1";
            this.добавитьАддитивныйШумToolStripMenuItem1.Size = new System.Drawing.Size(155, 22);
            this.добавитьАддитивныйШумToolStripMenuItem1.Text = "Добавить шум";
            this.добавитьАддитивныйШумToolStripMenuItem1.Click += new System.EventHandler(this.добавитьАддитивныйШумToolStripMenuItem1_Click);
            // 
            // удалитьШумToolStripMenuItem
            // 
            this.удалитьШумToolStripMenuItem.Enabled = false;
            this.удалитьШумToolStripMenuItem.Name = "удалитьШумToolStripMenuItem";
            this.удалитьШумToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.удалитьШумToolStripMenuItem.Text = "Удалить шум";
            this.удалитьШумToolStripMenuItem.Click += new System.EventHandler(this.удалитьШумToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(437, 6);
            // 
            // сглаживанияСоВзвешиваниемОтсчетовПоОбратномуГрадиентуToolStripMenuItem
            // 
            this.сглаживанияСоВзвешиваниемОтсчетовПоОбратномуГрадиентуToolStripMenuItem.Name = "сглаживанияСоВзвешиваниемОтсчетовПоОбратномуГрадиентуToolStripMenuItem";
            this.сглаживанияСоВзвешиваниемОтсчетовПоОбратномуГрадиентуToolStripMenuItem.Size = new System.Drawing.Size(440, 22);
            this.сглаживанияСоВзвешиваниемОтсчетовПоОбратномуГрадиентуToolStripMenuItem.Text = "Сглаживания со взвешиванием отсчетов по обратному градиенту";
            this.сглаживанияСоВзвешиваниемОтсчетовПоОбратномуГрадиентуToolStripMenuItem.Click += new System.EventHandler(this.сглаживанияСоВзвешиваниемОтсчетовПоОбратномуГрадиентуToolStripMenuItem_Click);
            // 
            // сглаживаниеМетодомКближайшихСоседейToolStripMenuItem
            // 
            this.сглаживаниеМетодомКближайшихСоседейToolStripMenuItem.Name = "сглаживаниеМетодомКближайшихСоседейToolStripMenuItem";
            this.сглаживаниеМетодомКближайшихСоседейToolStripMenuItem.Size = new System.Drawing.Size(440, 22);
            this.сглаживаниеМетодомКближайшихСоседейToolStripMenuItem.Text = "Сглаживание методом К-ближайших соседей";
            this.сглаживаниеМетодомКближайшихСоседейToolStripMenuItem.Click += new System.EventHandler(this.сглаживаниеМетодомКближайшихСоседейToolStripMenuItem_Click);
            // 
            // сглаживанияПоНаиболееОднороднойОкрестностиToolStripMenuItem
            // 
            this.сглаживанияПоНаиболееОднороднойОкрестностиToolStripMenuItem.Name = "сглаживанияПоНаиболееОднороднойОкрестностиToolStripMenuItem";
            this.сглаживанияПоНаиболееОднороднойОкрестностиToolStripMenuItem.Size = new System.Drawing.Size(440, 22);
            this.сглаживанияПоНаиболееОднороднойОкрестностиToolStripMenuItem.Text = "Сглаживания по наиболее однородной окрестности";
            this.сглаживанияПоНаиболееОднороднойОкрестностиToolStripMenuItem.Click += new System.EventHandler(this.сглаживанияПоНаиболееОднороднойОкрестностиToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(437, 6);
            // 
            // эффективностьМетодаToolStripMenuItem
            // 
            this.эффективностьМетодаToolStripMenuItem.Enabled = false;
            this.эффективностьМетодаToolStripMenuItem.Name = "эффективностьМетодаToolStripMenuItem";
            this.эффективностьМетодаToolStripMenuItem.Size = new System.Drawing.Size(440, 22);
            this.эффективностьМетодаToolStripMenuItem.Text = "Эффективность метода";
            this.эффективностьМетодаToolStripMenuItem.Click += new System.EventHandler(this.эффективностьМетодаToolStripMenuItem_Click);
            // 
            // посмотретьИсходноеИзображениеToolStripMenuItem
            // 
            this.посмотретьИсходноеИзображениеToolStripMenuItem.Enabled = false;
            this.посмотретьИсходноеИзображениеToolStripMenuItem.Name = "посмотретьИсходноеИзображениеToolStripMenuItem";
            this.посмотретьИсходноеИзображениеToolStripMenuItem.Size = new System.Drawing.Size(440, 22);
            this.посмотретьИсходноеИзображениеToolStripMenuItem.Text = "Посмотреть исходное изображение";
            this.посмотретьИсходноеИзображениеToolStripMenuItem.Click += new System.EventHandler(this.посмотретьИсходноеИзображениеToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "JPEG-файлы|*.jpg|PNG-файлы|*.png";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(9, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 500);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pictureBox2.Location = new System.Drawing.Point(526, 27);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(500, 500);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // DownConsole
            // 
            this.DownConsole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DownConsole.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.DownConsole.ForeColor = System.Drawing.SystemColors.InfoText;
            this.DownConsole.Location = new System.Drawing.Point(0, 559);
            this.DownConsole.Name = "DownConsole";
            this.DownConsole.ReadOnly = true;
            this.DownConsole.Size = new System.Drawing.Size(1032, 20);
            this.DownConsole.TabIndex = 3;
            this.DownConsole.TabStop = false;
            this.DownConsole.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 538);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1028, 579);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DownConsole);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Цифровая обработка изображений";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьИзображениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox DownConsole;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem фильтрацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьАддитивныйШумToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьАддитивныйШумToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem удалитьШумToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сглаживанияСоВзвешиваниемОтсчетовПоОбратномуГрадиентуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сглаживаниеМетодомКближайшихСоседейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сглаживанияПоНаиболееОднороднойОкрестностиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem посмотретьИсходноеИзображениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem эффективностьМетодаToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

