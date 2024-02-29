namespace WhilePractice
{
    public static class Task1
    {
        /// <summary>
        /// Calculate the following sum 1/1 + 1/2 + 1/3 + ... + 1/n, where n > 0.
        /// </summary>
        /// <param name="n">Number of elements.</param>
        /// <returns>Sum of elements.</returns>
        public static double SumSequenceElements(int n)
        {
            double sum = 0, i = 1, k = 0;
            int n1 = n;
            while (n1 > 0)
            {
                k = 1 / i;
                sum = sum + k;
                i++;
                n1 = n1 - 1;
            }

            return sum;
        }
    }
}
