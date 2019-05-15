using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner
{
    class Calculator
    {
        public delegate int CalcMethod(int op1, int op2);
        CalcMethod calc;
   
        public Calculator(string calcMethod)
        {
            if (calcMethod == "Add")
            {
                calc = new CalcMethod(Add);
            } else if (calcMethod == "Sub")
            {
                calc = new CalcMethod(delegate(int op1, int op2)
                {
                    return op1 - op2;
                });
            } else if (calcMethod == "Mul")
            {
                calc = delegate (int op1, int op2)
                {
                    return op1 * op2;
                };
            }

        }

        public int Calculate(int op1,int op2)
        {
            return calc(op1, op2);
        }
        
        public int Add(int op1, int op2)
        {
            return op1 + op2;
        }
        public int Sub(int op1, int op2)
        {
            return op1 - op2;
        }
    }
}
