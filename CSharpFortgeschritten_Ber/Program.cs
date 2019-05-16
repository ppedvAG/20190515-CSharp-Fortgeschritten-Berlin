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
            
            MyList<int> myList = new MyList<int>();

            myList.Add(22);
            myList.Add(33);
            myList.Add(11);

            myList.Remove(33);

            MyDict<int, string> myDict = new MyDict<int, string>();
            myDict.Add(5, "Fünf");
            myDict.Add(3, "Drei");
            myDict.Add(1, "Eins");

            myDict.Remove(3);
            Console.WriteLine(  myDict.Keys[0]);

            foreach (var item in myDict)
            {
                Console.WriteLine(item.key);
                Console.WriteLine(item.value);

            }


            Console.WriteLine(myList);
            Console.ReadKey();
        }
    }
}
