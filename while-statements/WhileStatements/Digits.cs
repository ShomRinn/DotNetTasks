namespace WhileStatements
{
    public static class Digits
    {
        public static ulong GetDigitsSum(ulong n)
        {
            ulong sum = 0;
            while (n > 0)
            {
                ulong nom = n % 10;
                n /= 10;
                sum += nom;
            }

            return sum;
        }

        public static ulong GetDigitsProduct(ulong n)
        {
            ulong result = 1;
            if (n == 0)
            {
                result = 0;
            }

            while (n > 0)
            {
                ulong nom = n % 10;
                n /= 10;
                result *= nom;
            }

            return result;
        }
    }
}
