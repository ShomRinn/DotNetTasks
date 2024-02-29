using System.Globalization;

namespace WhileStatements
{
    public static class GeometricSequences
    {
        public static uint SumGeometricSequenceTerms1(uint a, uint r, uint n)
        {
            uint sum = 0, i = 0;
            while (i < n)
            {
                uint j = 0, rpow = 1;
                while (j < i)
                {
                    rpow *= r;
                    j++;
                }

                sum += a * rpow;
                i++;
            }

            return sum;
        }

        public static uint SumGeometricSequenceTerms2(uint n)
        {
            uint sum = 0, i = 0;
            while (i < n)
            {
                uint j = 0, rpow = 1;
                while (j < i)
                {
                    rpow *= 3;
                    j++;
                }

                sum += 13 * rpow;
                i++;
            }

            return sum;
        }

        public static uint CountGeometricSequenceTerms3(uint a, uint r, uint maxTerm)
        {
            uint sum = 0, i = 0, count = 0;
            uint j = 0, rpow = 1;

            if ((a * rpow) == maxTerm)
            {
                count = 1;
            }

            if ((a * rpow) < maxTerm)
            {
                while ((a * rpow) < maxTerm)
                {
                    while (j < i)
                    {
                        rpow *= r;
                        j++;
                    }

                    sum += a * rpow;
                    i++;
                    count++;
                }
            }

            return count;
        }

        public static uint CountGeometricSequenceTerms4(uint a, uint r, uint n, uint minTerm)
        {
            uint sum = 0, i = 0, count = 0;
            uint j = 0, rpow = 1;

            if (minTerm == 0)
            {
                count--;
            }

            if ((a * rpow) <= minTerm)
            {
                do
                {
                    while (j < i)
                    {
                        rpow *= r;
                        j++;
                    }

                    sum += a * rpow;
                    i++;
                }
                while ((a * rpow) < minTerm);
            }

            while (i <= n)
            {
                while (j < i)
                {
                    rpow *= r;
                    j++;
                }

                sum += a * rpow;
                i++;
                count++;
            }

            return count;
        }
    }
}
