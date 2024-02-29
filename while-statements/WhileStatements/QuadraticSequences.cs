namespace WhileStatements
{
    public static class QuadraticSequences
    {
        public static long SumQuadraticSequenceTerms1(long a, long b, long c, long maxTerm)
        {
            long sum = 0, i = 1, term = 0;
            while (term <= maxTerm)
            {
                term = (a * i * i) + (b * i) + c;
                if (term <= maxTerm)
                {
                    sum += term;
                }

                i++;
            }

            return sum;
        }

        public static long SumQuadraticSequenceTerms2(long a, long b, long c, long startN, long count)
        {
            long sum = 0, i = startN, term = 0;
            while (i < (count + startN))
            {
                term = (a * i * i) + (b * i) + c;
                sum += term;
                i++;
            }

            return sum;
        }
    }
}
