using Xunit;

namespace Tests
{
    public class ImmutableTypesTests
    {
        public class ThisIsMutableTests
        {
            [Fact]
            public void Prove_mutability()
            {
                var rectangle = new MutableRectangle(1, 2);
                var rectangleBackup = rectangle;

                rectangle.Grow(10);

                Assert.Equal(11, rectangle.Length);
                Assert.Equal(11, rectangleBackup.Length);
                Assert.Same(rectangle, rectangleBackup);
            }

            public class MutableRectangle
            {
                public int Length { get; private set; }
                public int Height { get; private set; }

                public MutableRectangle(int length, int height)
                {
                    Length = length;
                    Height = height;
                }

                public void Grow(int growth)
                {
                    Length += growth;
                    Height += growth;
                }
            }
        }

        public class ThisIsImmutableTests
        {
            [Fact]
            public void Prove_the_immutability_first()
            {
                var rectangleOne = new Rectangle(1, 2);

                var rectangleTwo = rectangleOne.Grow(10);

                Assert.Equal(1, rectangleOne.Length);
                Assert.Equal(2, rectangleOne.Height);

                Assert.Equal(11, rectangleTwo.Length);
                Assert.Equal(12, rectangleTwo.Height);

                Assert.NotSame(rectangleOne, rectangleTwo);
            }

            [Fact]
            public void Prove_the_immutability_second()
            {
                var rectangleOne = new Rectangle(1, 2);
                var rectangleBackup = rectangleOne;

                Assert.Same(rectangleOne, rectangleBackup);

                rectangleOne = rectangleOne.Grow(10);

                Assert.NotSame(rectangleOne, rectangleBackup);
            }

            public class Rectangle
            {
                public int Length { get; }
                public int Height { get; }

                public Rectangle(int length, int height)
                {
                    Length = length;
                    Height = height;
                }

                public Rectangle Grow(int growth)
                {
                    return new Rectangle(Length + growth, Height + growth);
                }
            }
        }
    }
}