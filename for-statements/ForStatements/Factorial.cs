namespace ForStatements
{
    public static class Factorial
    {
        public static int GetFactorial(int n)
        {
            int sum = 1;
            for (int i = 1; i <= n; i++)
            {
                sum *= i;
            }

            return sum;
        }

        public static int SumFactorialDigits(int n)
        {
            int product = 1, sum = 0;
            if (n == 0)
            {
                return 1;
            }

            product = 1;
            for (int i = 1; i <= n; i++)
            {
                product *= i;
            }

            for (; product > 0; product = product / 10)
            {
                sum += product % 10;
            }

            return sum;
        }
    }
}
