using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    public class Customer
    {
        public int OrderTotal { get; set; }

        public string GreetCustomer(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Empty name");

            return $"Hello, {name}";
        }


        public override string ToString()
        {
            return "Customer Name";
        }

        public CustomerType GetCustomerDetails()
        {
            if (OrderTotal < 100)
            {
                return new BasicCustomer();
            }

            return new PlatinumCustomer();
        }
    }

    public class CustomerType { }
    public class BasicCustomer : CustomerType { }
    public class PlatinumCustomer : CustomerType { }
}
