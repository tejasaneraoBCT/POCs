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
    public class CustomerNUnitTests
    {
        private Customer Customer;

        [SetUp]
        public void Setup()
        {
            Customer = new Customer();
        }

        [Test]
        [TestCase("Tejas")]
        [TestCase("John")]
        public void GreetCustomer_InputName_ReturnMessage(string name)
        {
            // Arrange


            // Act
            var result = Customer.GreetCustomer(name);

            // Assert
            Assert.That(result, Is.EqualTo($"Hello, {name}"));
        }
    }
}
