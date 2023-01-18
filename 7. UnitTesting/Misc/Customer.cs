using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    public class Customer
    {
        public string GreetCustomer(string name)
        {
            return $"Hello, {name}";
        }


        public override string ToString()
        {
            return "Customer Name";
        }
    }
}
