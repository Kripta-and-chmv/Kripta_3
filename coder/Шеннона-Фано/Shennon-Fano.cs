using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Шеннона_Фано
{

    struct DATA
    {
        public float P;//вероятность
        public String alph; //символ алфавита,которому соответсвует вероятность P

    }

    class Shennon_Fano
    {

        List<DATA> d = new List<DATA>();
        List<String> Code = new List<String>();

        #region Быстрая сортировка
        void QuickSort(List<DATA> d, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int pivot = partition_for_sort(d, start, end);
            QuickSort(d, start, pivot - 1);
            QuickSort(d, pivot + 1, end);
        }

        int partition_for_sort(List<DATA> array, int start, int end)
        {
            int marker = start;
            for (int i = start; i <= end; i++)
            {
                if (array[i].P >= array[end].P)
                {
                    DATA temp = array[marker]; // swap
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
            return marker - 1;
        }
        #endregion
        public Shennon_Fano(List<String> alphabet, List<float> Probability)
        {

            DATA temp = new DATA();

            for (int i = 0; i < Probability.Count; i++)//ввод алфавита и вероятностей
            {
                temp.P = Probability[i];
                temp.alph = alphabet[i];
                Code.Add(String.Empty);
                d.Add(temp);
            }
            QuickSort(d, 0, d.Count - 1);//сортировка алфавита по вероятностям появления символов
            calculate(0, d.Count - 1); //вычисление кода

        }

        int partition_for_code(int L, int R) 
        {
            float sum_direct = 0, sum_backward = 0;
            for (int i = L; i < R; i++) //суммируются все элементы,кроме последнего(прямая сумма)
                sum_direct += d[i].P;

            int marker = 0;
            for (int i = R; i > L; i--)
            {
                sum_direct -= d[i].P;    //От суммы последовтельно отнимаются элементы массива и добавляются в обратную сумму
                sum_backward += d[i].P;  // и добавляются в обратную сумму
                if (sum_direct <= sum_backward) // пока прямая сумма не будет меньше,чем обратная
                {
                    marker = i;
                    break;
                }
            }
            if (marker == 0)
                return L;
            else
                return marker - 1;
        }
       
        private void calculate(int L, int R)//Вычисление кода
        {
            if (L < R)
            {
                // Вычисление индекса элемента,который делит массив вероятностей на две примерно равные части
                int middle = partition_for_code(L, R); 
                for (int i = L; i <= R; i++)
                    if (i > middle)           //Левой части этого массива присвается ноль
                        Code[i] += "0";
                    else
                        Code[i] += "1";  //Правой части - присвается единица
                calculate(L, middle);   
                calculate(middle + 1, R);
            }
            else return;
        }
        public List<String> Coding(List<String> messege) //кодирование сообщения
        {
            int count = 0;
       
            for (int j = 0; j < Code.Count; j++)
            {
                for (int k = 0; k < Code[j].Length; k++)
                {
                    if (Code[j][k] == '1')
                        count++;

                }
                if (count % 2 == 0)
                    Code[j] += "0";
                else
                    Code[j] += "1";
                count = 0;
            }
            List<String> Code_messege = new List<String>();
            for (int i = 0; i < messege.Count; i++)
                for (int j = 0; j < Code.Count; j++)
                    if (d[j].alph == messege[i])
                    {
                     
                        Code_messege.Add(Code[j]);
                    
                    }

            return Code_messege;
        }

      
   
        public List<String> getCode()
        {
            return Code;
        }
        public List<String> get_Alph()
        {
            List<String> temp = new List<String>();
            foreach (DATA i in d)

                temp.Add(i.alph);

            return temp;
        }
        
    }
}
