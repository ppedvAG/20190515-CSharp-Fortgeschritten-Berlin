using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaschenrechnerLibrary;

namespace Taschenrechner
{
    class Sub : ICalcMethod
    {
        public string Operator => "-";

        public int Calculate(params int[] op)
        {
            return op.Aggregate((x, y) => x - y);
        }
    }
}
