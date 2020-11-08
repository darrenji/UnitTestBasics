using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThirdDemo.Lib;
using Xunit;

namespace ThirdDemo.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void CanAdd()
        {
            //Arrange
            var calculator = new Calculator();
            int value1 = 1;
            int value2 = 2;

            //Act
            var result = calculator.Add(value1, value2);

            //Assert
            Assert.Equal(3, result);
        }

        /// <summary>
        /// 测试数据放测试方法上
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="exptected"></param>
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(-4, -6, -10)]
        [InlineData(-2, 2, 0)]
        [InlineData(int.MinValue, -1, int.MaxValue)]
        public void CanAddTheory(int value1, int value2, int exptected)
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var result = calculator.Add(value1, value2);

            //Assert
            Assert.Equal(exptected, result);
        }

        /// <summary>
        /// 测试数据来自IEnumerable<object[]>实现类里
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="exptected"></param>
        [Theory]
        [ClassData(typeof(CalculatorTestData))]
        public void CanAddTheoryClassData(int value1, int value2, int exptected)
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var result = calculator.Add(value1, value2);

            //Assert
            Assert.Equal(exptected, result);
        }

        /// <summary>
        /// 测试数据来自类型为IEnumerable<object[]>的静态属性
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="expected"></param>
        [Theory]
        [MemberData(nameof(Data))]
        public void CanAddTheoryMemberDataProperty(int value1, int value2, int expected)
        {
            var calculator = new Calculator();
            var result = calculator.Add(value1, value2);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// 测试数据来自返回类型为IEnumerable<object[]>的静态方法
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="expected"></param>
        [Theory]
        [MemberData(nameof(GetData), parameters:3)]
        public void CanAddTheoryMemberDataMethod(int value1, int value2, int expected)
        {
            var calculator = new Calculator();

            var result = calculator.Add(value1, value2);

            Assert.Equal(expected, result);
        }

        /// <summary>
        /// 测试数据来自外部类返回类型为IEnumerable<object[]>的静态方法
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="expected"></param>
        [Theory]
        [MemberData(nameof(CalculatorData.Data), MemberType =typeof(CalculatorData))]
        public void CanAddTheoryMemberDataMethod1(int value1, int value2, int expected)
        {
            var calculator = new Calculator();

            var result = calculator.Add(value1, value2);

            Assert.Equal(expected, result);
        }

        /// <summary>
        /// 测试数据来自外部json文件
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="expected"></param>
        [Theory]
        [JsonFileData("all_data.json")]
        public void CanAddAll(int value1, int value2, int expected)
        {
            var calculator = new Calculator();

            var result = calculator.Add(value1, value2);

            Assert.Equal(expected, result);
        }

        /// <summary>
        /// 测试数据来自外部json文件中的某个属性
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="expected"></param>
        [Theory]
        [JsonFileData("data.json", "AddData")]
        public void CanAdd1(int value1, int value2, int expected)
        {
            var calculator = new Calculator();

            var result = calculator.Add(value1, value2);

            Assert.Equal(expected, result);
        }

        /// <summary>
        /// 测试数据来自外部json文件的某个属性
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="expected"></param>
        [Theory]
        [JsonFileData("data.json", "SubtractData")]
        public void CanSubtract(int value1, int value2, int expected)
        {
            var calculator = new Calculator();

            var result = calculator.Subtract(value1, value2);

            Assert.Equal(expected, result);
        }

        /// <summary>
        /// 测试数据来自 TheoryData<int, int ,int>泛型
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="expected"></param>
        [Theory]
        [ClassData(typeof(CalculatorTestData1))]
        public void CanAdd2(int value1, int value2, int expected)
        {
            var calculator = new Calculator();
            var result = calculator.Add(value1, value2);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// 测试数据来自返回类型为TheoryData<int, int, int>的静态属性
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="expected"></param>
        [Theory]
        [MemberData(nameof(Data1))]
        public void CanAdd3(int value1, int value2, int expected)
        {
            var calculator = new Calculator();

            var result = calculator.Add(value1, value2);

            Assert.Equal(expected, result);
        }


        /// <summary>
        /// 静态属性提供数据源，返回IEnumerable<object[]>
        /// </summary>
        public static IEnumerable<object[]> Data =>
           new List<object[]>
           {
                new object[] { 1, 2, 3 },
                new object[] { -4, -6, -10 },
                new object[] { -2, 2, 0 },
                new object[] { int.MinValue, -1, int.MaxValue },
           };

        /// <summary>
        /// 静态方法提供数据源
        /// </summary>
        /// <param name="numTests"></param>
        /// <returns></returns>
        public static IEnumerable<object[]> GetData(int numTests)
        {
            var allData = new List<object[]>
            {
                new object[] { 1, 2, 3 },
                new object[] { -4, -6, -10 },
                new object[] { -2, 2, 0 },
                new object[] { int.MinValue, -1, int.MaxValue },
            };

            return allData.Take(numTests);
        }

        /// <summary>
        /// 静态属性提供数据源，返回TheoryData<int, int, int>泛型
        /// </summary>
        public static TheoryData<int, int, int> Data1 =>
            new TheoryData<int, int, int> {
                { 1, 2, 3 },
                { -4, -6, -10 },
                { -2, 2, 0 },
                { int.MinValue, -1, int.MaxValue }
            };
    }
}
