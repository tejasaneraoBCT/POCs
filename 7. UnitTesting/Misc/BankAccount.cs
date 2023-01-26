using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    public class BankAccount
    {
        public int Balance { get; set; }
        private readonly ILogBook _logBook;

        public BankAccount(ILogBook logBook)
        {
            Balance = 0;
            _logBook = logBook;
        }

        public bool Deposit(int amount)
        {
            Balance += amount;
            _logBook.Log($"INR {amount} where credited to your account");
            return true;
        }

        public bool Withdrawal(int amount)
        {
            if (Balance >= amount)
            {
                _logBook.LogToDb($"INR {amount} has been debited from your account");
                Balance -= amount;
                return _logBook.LogBalanceAfterWithdrawal(Balance);
            }

            //_logBook.Log($"Debit transaction of INR {amount} failed due to insufficient balance");
            return _logBook.LogBalanceAfterWithdrawal(Balance);
        }

        public int GetBalance() => Balance;

    }
}
