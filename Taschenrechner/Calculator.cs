using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner
{
    class Calculator
    {
        public delegate int CalcMethod(params int[] operanden);
        CalcMethod calc;
   
        Dictionary<CalcMethods, CalcMethod> CalcDic;

        public Calculator(CalcMethods calcMethod)
        {
            CalcDic = new Dictionary<CalcMethods, CalcMethod>();
            CalcDic.Add(CalcMethods.Add, op => op.Sum());
            CalcDic.Add(CalcMethods.Div, (op1, op2) => op1 / op2);
            CalcDic.Add(CalcMethods.Mod, (op1, op2) => op1 % op2);
            CalcDic.Add(CalcMethods.Mul, (op1, op2) => op1 * op2);
            CalcDic.Add(CalcMethods.Sub, (op1, op2) => op1 - op2);

            calc = CalcDic[calcMethod];

        }

        public int Calculate(params int[] operanden)
        {
       
            return calc(operanden);
        }

        public enum CalcMethods
        {
            Add,
            Sub,
            Mod,
            Div,
            Mul
        }
    }
}
