using FluentAssertions;
using NUnit.Framework;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestFixture]
        public class Add
        {
            //Given 1 and 1 should return 2
            //Given 33 and 5 should return 38
            //Given 6 and 17 should return 23
            //Given 11 and 3 should return 14
            [Test]
            public void Given_EmptyString_ShouldReturn_0()
            {
                //Arrange
                var numbers = string.Empty;
                var sut = CreateStringCalculator();

                //Act
                var result = sut.Add(numbers);

                //Assert
                result.Should().Be(0);
            }

            [Test]
            public void Given_Null_ShouldReturn_0()
            {
                //Arrange
                var sut = CreateStringCalculator();

                //Act
                var result = sut.Add(null);

                //Assert
                result.Should().Be(0);
            }

            [Test]
            public void Given_1_ShouldReturn_1()
            {
                //Arrange
                var numbers = "1";
                var sut = CreateStringCalculator();

                //Act
                var result = sut.Add(numbers);

                //Assert
                result.Should().Be(1);
            }

            [Test]
            public void Given_5_ShouldReturn_5()
            {
                //Arrange
                var numbers = "5";
                var sut = CreateStringCalculator();

                //Act
                var result = sut.Add(numbers);

                //Assert
                result.Should().Be(5);
            }

            [Test]
            public void Given_60_ShouldReturn_60()
            {
                //Arrange
                var numbers = "60";
                var sut = CreateStringCalculator();

                //Act
                var result = sut.Add(numbers);

                //Assert
                result.Should().Be(60);
            }

            [Test]
            public void Given_1_1_ShouldReturn_2()
            {
                //Arrange
                var numbers = "1,1";
                var sut = CreateStringCalculator();

                //Act
                var result = sut.Add(numbers);

                //Assert
                result.Should().Be(2);
            }

            private StringCalculator CreateStringCalculator()
            {
                return new StringCalculator();
            }
        }
    }
}