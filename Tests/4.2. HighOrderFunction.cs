using System;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class HighOrderFunctionsTest
    {
        private readonly ITestOutputHelper _output;

        public HighOrderFunctionsTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void SumLambda_Test()
        {
            var expected = 3;

            var func = Sum();

            var result = func(1, 2);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SumDelegate_Test()
        {
            var expected = 3;

            var func = SumDelegate();

            var result = func(1, 2);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SumFunction_Test()
        {
            var expected = 3;

            var func = SumFunction();
            var result = func(1, 2);

            Assert.Equal(expected, result);
        }

        ///////////////////////////////////////////

        public Func<int, int, int> Sum()
        {
            return (x, y) => x + y;
        }

        public Func<int, int, int> SumDelegate()
        {
            return delegate (int x, int y) { return x + y; };
        }

        public Func<int, int, int> SumFunction()
        {
            return SumOfTwoInteger;
        }

        private static int SumOfTwoInteger(int x, int y)
        {
            return x + y;
        }

        ///////////////////////////////////////////

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(10)]
        [InlineData(100)]
        public void FunctionAsAParameter_Test(int p)
        {
            static int Random(int max) => new Random().Next(max);

            var result = IsEven(Random, p) ? "even" : "odd";

            _output.WriteLine($"{result}");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void FunctionAsAParameter_OneMoreTest(int x)
        {
            static int Double(int a) => 2 * a;

            var result = IsEven(Double, x);

            Assert.True(result);
        }

        ///////////////////////////////////////////

        private static bool IsEven(Func<int, int> func, int max) => func(max) % 2 == 0;

        ///////////////////////////////////////////

    }
}