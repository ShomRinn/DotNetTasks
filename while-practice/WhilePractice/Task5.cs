namespace WhilePractice
{
    public static class Task5
    {
        /// <summary>
        /// Calculate the following product
        /// (1 + 1/(1 * 1)) * (1 + 1/(2 * 2)) * (1 + 1/(3 * 3)) * ... * (1 + 1/(n * n)), where n > 0.
        /// </summary>
        /// <param name="n">Number of elements.</param>
        /// <returns>Product of elements.</returns>
        public static double GetSequenceProduct(int n)
        {
            double sum = 1;
            long n1 = 1;
            while (n1 <= n)
            {
                double i = 1;
                double n2 = n1 * n1;
                sum *= i + (i / n2);
                n1++;
            }

            return sum;
        }
    }
}
