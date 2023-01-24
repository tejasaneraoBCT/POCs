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


            // Null Check
            //Assert.IsNotNull(name);
            //Assert.IsFalse(string.IsNullOrEmpty(name));

            // Assert
            Assert.That(result, Is.EqualTo($"Hello, {name}"));
        }

        [Test]
        public void GreetCustomer_EmptyName_ThrowsException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => Customer.GreetCustomer(" "));

            // Check if exception is thrown
            //Assert.Throws<ArgumentException>(() => Customer.GreetCustomer(" "));

            //Assert.AreEqual("Empty name", exceptionDetails.Message);
            //Assert.That(exceptionDetails.Message, Is.EqualTo("Empty name"));
            Assert.That(() => Customer.GreetCustomer(" "), Throws.ArgumentException.With.Message.EqualTo("Empty name"));
            // Check if exception is thrown
            //Assert.That(() => Customer.GreetCustomer(" "), Throws.ArgumentException);
        }

        [Test]
        public void CustomerType_CreateCustomerWithLessThan100OrderTotal_ReturnBasicCustomer()
        {
            Customer.OrderTotal = 90;
            var customerType = Customer.GetCustomerDetails();
            Assert.That(customerType, Is.TypeOf<BasicCustomer>());
        }

        [Test]
        public void CustomerType_CreateCustomerWithMoreThan100OrderTotal_ReturnPlatinumCustomer()
        {
            Customer.OrderTotal = 190;
            var customerType = Customer.GetCustomerDetails();
            Assert.That(customerType, Is.TypeOf<PlatinumCustomer>());
        }

    }

}
