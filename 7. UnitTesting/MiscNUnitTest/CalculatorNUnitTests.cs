using Misc;
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
        [TestCase(5.55,1.15)]
        [TestCase(5.55,1.16)]
        [TestCase(5.55,1.14)]
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
    }
}
