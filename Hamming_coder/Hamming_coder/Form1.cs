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

namespace Hamming_coder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        struct Binary_Alph
        {
            public List<SByte> Bin;
            public string Dex;
        };

        List<Binary_Alph> Alph = new List<Binary_Alph>
        {
            new Binary_Alph {Bin = new  List<SByte> { 0,0,0,0,0},Dex = "0" },
              new Binary_Alph {Bin = new  List<SByte> { 0,0,0,0,1},Dex = "1" },
              new Binary_Alph {Bin = new  List<SByte> { 0,0,0,1,0},Dex = "2" },
              new Binary_Alph {Bin = new  List<SByte> { 0,0,0,1,1},Dex = "3" },
              new Binary_Alph {Bin = new  List<SByte> { 0,0,1,0,0},Dex = "4" },
              new Binary_Alph {Bin = new  List<SByte> { 0,0,1,0,1},Dex = "5" },
              new Binary_Alph {Bin = new  List<SByte> { 0,0,1,1,0},Dex = "6" },
              new Binary_Alph {Bin = new  List<SByte> { 0,0,1,1,1},Dex = "7" },
              new Binary_Alph {Bin = new  List<SByte> { 0,1,0,0,0},Dex = "8" },
              new Binary_Alph {Bin = new  List<SByte> { 0,1,0,0,1},Dex = "9" },
              new Binary_Alph {Bin = new  List<SByte> { 0,1,0,1,0},Dex = "10" },
              new Binary_Alph {Bin = new  List<SByte> { 0,1,0,1,1},Dex = "11" },
              new Binary_Alph {Bin = new  List<SByte> { 0,1,1,0,0},Dex = "12" },
              new Binary_Alph {Bin = new  List<SByte> { 0,1,1,0,1},Dex = "13" },
              new Binary_Alph {Bin = new  List<SByte> { 0,1,1,1,0},Dex = "14" },
              new Binary_Alph {Bin = new  List<SByte> { 0,1,1,1,1},Dex = "15" },
              new Binary_Alph {Bin = new  List<SByte> { 1,0,0,0,0},Dex = "16" },
              new Binary_Alph {Bin = new  List<SByte> {1,0,0,0,1},Dex = "17" },
              new Binary_Alph {Bin = new  List<SByte> { 1,0,0,1,0},Dex = "18" },
              new Binary_Alph {Bin = new  List<SByte> { 1,0,0,1,1},Dex = "19" },
              new Binary_Alph {Bin = new  List<SByte> { 1,0,1,0,0},Dex = "20" },
              new Binary_Alph {Bin = new  List<SByte> { 1,0,1,0,1},Dex = "21" },
              new Binary_Alph {Bin = new  List<SByte> { 1,0,1,1,0},Dex = "22" },
              new Binary_Alph {Bin = new  List<SByte> { 1,0,1,1,1},Dex = "23" },
              new Binary_Alph {Bin = new  List<SByte> { 1,1,0,0,0},Dex = "24" },
              new Binary_Alph {Bin = new  List<SByte> { 1,1,0,0,1},Dex = "25" },
              new Binary_Alph {Bin = new  List<SByte> { 1,1,0,1,0},Dex = "26" },
              new Binary_Alph {Bin = new  List<SByte> { 1,1,0,1,1},Dex = "27" },
              new Binary_Alph {Bin = new  List<SByte> { 1,1,1,0,0},Dex = "28" },
              new Binary_Alph {Bin = new  List<SByte> { 1,1,1,0,1},Dex = "29" },
              new Binary_Alph {Bin = new  List<SByte> { 1,1,1,1,0},Dex = "30" },
              new Binary_Alph {Bin = new  List<SByte> { 1,1,1,1,1},Dex = "31" },

        };
        String Messege = String.Empty;
        List<List<SByte>> binary_messeges = new List<List<SByte>>();
        List<List<SByte>> coded_messeges = new List<List<SByte>>();
        List<List<SByte>> H = new List<List<SByte>>
          {
             new List<SByte> {0,0,0,0,1,1,0,0,0,},
             new List<SByte> {0,1,1,1,1,0,1,0,0,},
             new List<SByte> {1,0,1,1,1,0,0,1,0 },
             new List<SByte>  {1,1,0,1,0,0,0,0,1 }
          };

        List<List<SByte>> G = new List<List<SByte>>
        {
           new List<SByte> {1,0,0,0,0,0,0,1,1},
           new List<SByte> {0,1,0,0,0,0,1,0,1},
           new List<SByte> {0,0,1,0,0,0,1,1,0},
           new List<SByte> {0,0,0,1,0,0,1,1,1},
           new List<SByte> {0,0,0,0,1,1,1,1,0}
        };




        private void button1_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader sr = new
                StreamReader(openFileDialog1.FileName);
                textBox_mess.Text = sr.ReadToEnd();

                if (textBox_mess.Text == "")
                {
                    MessageBox.Show("Файл пуст");
                    textBox_mess.Text = "Выберите файл с сообщением";
                }
                sr.Close();
            }
        }

        private void textBox_mess_TextChanged(object sender, EventArgs e)
        {

        }
        List<SByte> multiplicity(List<List<SByte>> M, List<SByte> V)
        {
            List<SByte> result = new List<SByte>();
            SByte sum = 0;
            for (int j = 0; j < 9; j++)
            {
                for (int i = 0; i < 5; i++)
                    sum ^= (SByte)(V[i] * M[i][j]);
                result.Add(sum);
                sum = 0;
            }
            return result;

        }
        private void button_coding_Click(object sender, EventArgs e)
        {
            String temp = String.Empty;

            if (textBox_mess.Text == "Введите сообщение")
            {
                MessageBox.Show("Сообщение не введено");
                return;
            }
            #region Проверка символов
            if (textBox_mess.Text[textBox_mess.Text.Length - 1] == ' ')
            {
                textBox_mess.Text.Remove(textBox_mess.Text.Length - 1, 1);


            }
            for (int i = 0; i < textBox_mess.Text.Length; i++)
            {

                if (textBox_mess.Text[i] == ' ')
                {
                    if (Convert.ToInt32(temp) >= 0 && Convert.ToInt32(temp) < 32)
                    {
                        binary_messeges.Add(Alph[Convert.ToInt32(temp)].Bin);
                        temp = System.String.Empty;

                    }
                    else
                    {
                        MessageBox.Show("Введены посторонние символы");
                        break;
                    }
                }
                else temp += textBox_mess.Text[i];

                if (i == textBox_mess.Text.Length - 1)
                {

                    if (Convert.ToInt32(temp) >= 0 && Convert.ToInt32(temp) < 32)
                    {
                        binary_messeges.Add(Alph[Convert.ToInt32(temp)].Bin);
                        temp = System.String.Empty;

                    }
                    else
                    {
                        MessageBox.Show("Введены посторонние символы");
                        break;
                    }
                }
            }
            #endregion

            coded_messeges.Clear();
            for (int i = 0; i < binary_messeges.Count; i++)
                coded_messeges.Add(multiplicity(G, binary_messeges[i]));


            textBox_codedmess.Text = String.Empty;
            for (int i = 0; i < coded_messeges.Count; i++)
                for (int j = 0; j < coded_messeges[i].Count; j++)
                    textBox_codedmess.Text += coded_messeges[i][j];

        }

        private void сохранитьСообщениеВФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox_codedmess.Text != "")
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    File.WriteAllText(saveFileDialog1.FileName, textBox_codedmess.Text);
        }
    }
}
