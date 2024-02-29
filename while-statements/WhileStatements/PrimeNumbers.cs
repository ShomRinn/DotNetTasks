namespace WhileStatements
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
            while (i < n)
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

    public static uint GetLastPrimeNumber(uint n)
    {
        uint i = n;
        if (n < 2)
        {
            return 0;
        }
        else if (i <= n)
        {
            while (true)
            {
                if (IsPrimeNumber(n))
                {
                    return n;
                }

                n--;
            }
        }

        return n;
    }

    public static uint SumLastPrimeNumbers(uint n, uint count)
    {
        uint i = n, sum = 0;
        if (n < 2)
        {
            return 0;
        }
        else if (i <= n)
        {
            while (count > 0)
            {
                if (IsPrimeNumber(n))
                {
                    sum += n;
                    count--;
                }

                n--;
            }
        }

        return sum;
    }
}
    }
