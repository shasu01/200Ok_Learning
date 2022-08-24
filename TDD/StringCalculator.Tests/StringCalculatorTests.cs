using System.Globalization;
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

            [TestCase("1,1",2)]
            [TestCase("33,5", 38)]
            [TestCase("6,17", 23)]
            [TestCase("11,3", 14)]
            [TestCase("11,3,5,10,100", 129)]
            [Test]
            public void Given_StringNumbers_ShouldReturn_ExpectedResult(string numbers, int expectedResult)
            {
                //Arrange
                var sut = CreateStringCalculator();

                //Act
                var result = sut.Add(numbers);

                //Assert
                result.Should().Be(expectedResult);
            }

            [TestCase("1\n1", 2)]
            [Test]
            public void Given_StringNumbersWithNewLine_ShouldReturn_ExpectedResult(string numbers, int expectedResult)
            {
                //Arrange
                var sut = CreateStringCalculator();

                //Act
                var result = sut.Add(numbers);

                //Assert
                result.Should().Be(expectedResult);
            }
            [TestCase("//;\n1;2", 3)]
            [Test]
            public void Given_StringNumbersWithDynamicDelimeter_ShouldReturn_ExpectedResult(string numbers, int expectedResult)
            {
                //Arrange
                var sut = CreateStringCalculator();

                //Act
                var result = sut.Add(numbers);

                //Assert
                result.Should().Be(expectedResult);
            }

            [TestCase("//;\n1;-2", "Negatives Not Allowed, -2 ")]
            [TestCase("//;\n-1;-2;1", "Negatives Not Allowed, -1 -2 ")]
            [Test]
            public void Given_StringNumbersWithNegativeNumber_Should_ThrowException(string numbers, string exception)
            {
                //Arrange
                var sut = CreateStringCalculator();

                //Act
                Assert.That(() => sut.Add(numbers),
                    Throws.Exception
                        .With
                        .Message.EqualTo(exception));
            }


            private StringCalculator CreateStringCalculator()
            {
                return new StringCalculator();
            }
        }
    }
}