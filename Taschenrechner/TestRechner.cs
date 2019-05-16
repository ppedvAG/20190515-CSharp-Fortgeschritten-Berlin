using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner
{
    [TestClass]
    public class TestRechner
    {
        [TestMethod]
        public void TestAddieren()
        {
            Calculator calc = new Calculator(Calculator.CalcMethods.Add);

            var result = calc.Calculate();
            Assert.AreEqual(0, result);

            result = calc.Calculate(10, 5);
            Assert.AreEqual(15, result);

            var zuBerechnen = new int[] { 10, 5, 3, 1 , 99, -2, 0};
            result = calc.Calculate(zuBerechnen);
            Assert.AreEqual(116, result);
        }
        [TestMethod]
        public void TestSubtrahieren()
        {
            Calculator calc = new Calculator(Calculator.CalcMethods.Sub);

            var result = calc.Calculate(10, 5);
            Assert.AreEqual(5, result);

            var zuBerechnen = new int[] { 10, 5, 3, 1, 99, -2, 0 };
            result = calc.Calculate(zuBerechnen);
            Assert.AreEqual(-96, result);
        }
    }
}
