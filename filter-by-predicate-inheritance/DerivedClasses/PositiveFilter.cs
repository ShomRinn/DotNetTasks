using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FilterByPredicate;

namespace DerivedClasses
{
    public class PositiveFilter : Filter
    {
        protected override bool IsMatch(int item)
        {
            if (item <= 0)
            {
                return false;
            }

            return true;
        }
    }
}
