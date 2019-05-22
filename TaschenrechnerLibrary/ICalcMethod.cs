using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaschenrechnerLibrary
{
    public interface ICalcMethod
    {
        string Operator { get; }
        int Calculate(params int[] op);
    }
}
