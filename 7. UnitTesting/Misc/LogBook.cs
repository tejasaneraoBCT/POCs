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
    }

    public class LogBook : ILogBook
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
