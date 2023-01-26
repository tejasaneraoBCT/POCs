using Misc;
using Xunit;

namespace MiscXUnitTest
{
    public class CustomerXUnitTests
    {
        private Customer Customer;

        public CustomerXUnitTests()
        {
            Customer = new Customer();
        }

        [Theory]
        [InlineData("Tejas")]
        [InlineData("John")]
        public void GreetCustomer_InputName_ReturnMessage(string name)
        {
            // Arrange


            // Act
            var result = Customer.GreetCustomer(name);


            // Null Check
            //Assert.IsNotNull(name);
            //Assert.IsFalse(string.IsNullOrEmpty(name));

            // Assert
            Assert.Equal($"Hello, {name}", result);
        }

        [Fact]
        public void GreetCustomer_EmptyName_ThrowsException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => Customer.GreetCustomer(" "));

            // Check if exception is thrown
            Assert.Throws<ArgumentException>(() => Customer.GreetCustomer(" "));

            Assert.Equal("Empty name", exceptionDetails.Message);

            // Check if exception is thrown
            //Assert.That(() => Customer.GreetCustomer(" "), Throws.ArgumentException);
        }

        [Fact]
        public void CustomerType_CreateCustomerWithLessThan100OrderTotal_ReturnBasicCustomer()
        {
            Customer.OrderTotal = 90;
            var customerType = Customer.GetCustomerDetails();
            Assert.IsType<BasicCustomer>(customerType);
        }

        [Fact]
        public void CustomerType_CreateCustomerWithMoreThan100OrderTotal_ReturnPlatinumCustomer()
        {
            Customer.OrderTotal = 190;
            var customerType = Customer.GetCustomerDetails();
            Assert.IsType<PlatinumCustomer>(customerType);
        }

    }

}
