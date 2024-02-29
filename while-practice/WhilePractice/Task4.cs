namespace WhilePractice
{
    public static class Task4
    {
        /// <summary>
        /// Calculate the following sum
        /// 1/(3 * 3) + 1/(5 * 5) + 1/(7 * 7) + ... + 1/((2 * n + 1) * (2 * n + 1)), where n > 0.
        /// </summary>
        /// <param name="n">Number of elements.</param>
        /// <returns>Sum of elements.</returns>
        public static double SumSequenceElements(int n)
        {
            double sum = 0;
            long n1 = 1;
            while (n1 <= n)
            {
                double i = 1;
                sum = sum + ( i / (((2 * n1) + 1) * ((2 * n1) + 1)));
                n1++;
            }

            return sum;
        }
    }
}
