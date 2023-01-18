using Misc;

namespace MiscMSTest
{
    [TestClass]
    public class CalculatorMSTests
    {
        [TestMethod]
        public void AddNumbers_InputTwoDouble_GetCorrectResult()
        {
            // Arrange
            Calculator calculator = new Calculator();

            // Act
            var result = calculator.AddNumbers(10, 10);

            // Assert
            Assert.AreEqual(20, result); //Pass

            //Assert.AreEqual(20, result); //Fail

        }
    }
}