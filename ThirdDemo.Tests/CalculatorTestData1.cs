using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ThirdDemo.Tests
{
    public class CalculatorTestData1 : TheoryData<int, int ,int>
    {

        public CalculatorTestData1()
        {
            Add(1, 2, 3);
            Add(-4, -6, -10);
            Add(-2, 2, 0);
            Add(int.MinValue, -1, int.MaxValue);
            //Add(1.5, 2.3m, "The value"); // will not compile!
        }
    }
}
