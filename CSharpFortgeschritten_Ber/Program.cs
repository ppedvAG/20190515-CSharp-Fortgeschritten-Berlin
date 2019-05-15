using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFortgeschritten_Ber
{
    class Program
    {
        static void Main(string[] args)
        {
            // Array
            int[] numberArray = new int[10];
            int[] numberArray2 = { 10, 5 };
            numberArray[0] = 5;

            // ArrayList
            ArrayList numberArrayList = new ArrayList();
            numberArrayList.Add(10);
            numberArrayList.Add(5);
            numberArrayList.Add(99);
            numberArrayList.Add(1);
            numberArrayList.Add("KeineZahl");
            Random ran = new Random();
            numberArrayList.Add(ran);
            object obj = new object();
            numberArrayList.Add(obj);

            for (int i = 0; i < numberArrayList.Count; i++)
            {
                if(numberArrayList[i] is int zahl1)
                {
                    int zahl2 = zahl1;
                }
            }

            // List
            List<int> numberList = new List<int>();
            numberList.Add(5);
            numberList.Add(3);

            
            foreach (var item in numberList)
            {
                int zahl2 = item;
            }

        }
    }
}
