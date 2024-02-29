namespace ForStatements
{
    public static class QuadraticSequences
    {
        public static uint CountQuadraticSequenceTerms(long a, long b, long c, long maxTerm)
        {
            long term = 0;
            uint i;
            for (i = 1; term < maxTerm; i++)
            {
                term = (a * (i * i)) + (b * i) + c;
            }

            if (i > 0)
            {
                return i - 1;
            }
            else
            {
                return 0;
            }
        }

        public static ulong GetQuadraticSequenceTermsProduct1(uint count)
        {
            ulong term = 0, product = 1;
            uint i = 1;
            for (; count > 0; count--)
            {
                term = (7 * (i * i)) + (4 * i) + 2;
                product *= term;
                i++;
            }

            return product;
        }

        public static ulong GetQuadraticSequenceProduct2(long a, long b, long c, long startN, long count)
        {
            long term = 0, product = 1;
            long i = startN;
            for (; count > 0; count--)
            {
                term = (a * (i * i)) + (b * i) + c;
                product *= term;
                i++;
            }

            return (ulong)product;
        }
    }
}
