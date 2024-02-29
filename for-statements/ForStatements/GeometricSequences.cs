namespace ForStatements
{
    public static class GeometricSequences
    {
        public static ulong GetGeometricSequenceTermsProduct(uint a, uint r, uint n)
        {
            ulong p = 1;
            for (ulong i = 0; i < n; i++)
            {
                ulong rpow = 1;
                for (ulong j = 0; j < i; j++)
                {
                    rpow *= r;
                }

                p *= a * rpow;
            }

            return p;
        }

        public static ulong SumGeometricSequenceTerms(uint n)
        {
            const ulong tree = 3, first = 5;
            ulong sum = 0;
            for (uint i = 0; i < n; i++)
            {
                ulong rpow = 1;
                for (ulong j = 0; j < i; j++)
                {
                    rpow *= tree;
                }

                sum += first * rpow;
            }

            return sum;
        }

        public static ulong CountGeometricSequenceTerms1(uint a, uint r, uint maxTerm)
        {
            ulong term = a, i = 0;
            for (; term <= maxTerm;)
            {
                i++;
                ulong rpow = 1;
                for (ulong j = 0; j < i; j++)
                {
                    rpow = rpow * r;
                }

                term = a * rpow;
            }

            return i;
        }

        public static ulong CountGeometricSequenceTerms2(uint a, uint r, uint n, uint minTerm)
        {
            uint i = n - 1, term = 0;
            for (uint rpow = 1, j = 0; j < i; i--)
            {
                if (j < 1)
                {
                    for (; j < i; j++)
                    {
                        rpow *= r;
                    }
                }

                term = a * rpow;
                if ((term < minTerm) && (i == n - 1))
                {
                    return 0;
                }

                if ((term <= minTerm) || (i == 0))
                {
                    return n - i;
                }

                rpow = 1;
                j = 0;
            }

            return n - i;
        }
    }
}
