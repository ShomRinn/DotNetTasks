namespace LeapYearTask
{
    public static class Year
    {
        /// <summary>
        /// Returns true if a specified <paramref name="year"/> is a leap year.
        /// </summary>
        /// <param name="year">A year to test.</param>
        /// <returns>True if a specified <paramref name="year"/> is a leap year; otherwise false.</returns>
        public static bool IsLeapYear(int year)
        {
            int i = 4;
            int i1 = 100;
            int i2 = 400;
            int a1, a2, a3;
            bool k = false;
            a1 = year % i;
            a2 = year % i1;
            a3 = year % i2;
            if (a1 > -1 && a1 < 1)
            {
                if (a2 > -1 && a2 < 1)
                {
                    if (a3 != 0)
                    {
                        k = false;
                    }
                    else
                    {
                        k = true;
                    }
                }
                else
                {
                    k = true;
                }
            }
            else
            {
                k = false;
            }

            return k;
        }
    }
}
