namespace ForStatements
{
    public static class PrimeNumbers
    {
        public static bool IsPrimeNumber(uint n)
        {
            uint i = 2;
            if (n < 2)
            {
                return false;
            }
            else if (i < n)
            {
                for (; i < n;)
                {
                    if (n % i == 0)
                    {
                        return false;
                    }

                    i++;
                }
            }

            return true;
        }

        public static ulong SumDigitsOfPrimeNumbers(int start, int end)
        {
            int sum = 0;
            for (; start <= end; start++)
            {
                if (IsPrimeNumber((uint)start))
                {
                    for (int i = start; i > 0; i /= 10)
                    {
                        sum += i % 10;
                    }
                }
            }

            return (ulong)sum;
        }
    }
}
