using System;
using System.Collections.Generic;
using System.Text;

namespace ThirdDemo.Tests
{
    public class CalculatorData
    {
        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { 1, 2, 3 },
                new object[] { -4, -6, -10 },
                new object[] { -2, 2, 0 },
                new object[] { int.MinValue, -1, int.MaxValue },
            };
    }
}
