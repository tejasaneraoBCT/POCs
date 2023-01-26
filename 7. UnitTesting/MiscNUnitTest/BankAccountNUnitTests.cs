using Misc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscNUnitTest
{
    [TestFixture]
    public class BankAccountNUnitTests
    {
        private BankAccount _bankAccount;
        private Mock<ILogBook> _logBook;
        [SetUp]
        public void Setup()
        {
            _logBook = new Mock<ILogBook>();
            _bankAccount = new BankAccount(_logBook.Object);
        }

        [Test]
        public void Deposit_Add1000_ReturnsTrue()
        {
            var result = _bankAccount.Deposit(1000);
            Assert.That(result, Is.True);
        }

        [Test]
        public void Withdraw_Withdraw100Balance200_ReturnsTrue()
        {
            _logBook.Setup(x => x.LogBalanceAfterWithdrawal(It.IsAny<int>())).Returns(true);
            _bankAccount.Deposit(200);
            var result = _bankAccount.Withdrawal(100);
            Assert.That(result, Is.True);
        }

        [Test]
        public void Withdraw_Withdraw200Balance100_ReturnsFalse()
        {
            _logBook.Setup(x => x.LogBalanceAfterWithdrawal(It.Is<int>(x=>x<0))).Returns(false);
            _logBook.Setup(x => x.LogBalanceAfterWithdrawal(It.IsInRange<int>(int.MinValue, -1,Moq.Range.Inclusive))).Returns(false);
            _bankAccount.Deposit(100);
            var result = _bankAccount.Withdrawal(200);
            Assert.That(result, Is.False);
        }
    }
}
