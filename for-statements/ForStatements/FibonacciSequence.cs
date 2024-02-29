namespace ForStatements
{
    public static class FibonacciSequence
    {
        public static int GetFibonacciNumber(int n)
        {
            int result = 0;
            if (n == 0)
            {
                return 0;
            }

            for (int i = 1, j = 1; n > 0; i += j, n--)
            {
                result = i;
                j = i - j;
            }

            return result;
        }

        public static ulong GetProductOfFibonacciNumberDigits(ulong n)
        {
            int result = 0, product = 1;
            if (n == 0)
            {
                return 0;
            }

            for (int i = 1, j = 1; n > 0; i += j, n--)
            {
                result = i;
                j = i - j;
            }

            for (; result > 0; result /= 10)
            {
                product *= result % 10;
            }

            return (ulong)product;
        }
    }
}
