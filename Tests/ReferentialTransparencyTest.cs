using Xunit;

namespace Tests
{
    public class ReferentialTransparencyTest
    {
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(2, 4, 6)]
        public void Should_be_able_to_replace_with_result_based_on_function_parameters(int x, int y, int expected)
        {
            var resultFromTransparentFunction = SumTransparent(x, y);
            var resultReplaced = x + y;

            Assert.Equal(expected, resultFromTransparentFunction);
            Assert.Equal(expected, resultReplaced);
            Assert.Equal(resultReplaced, resultFromTransparentFunction);
        }

        [Fact]
        public void Not_able_to_replace_with_result_at_all_times()
        {
            var sut1 = new Sum(1);
            var sut2 = new Sum(2);

            var result1 = sut1.NotTransparent(2); // ? = 3
            var result2 = sut2.NotTransparent(2); // ? = 2

            Assert.Equal(3, result1);
            Assert.Equal(2, result2);
        }

        public int SumTransparent(int x, int y)
        {
            return x + y;
        }

        public class Sum
        {
            private readonly int _x;

            public Sum(int x)
            {
                _x = x % 2;
            }

            public int NotTransparent(int y)
            {
                return _x + y;
            }
        }
    }
}
