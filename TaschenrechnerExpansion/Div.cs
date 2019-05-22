using System;
using System.Collections.Generic;
using System.Text;
using TaschenrechnerLibrary;
using System.Linq;

namespace TaschenrechnerExpansion
{
    public class Div : ICalcMethod
    {
        public string Operator => "/";

        public int Calculate(params int[] op)
        {
            return op.Aggregate((x, y) => x / y);
        }
    }
}
