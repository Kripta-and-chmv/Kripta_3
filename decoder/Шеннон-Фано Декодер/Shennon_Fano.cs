using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Шеннон_Фано_Декодер
{
    struct DATA
    {
        public float P;
        public String alph;
    }
    class Shennon_Fano
    {
        List<DATA> d = new List<DATA>();
        List<String> Code = new List<String>();

        #region Сортировка
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

            for (int i = 0; i < alphabet.Count; i++)
            {
                temp.P = Probability[i];
                temp.alph = alphabet[i];
                Code.Add(String.Empty);
                d.Add(temp);
            }
            QuickSort(d, 0, d.Count - 1);
            calculate(0, d.Count - 1);

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

        public String Decoding(String coding_messege)//Декодирование
        {
            String temp = string.Empty;
            int count = 0, j = 0, wordNumber = coding_messege.Length/4 ;
            String result = string.Empty;
            bool flag = false;
            for (int i = 0; i <wordNumber; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    temp += coding_messege[count++];
                }
                for (j = 0; j < Code.Count; j++)
                {
                    if (temp == Code[j])
                    {
                        result+=d[j].alph+" ";
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                    result+="* ";
                temp = string.Empty;
            }
            return result;
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
