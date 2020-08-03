using Xunit;

namespace Tests
{
    public class RecursiveFunctionsTests
    {
        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        public void Recursive_base_should_produce_expected_result(uint x, uint expected)
        {
            var sut = new Code();

            var result = sut.FactorialRecursive(x);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2, 2)]
        [InlineData(3, 6)]
        [InlineData(4, 24)]
        [InlineData(9, 362880)]
        [InlineData(10, 3628800)]
        public void Recursive_should_produce_expected_result(uint x, uint expected)
        {
            var sut = new Code();

            var result = sut.FactorialRecursive(x);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 6)]
        [InlineData(4, 24)]
        [InlineData(9, 362880)]
        [InlineData(10, 3628800)]
        public void Iterative_should_produce_expected_result(uint x, uint expected)
        {
            var sut = new Code();

            var result = sut.FactorialIteration(x);

            Assert.Equal(expected, result);
        }
    }

    public class Code
    {
        public uint FactorialRecursive(uint x)
        {
            if (x <= 1)
            {
                return 1;
            }

            return x * FactorialRecursive(x - 1);
        }

        public uint FactorialRecursiveAsExpressionBody(uint x) => x <= 1 ? 1 : x * FactorialRecursiveAsExpressionBody(x - 1);
       

        public uint FactorialIteration(uint x)
        {
            uint result = 1;

            for (uint i = 2; i <= x; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}