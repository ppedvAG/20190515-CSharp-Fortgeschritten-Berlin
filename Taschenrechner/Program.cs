﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner
{
    class Program
    {
        static void Main(string[] args)
        {


            var addCalc = new Calculator();
            addCalc.StartUI();

            Console.ReadKey();

        }
    }
}
