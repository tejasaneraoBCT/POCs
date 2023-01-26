using Misc;
using Moq;
using Xunit;

namespace MiscXUnitTest
{
    public class BankAccountXUnitTests
    {
        private BankAccount _bankAccount;
        private Mock<ILogBook> _logBook;

        public BankAccountXUnitTests()
        {
            _logBook = new Mock<ILogBook>();
            _bankAccount = new BankAccount(_logBook.Object);
        }

        [Fact]
        public void Deposit_Add1000_ReturnsTrue()
        {
            var result = _bankAccount.Deposit(1000);
            Assert.True(result);
        }

        [Fact]
        public void Withdraw_Withdraw100Balance200_ReturnsTrue()
        {
            _logBook.Setup(x => x.LogBalanceAfterWithdrawal(It.IsAny<int>())).Returns(true);
            _bankAccount.Deposit(200);
            var result = _bankAccount.Withdrawal(100);
            Assert.True(result);
        }

        [Fact]
        public void Withdraw_Withdraw200Balance100_ReturnsFalse()
        {
            _logBook.Setup(x => x.LogBalanceAfterWithdrawal(It.Is<int>(x => x < 0))).Returns(false);
            _logBook.Setup(x => x.LogBalanceAfterWithdrawal(It.IsInRange(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);
            _bankAccount.Deposit(100);
            var result = _bankAccount.Withdrawal(200);
            Assert.False(result);
        }
    }
}
