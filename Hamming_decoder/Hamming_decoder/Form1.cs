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


namespace Hamming_decoder
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
        List<List<SByte>> Binary_messeges = new List<List<SByte>>();
        /* List<List<SByte>> H = new List<List<SByte>>
           {
              new List<SByte> {0,0,0,0,1,1,0,0,0,},
              new List<SByte> {0,1,1,1,1,0,1,0,0,},
              new List<SByte> {1,0,1,1,1,0,0,1,0 },
              new List<SByte>  {1,1,0,1,0,0,0,0,1 }
           };*/

            List<int> errors = new List<int>();
        List<List<SByte>> HT = new List<List<SByte>>
          {
             new List<SByte> {0,0,1,1 },
            new List<SByte> {0,1,0,1 },
            new List<SByte> {0,1,1,0 },
            new List<SByte> {0,1,1,1 },
            new List<SByte> {1,1,1,0 },
            new List<SByte> {1,0,0,0 },
            new List<SByte> {0,1,0,0 },
            new List<SByte> {0,0,1,0 },
            new List<SByte> {0,0,0,1 }

          };
        List<List<SByte>> syndromes = new List<List<SByte>>();
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
        bool comapare_for_syndrom(List<SByte> syn, List<SByte> V)
        {
            for (int i = 0; i < syn.Count; i++)
                if (syn[i] != V[i])
                    return false;
            return true;
        }
        List<SByte> multiplicity(List<List<SByte>> M, List<SByte> V)
        {
            List<SByte> result = new List<SByte>();
            SByte sum = 0;
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 9; i++)
                    sum ^= (SByte)(V[i] * M[i][j]);
                result.Add(sum);
                sum = 0;
            }
            return result;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader sr = new
                StreamReader(openFileDialog1.FileName);
                textBox_codedmes.Text = sr.ReadToEnd();

                if (textBox_codedmes.Text == "")
                {
                    MessageBox.Show("Файл пуст");
                    textBox_codedmes.Text = "Выберите файл с сообщением";
                }
                sr.Close();
            }
        }

        private void сохранитьСообщениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox_decodedmess.Text != "")
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    File.WriteAllText(saveFileDialog1.FileName, textBox_decodedmess.Text);
        }

        private void Decod_button_Click(object sender, EventArgs e)
        {
            List<SByte> temp = new List<SByte>();
            Binary_messeges.Clear();

            if (textBox_codedmes.Text == "Введите закодированное сообщение")
            {
                MessageBox.Show("Сообщение не введено");
                return;
            }
            if(textBox_codedmes.TextLength %9 != 0)
            {
                MessageBox.Show("Неверное количество символов");
                return;
            }

            for (int i = 0; i < textBox_codedmes.Text.Length; i++)
            {

                temp.Add((SByte)(textBox_codedmes.Text[i] - 48));
                if ((i + 1) % 9 == 0)
                {
                    Binary_messeges.Add(temp);
                    temp = new List<SByte>();
                }
                if (textBox_codedmes.Text[i] != '1' && textBox_codedmes.Text[i] != '0')
                {
                    MessageBox.Show("Введены посторонние символы");
                    break;
                }

            }
            
            int n_error = 0;
            int count = 0;
            foreach (List<SByte> i in Binary_messeges)
            {
                
                temp = multiplicity(HT, i);
                for (int j = 0; j < temp.Count; j++)
                    if (temp[j] == 1)
                    {
                        syndromes.Add(temp);
                        for (int k = 0; k < HT.Count; k++)
                            if (comapare_for_syndrom(temp, HT[k]))
                            {
                                errors.Add(count * 9 + k+1);
                                n_error = k;
                                i[n_error] ^= 1;
                            }
                        j = temp.Count;

                    }
                count++;
            }
            bool flag = false;
            textBox_decodedmess.Text = String.Empty;
            foreach (List<SByte> i in Binary_messeges)
            {
                foreach (Binary_Alph j in Alph)
                {
                    flag = true;
                    for (int k = 0; k < 5; k++)
                        if (i[k] != j.Bin[k])
                            flag = false;
                    if (flag)
                        textBox_decodedmess.Text += j.Dex;

                }
            }
            if (errors.Count != 0)
            {
                label_error.Text = "Ошибки исправлены в битах: ";
                for (int i = 0; i < errors.Count; i++)
                    label_error.Text += errors[i] + ", ";
                
            }

        }
    }
}
