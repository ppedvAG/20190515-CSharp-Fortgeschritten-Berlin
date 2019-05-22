using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaschenrechnerLibrary;

namespace Taschenrechner
{
    class Calculator
    {
        List<ICalcMethod> CalcDic = new List<ICalcMethod>();

        public Calculator()
        {
            foreach (string datei in Directory.GetFiles(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "plugins")))
            {
                if(Path.GetExtension(datei) == ".dll")
                {
                    Assembly.LoadFrom(datei);
                }
            }
            // Die gesamte Assembly durchgehen und alle ICalcMethod holen
                CalcDic = AppDomain.CurrentDomain?.GetAssemblies()?
                    .SelectMany(x => x.GetTypes())
                    .Where(x => typeof(ICalcMethod).IsAssignableFrom(x))
                    .Where(x => !x.IsInterface)
                    .Select(x => (ICalcMethod)Activator.CreateInstance(x))
                    .ToList();

            //Lädt alle verfügbaren Rechenoperationen

            //CalcDic = new List<ICalcMethod>();
            //CalcDic.Add(new Add());
            //CalcDic.Add(new Sub());
            //CalcDic.Add(CalcMethods.Div, (op1, op2) => op1 / op2);
            //CalcDic.Add(CalcMethods.Mod, (op1, op2) => op1 % op2);
            //CalcDic.Add(CalcMethods.Mul, (op1, op2) => op1 * op2);
            
            //calc = CalcDic[calcMethod];
        }

        public int[] ParseNumbers(string input)
        {
            return input.Trim().Split(',').Select(int.Parse).ToArray();
        }

        public void StartUI()
        {
            Console.WriteLine("Bitte gib eine Rechenoperation ein: ");
            string eingabeOp = Console.ReadLine();

            Console.WriteLine("Bitte gib die Operanden ein: ");
            string eingabeOperanden = Console.ReadLine();
            int[] operanden = ParseNumbers(eingabeOperanden);

            Console.WriteLine($"Das Ergebnis lautet: {Calculate(eingabeOp, operanden)}");
        }

        public int Calculate(string op, params int[] operanden)
        {
            // Suche nach der eingegebenen Rechenoperation und führe diese aus "+"
            foreach (var item in CalcDic)
            {
                if(item.Operator == op)
                {
                    return item.Calculate(operanden);
                }
            }
            throw new Exception("Operation not found");
        }
    }
}
