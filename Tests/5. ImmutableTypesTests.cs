using RectangleExtensions;
using Tests;
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
                Assert.NotEqual(1, rectangleBackup.Length);
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

                Assert.Equal(1, rectangleOne.Width);
                Assert.Equal(2, rectangleOne.Height);

                Assert.Equal(11, rectangleTwo.Width);
                Assert.Equal(12, rectangleTwo.Height);

                Assert.NotSame(rectangleOne, rectangleTwo);
            }

            [Fact]
            public void Prove_the_immutability_second()
            {
                var rectangleOne = new Rectangle(1, 2);
                var rectangleBackup = rectangleOne;

                Assert.Same(rectangleOne, rectangleBackup);

                var rectangleTwo = rectangleOne.Grow(10);

                Assert.Same(rectangleOne, rectangleBackup);
                Assert.NotSame(rectangleTwo, rectangleBackup);
                Assert.NotSame(rectangleTwo, rectangleOne);
            }

            [Fact]
            public void Grow_using_extension_method()
            {
                var rectangle = new Rectangle(1,2);
                var rectangleBackup = rectangle;

                var result = rectangle.Swell(10);

                Assert.Equal(12, result.Height);
                Assert.Equal(11, result.Width);

                Assert.NotSame(rectangleBackup, result);
                Assert.NotSame(rectangle, result);
                Assert.Same(rectangle, rectangleBackup);
            }

            public class Rectangle
            {
                public int Width { get; }
                public int Height { get; }

                public Rectangle(int width, int height)
                {
                    Width = width;
                    Height = height;
                }

                public Rectangle Grow(int growth)
                {
                    return new Rectangle(Width + growth, Height + growth);
                }

                public Rectangle GrowChained(int growth)
                {
                    return Widen(growth).Raise(growth);
                }

                public Rectangle GrowUsingWith(int growth)
                {
                    return With(Width + growth, Height + growth);
                }

                private Rectangle Widen(int growWidth)
                {
                    return this.With(length: this.Width + growWidth);
                }

                private Rectangle Raise(int growHeight)
                {
                    return this.With(height: this.Height + growHeight);
                }

                private Rectangle With(int length = -1, int height = -1)
                {
                    return new Rectangle(length == -1 ? this.Width : length, height == -1 ? this.Height : height);
                }
            }
        }
    }
}

namespace RectangleExtensions
{
    using static ImmutableTypesTests.ThisIsImmutableTests;

    public static class RectangleExtensions
    {
        public static Rectangle Swell(this Rectangle rectangle, int growth)
        {
            return rectangle.Grow(growth);
        }
    }
}