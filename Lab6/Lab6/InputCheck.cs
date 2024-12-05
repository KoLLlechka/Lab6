using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    internal class InputCheck
    {
        //проверка перевода из str в int
        public static bool IsStringToInt(string x)
        {
            return int.TryParse(x, out var result);
        }

        public static bool IsIntOneThree(string x)
        {
            return int.Parse(x) >= 1 && int.Parse(x) <= 3;
        }




        //проверка на содержание заданного числа в листе
        public static bool IsValueInList(string[] sarr, string s)
        {
            return sarr.Contains(s);
        }

        //проверка на не пустоту словаря
        public static bool IsDictionaryNotNone(Dictionary<string, HashSet<string>> d)
        {
            return d.Count != 1;
        }

        //проверка входят ли дискотеки в перечень
        public static bool IsValueInAllDisko(string[] sarr, Dictionary<string, HashSet<string>> d)
        {
            foreach (var dis in sarr)
            {
                if (!d["All Disko:"].Contains(dis))
                    return false;
            }
            return true;
        }

        //проверка на не пустоту строки
        public static bool IsStrNotNone(string s)
        {
            return s != "";
        }

        //проверка на не пустоту листа
        public static bool IsListNotNone(string[] sarr)
        {
            return sarr[0] != "";
        }

        

        //проверка числа на положительность
        public static bool IsValueNotNegative(string x)
        {
            return int.Parse(x) >= 0;
        }

        //проверка числа на неравность нулю
        public static bool IsValueNotZero(string x)
        {
            return int.Parse(x) != 0;
        }

        //проверка числа на положительность и не равность нулю
        public static bool IsValueMoreZero(string x)
        {
            return int.Parse(x) > 0;
        }

        //проверка перевода из массива строк в числовой массив
        public static bool IsStringToIntArray(string[] arr, int kol)
        {
            if (arr.Length != kol)
                return false;
            for (int i = 0; i < arr.Length; i++)
            {
                if (!IsStringToInt(arr[i]))
                {
                    return false;
                }
            }
            return true;
        }

        //размерность матриц подходит для их складывания или сложения
        public static bool IsDimensionsCorrect(string[] a, string[] b, string[] c)
        {
            return a[0] == b[0] && a[1] == b[1] && a[0] == c[1] && a[1] == c[0];
        }

        //значения массива стринга больше ноля
        public static bool ValuesMoreZero(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (!IsValueMoreZero(arr[i]))
                    return false;
            }
            return true;
        }
    }
}
