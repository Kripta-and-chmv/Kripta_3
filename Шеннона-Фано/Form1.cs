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

namespace Шеннона_Фано
{
    public partial class Form1 : Form
    {



        public List<String> messeges = new List<String>();

        public List<float> probability = new List<float> { 0.125f, 0.125f, 0.125f, 0.125f, 0.125f, 0.125f, 0.125f, 0.125f };
        public List<String> Alph = new List<String> { "_", "14", "5", "1", "0", "2", "8", "4" };
        bool IsProbTrue = true;
        public Form1()
        {
            InitializeComponent();
            foreach (String i in Alph)
                Alphabite.Text += i + '\n';

        }



        private void button1_Click(object sender, EventArgs e)//Выбор файла с сообщением
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader sr = new
                StreamReader(openFileDialog1.FileName);
                textBox1.Text = sr.ReadToEnd();

                if (textBox1.Text == "")
                {
                    MessageBox.Show("Файл пуст");
                    textBox1.Text = "Выберите файл с сообщением";
                }


                sr.Close();
            }
        }


        private bool Checking_messege(List<String> messege, List<String> Alph)//Проверка на символы,не входящие в алфавит
        {
            bool temp = false; ;
            for (int i = 0; i < messege.Count; i++)
            {
                temp = false;
                foreach (string j in Alph)
                {
                    if (j == messege[i])
                        temp = true;
                    if (!temp && j == Alph.Last())
                        return temp;
                }
            }
            return temp;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "Выберите файл с сообщением")
            {
                MessageBox.Show("Не выбран файл с сообщением");
                return;
            }

            if (probability.Sum() != 1)
            {
                MessageBox.Show("Сумма вероятностей не равна единице!");
                return;
            }

            if (!IsProbTrue)
            {
                MessageBox.Show("Задана отрицательная вероятность");
                return;
            }
            List<string> new_alph = new List<string>(Alph);

            for (int i = 0; i < probability.Count; i++)
                if (probability[i] == 0)
                {
                    new_alph.RemoveAt(i);
                    probability.RemoveAt(i);
                    i = 0;
                }

            if (!Checking_messege(messeges, new_alph))
            {
                MessageBox.Show("В сообщении есть символы,не входящие в алфавит");
                return;
            }
            Alphabite.Text = String.Empty;
            foreach (String i in new_alph)
                Alphabite.Text += i + '\n';
            Shennon_Fano S = new Shennon_Fano(Alph, probability);
            List<String> Code = S.getCode(), alph = S.get_Alph(), Coding_mess = S.Coding(messeges);

          
            /////////////////////////////////////////

            ///////////////////////////  
            dataGridView1.Rows.Clear();
            for (int i = 0; i < Code.Count; i++)
                dataGridView1.Rows.Add(alph[i], Code[i]);
            Code_messege.Text = String.Empty;
            foreach (String i in Coding_mess)
                Code_messege.Text += i;

        }



        private void сохранитьЗакодированноеСообщениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Code_messege.Text != "")
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    File.WriteAllText(saveFileDialog1.FileName, Code_messege.Text);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            String temp = System.String.Empty;
            messeges.Clear();

            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if (textBox1.Text[i] == ' ')
                {
                    if (temp != System.String.Empty)
                        messeges.Add(temp);

                    temp = System.String.Empty;
                }
                else temp = temp.Insert(temp.Length, textBox1.Text[i].ToString());
                if (i == textBox1.Text.Length - 1)
                    messeges.Add(temp);
            }
        }


    }
}
