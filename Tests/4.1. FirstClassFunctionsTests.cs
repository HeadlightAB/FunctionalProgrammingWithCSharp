using System;
using Xunit;

namespace Tests
{
    public class FirstClassFunctionsTests
    {
        [Fact]
        public void Should_support_first_class_function()
        {
            Func<int, int, int> aSumFuncNamed = ASumFuncNamed;
            Func<int, int, int> aSumFuncDelegate = delegate(int x, int y) { return x + y; };
            Func<int, int, int> aSumFuncLambda = (x, y) => x + y;

            Assert.Equal(3, aSumFuncNamed(1, 2));
            Assert.Equal(3, aSumFuncDelegate(1, 2));
            Assert.Equal(3, aSumFuncLambda(1, 2));
        }

        [Fact]
        public void Sort_of_first_class_local_functions()
        {
            int ASumLocalFunc(int x, int y)
            {
                return x + y;
            }

            int ASumLocalEpressionBodyFunc(int x, int y) => x + y;

            Assert.Equal(3, ASumLocalFunc(1, 2));
            Assert.Equal(3, ASumLocalEpressionBodyFunc(1, 2));
        }

        private int ASumFuncNamed(int x, int y)
        {
            return x + y;
        }
    }
}
