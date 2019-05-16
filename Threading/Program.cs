using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(new ParameterizedThreadStart(MachEtwas));
            t.Start("A");
            Thread t2 = new Thread(new ParameterizedThreadStart(MachEtwas));
            t2.Start("B");
            Console.ReadKey();
        }

        private static void MachEtwas(object prefix)
        {
            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine($"{prefix} {i}");
            }

        }
    }
}
