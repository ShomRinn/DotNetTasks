namespace WhilePractice
{
    public static class Task3
    {
        /// <summary>
        /// Calculate the following sum
        /// 1/1^5 + 1/2^5 + 1/3^5 + ... + 1/n^5, where n > 0.
        /// </summary>
        /// <param name="n">Number of elements.</param>
        /// <returns>Sum of elements.</returns>
        public static double SumSequenceElements(int n)
        {
            double sum = 0;
            int n1 = 1;

            while (n1 <= n)
            {
                double j = 1;
                int i = 1;

                while (i <= 5)
                {
                    j = j * n1;
                    i++;
                }

                sum += 1 / j;
                n1++;
            }

            return sum;
        }
    }
}
