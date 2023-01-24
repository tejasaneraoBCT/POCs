using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    public class Calculator
    {
        public double AddNumbers(double x, double y)
        {
            return x + y;
        }

        public bool IsOdd(int x)
        {
            return x % 2 != 0;
        }

        public List<int> OddRange(int min, int max)
        {
            List<int> range = new List<int>();

            for (int i = min; i <= max; i++  ){
                if (i % 2 != 0) range.Add(i);
            }

            return range;
        }
    }
}
