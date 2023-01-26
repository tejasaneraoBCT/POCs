using Misc;
using Xunit;

namespace MiscXUnitTest
{
    public class CalculatorXUnitTests
    {
        private Calculator Calculator;

        public CalculatorXUnitTests()
        {
            Calculator = new Calculator();
        }

        [Theory]
        [InlineData(5.55, 1.15)]
        //[InlineData(5.55, 1.16)]
        //[InlineData(5.55, 1.14)]
        public void AddNumbers_InputTwoDouble_GetCorrectResult(double x, double y)
        {
            // Arrange
            //Calculator calculator = new Calculator();

            // Act
            var result = Calculator.AddNumbers(x, y);

            // Assert
            // XUnit way
            Assert.Equal(6.7, result, 1); //Pass
            //Assert.Equal(6.7, result, 2); //Pass

            // Normal Way
            //Assert.AreEqual(6.7, result, 0.1); //Pass
            //Assert.AreEqual(21, result); //Fail
        }

        [Theory]
        [InlineData(9)]
        public void IsOdd_InputOddNumber_ReturnsTrue(int x)
        {
            //Calculator calculator = new Calculator();

            // Act
            var result = Calculator.IsOdd(x);

            // Assert
            Assert.True(result);
            //Assert.IsTrue(result);
        }

        [Theory]
        [InlineData(6)]
        [InlineData(0)]
        public void IsOdd_InputEvenNumber_ReturnsFalse(int x)
        {
            //Calculator calculator = new Calculator();

            // Act
            var result = Calculator.IsOdd(x);

            // Assert
            Assert.False(result);
            //Assert.IsFalse(result);
        }

        // Combine Tests
        [Theory]
        [InlineData(9, true)]
        [InlineData(8, false)]
        public void IsOdd_InputNumber_ReturnsTrueIfOdd(int x, bool expected)
        {
            //Calculator calculator = new Calculator();
            var result = Calculator.IsOdd(x);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void OddRange()
        {
            List<int> expectedRange = new List<int> { 5, 7, 9 };

            var result = Calculator.OddRange(5, 10);

            // Multiple Checks
            Assert.Multiple(() =>
            {
                Assert.Equal(expectedRange, result);
                //Assert.Contains(7, expectedRange);
                //Assert.NotEmpty(result);
                //Assert.Equal(3, result.Count);
                //Assert.DoesNotContain(result, 6);
                //Assert.Equal(result.OrderBy(u=>u), result); // Whether collection is ordered
                //Assert.That(expectedRange, Is.Unique); // Contains unique Items
                //Assert.That(expectedRange.Count, Is.InRange(2, 5));
            });


        }
    }
}
