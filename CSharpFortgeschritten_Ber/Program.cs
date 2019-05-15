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

            MyList myList = new MyList();

            myList.Add(22);
            myList.Add(33);
            myList.Add(11);

            myList.Remove(33);

            Console.WriteLine(myList);
            Console.ReadKey();
        }
    }
}
