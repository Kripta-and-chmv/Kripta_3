namespace Hamming_coder
{
    partial class Form1
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
            this.textBox_mess = new System.Windows.Forms.TextBox();
            this.textBox_codedmess = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button_coding = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.сохранитьСообщениеВФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_mess
            // 
            this.textBox_mess.Location = new System.Drawing.Point(12, 66);
            this.textBox_mess.Name = "textBox_mess";
            this.textBox_mess.Size = new System.Drawing.Size(293, 20);
            this.textBox_mess.TabIndex = 0;
            this.textBox_mess.Text = "Введите сообщение";
            this.textBox_mess.TextChanged += new System.EventHandler(this.textBox_mess_TextChanged);
            // 
            // textBox_codedmess
            // 
            this.textBox_codedmess.Location = new System.Drawing.Point(12, 117);
            this.textBox_codedmess.Name = "textBox_codedmess";
            this.textBox_codedmess.ReadOnly = true;
            this.textBox_codedmess.Size = new System.Drawing.Size(317, 20);
            this.textBox_codedmess.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(324, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Обзор";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_coding
            // 
            this.button_coding.Location = new System.Drawing.Point(51, 170);
            this.button_coding.Name = "button_coding";
            this.button_coding.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button_coding.Size = new System.Drawing.Size(217, 64);
            this.button_coding.TabIndex = 3;
            this.button_coding.Text = "Закодировать";
            this.button_coding.UseVisualStyleBackColor = true;
            this.button_coding.Click += new System.EventHandler(this.button_coding_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Закодированное сообщение:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Сообщение:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьСообщениеВФайлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(667, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // сохранитьСообщениеВФайлToolStripMenuItem
            // 
            this.сохранитьСообщениеВФайлToolStripMenuItem.Name = "сохранитьСообщениеВФайлToolStripMenuItem";
            this.сохранитьСообщениеВФайлToolStripMenuItem.Size = new System.Drawing.Size(237, 20);
            this.сохранитьСообщениеВФайлToolStripMenuItem.Text = "Сохранить закодированное сообщение";
            this.сохранитьСообщениеВФайлToolStripMenuItem.Click += new System.EventHandler(this.сохранитьСообщениеВФайлToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 343);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_coding);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_codedmess);
            this.Controls.Add(this.textBox_mess);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Коды Хэмминга";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_mess;
        private System.Windows.Forms.TextBox textBox_codedmess;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_coding;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem сохранитьСообщениеВФайлToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

