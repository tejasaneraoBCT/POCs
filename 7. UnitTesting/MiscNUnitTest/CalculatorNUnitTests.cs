using Misc;
using NuGet.Frameworks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscNUnitTest
{
    [TestFixture]
    public class CalculatorNUnitTests
    {
        private Calculator Calculator;

        [SetUp]
        public void Setup()
        {
            Calculator = new Calculator();
        }

        [Test]
        [TestCase(5.55, 1.15)]
        [TestCase(5.55, 1.16)]
        [TestCase(5.55, 1.14)]
        public void AddNumbers_InputTwoDouble_GetCorrectResult(double x, double y)
        {
            // Arrange
            //Calculator calculator = new Calculator();

            // Act
            var result = Calculator.AddNumbers(x, y);

            // Assert
            // NUnit way
            //Assert.That(result, Is.EqualTo(6.7)); //Pass

            // Normal Way
            Assert.AreEqual(6.7, result, 0.1); //Pass
            //Assert.AreEqual(21, result); //Fail
        }

        [Test]
        [TestCase(9)]
        public void IsOdd_InputOddNumber_ReturnsTrue(int x)
        {
            //Calculator calculator = new Calculator();

            // Act
            var result = Calculator.IsOdd(x);

            // Assert
            Assert.That(result, Is.EqualTo(true));
            //Assert.IsTrue(result);
        }

        [Test]
        [TestCase(6)]
        [TestCase(0)]
        public void IsOdd_InputEvenNumber_ReturnsFalse(int x)
        {
            //Calculator calculator = new Calculator();

            // Act
            var result = Calculator.IsOdd(x);

            // Assert
            Assert.That(result, Is.EqualTo(false));
            //Assert.IsFalse(result);
        }

        // Combine Tests
        [Test]
        [TestCase(9, ExpectedResult = true)]
        [TestCase(8, ExpectedResult = false)]
        public bool IsOdd_InputNumber_ReturnsTrueIfOdd(int x)
        {
            //Calculator calculator = new Calculator();
            return Calculator.IsOdd(x);
        }

        [Test]
        public void OddRange()
        {
            List<int> expectedRange = new List<int> { 5, 7, 9 };

            var result = Calculator.OddRange(5, 10);

            // Multiple Checks
            Assert.Multiple(() =>
            {
                Assert.That(expectedRange, Is.EquivalentTo(result));
                //Assert.That(expectedRange, Does.Contain(7));
                //Assert.That(expectedRange, Is.Not.Empty);
                //Assert.That(expectedRange.Count, Is.EqualTo(3));
                //Assert.That(expectedRange, Has.No.Member(6));
                //Assert.That(expectedRange, Is.Ordered); // Whether collection is ordered
                //Assert.That(expectedRange, Is.Unique); // Contains unique Items
                //Assert.That(expectedRange.Count, Is.InRange(2, 5));
            });


        }
    }
}
