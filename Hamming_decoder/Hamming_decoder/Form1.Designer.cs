namespace Hamming_decoder
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
            this.textBox_codedmes = new System.Windows.Forms.TextBox();
            this.textBox_decodedmess = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Decod_button = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.сохранитьСообщениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_error = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_codedmes
            // 
            this.textBox_codedmes.Location = new System.Drawing.Point(12, 63);
            this.textBox_codedmes.Name = "textBox_codedmes";
            this.textBox_codedmes.Size = new System.Drawing.Size(283, 20);
            this.textBox_codedmes.TabIndex = 0;
            this.textBox_codedmes.Text = "Введите закодированное сообщение";
            // 
            // textBox_decodedmess
            // 
            this.textBox_decodedmess.Location = new System.Drawing.Point(12, 115);
            this.textBox_decodedmess.Name = "textBox_decodedmess";
            this.textBox_decodedmess.ReadOnly = true;
            this.textBox_decodedmess.Size = new System.Drawing.Size(283, 20);
            this.textBox_decodedmess.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(320, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Обзор";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Decod_button
            // 
            this.Decod_button.Location = new System.Drawing.Point(37, 159);
            this.Decod_button.Name = "Decod_button";
            this.Decod_button.Size = new System.Drawing.Size(246, 46);
            this.Decod_button.TabIndex = 3;
            this.Decod_button.Text = "Декодировать сообщение";
            this.Decod_button.UseVisualStyleBackColor = true;
            this.Decod_button.Click += new System.EventHandler(this.Decod_button_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьСообщениеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(501, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // сохранитьСообщениеToolStripMenuItem
            // 
            this.сохранитьСообщениеToolStripMenuItem.Name = "сохранитьСообщениеToolStripMenuItem";
            this.сохранитьСообщениеToolStripMenuItem.Size = new System.Drawing.Size(144, 20);
            this.сохранитьСообщениеToolStripMenuItem.Text = "Сохранить сообщение";
            this.сохранитьСообщениеToolStripMenuItem.Click += new System.EventHandler(this.сохранитьСообщениеToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Закодированное сообщение";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Декодированное сообщение";
            // 
            // label_error
            // 
            this.label_error.AutoSize = true;
            this.label_error.Location = new System.Drawing.Point(12, 232);
            this.label_error.Name = "label_error";
            this.label_error.Size = new System.Drawing.Size(0, 13);
            this.label_error.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 331);
            this.Controls.Add(this.label_error);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Decod_button);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_decodedmess);
            this.Controls.Add(this.textBox_codedmes);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_codedmes;
        private System.Windows.Forms.TextBox textBox_decodedmess;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Decod_button;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem сохранитьСообщениеToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_error;
    }
}

