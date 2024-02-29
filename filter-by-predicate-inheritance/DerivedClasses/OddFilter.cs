using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilterByPredicate
{
    public class OddFilter : Filter
    {
        protected override bool IsMatch(int item)
        {
            if (item % 2 == 0)
            {
                return false;
            }

            return true;
        }
    }
}
