using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaschenrechnerLibrary;

namespace Taschenrechner
{
    class Add : ICalcMethod
    {
        public string Operator => "+";

        public int Calculate(params int[] op)
        {
            return op.Sum();
        }
    }
}
