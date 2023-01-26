using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    public interface ILogBook
    {
        void Log(string message);
        bool LogBalanceAfterWithdrawal(int balance);
        bool LogToDb(string message);
    }

    public class LogBook : ILogBook
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public bool LogBalanceAfterWithdrawal(int balance)
        {
            if(balance >= 0)
            {
                return true;
            }
            return false;
        }

        public bool LogToDb(string message)
        {
            Console.WriteLine(message);
            return true;
        }
    }
}
