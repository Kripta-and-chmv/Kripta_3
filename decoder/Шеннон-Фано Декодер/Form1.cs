using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Шеннон_Фано_Декодер
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          
        }
        String  Coded_Messege = System.String.Empty;
        public List<float> probability = new List<float> { 0.125f, 0.125f, 0.125f, 0.125f, 0.125f, 0.125f, 0.125f, 0.125f };
        public List<String> Alph = new List<String> { "_", "14", "5", "1", "0", "2", "8", "4" };
        bool IsProbTrue = true;
        private void button1_Click(object sender, EventArgs e)//Выбор файла с закодированным сообщением
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader sr = new
                StreamReader(openFileDialog1.FileName);
                Coding_messege.Text = sr.ReadToEnd() ;
                if (Coding_messege.Text == "")
                {
                    MessageBox.Show("Файл пуст");
                    Coding_messege.Text = "Выберите файл с сообщением";
                }

                sr.Close();

            }
        }

       

        private void Coding_messege_TextChanged(object sender, EventArgs e)
        {
            Coded_Messege = String.Empty;
            Coded_Messege += Coding_messege.Text;
        }

        bool Check_code(String code)//Проверка на символы,отличные от 0 и 1
        {
            bool temp = true;
            foreach (char i in code)
                if (i != '0' && i != '1')
                    temp = false;
            return temp;
        }
        private void button3_Click(object sender, EventArgs e)
        {
           
            if (Coding_messege.Text == "Выберите файл с сообщением")
            {
                MessageBox.Show("Не выбран файл с сообщением");
                return;
            }
         
            if(!Check_code(Coded_Messege))
            {
                MessageBox.Show("Введенны посторонние символы");
                return;
            }
        
          
            List<string> new_alph = new List<string>(Alph);

            Shennon_Fano S = new Shennon_Fano(new_alph, probability);
            List<String> Code = S.getCode(), alph = S.get_Alph();
            string messeges = S.Decoding(Coded_Messege);
            dataGridView1.Rows.Clear();
            for (int i = 0; i < Code.Count; i++)
                dataGridView1.Rows.Add(alph[i], Code[i]);
            textBox3.Text = messeges;
  

        }

    

        private void сохранитьСообщениеВФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    File.WriteAllText(saveFileDialog1.FileName, textBox3.Text);
        }
    }
}
