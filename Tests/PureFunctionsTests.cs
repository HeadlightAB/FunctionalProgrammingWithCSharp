using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class PureFunctionsTests
    {
        private readonly ITestOutputHelper _output;

        public PureFunctionsTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Add_should_produce_the_Sum()
        {
            var sut = new Code();
            
            const int x = 1;
            const int y = 2;

            var result = sut.Add(x, y);

            Assert.Equal(3, result);
        }

        [Theory]
        [InlineData(1, 2, 3, 1000)]
        public void Add_should_produce_Sum_for_every_pair_of_inputs(int x, int y, int sum, int numberOfInvocations)
        {
            var sut = new Code();

            for (var i = 0; i < numberOfInvocations; i++)
            {
                var result = sut.Add(x, y);

                Assert.Equal(sum, result);

                _output.WriteLine($"(invocation {i}) {x} + {y} = {sum}");
            }
        }

        [Theory]
        [InlineData(1, 1000)]
        public void Increment_is_not_pure(int a, int numberOfInvocations)
        {
            var sut = new Code();

            for (var i = 0; i < numberOfInvocations; i++)
            {
                var result = sut.Increment(a);

                _output.WriteLine($"(invocation {i}) Increment {a} = {result}");
                Assert.Equal(1, result);
            }
        }
    }

    public class Code
    {
        public int Add(int a, int b) => a + b;

        private int _counter = 0;

        public int Increment(int a) => _counter += a;
    }
}
