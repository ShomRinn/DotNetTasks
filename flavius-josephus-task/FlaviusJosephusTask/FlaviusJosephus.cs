namespace FlaviusJosephusTask
{
    /// <summary>
    /// class.
    /// </summary>
    public static class FlaviusJosephus
    {
        /// <summary>
        /// Simulate this process of crossing every k-th person in a circle.
        /// </summary>
        /// <param name="n">number of people.</param>
        /// <param name="k">every such a person is crossed out.</param>
        /// <returns>One left person.</returns>
        /// <exception cref="ArgumentException">Thrown if k or n is less than 1.</exception>
        public static int GetLastPerson(int n, int k)
        {
            if (n < 1 || k < 1)
            {
                throw new ArgumentException("Both n and k must be greater than 0");
            }

            var people = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                people.Add(i);
            }

            int index = 0;
            while (people.Count > 1)
            {
                index = (index + k - 1) % people.Count;
                people.RemoveAt(index);
            }

            return people[0];
        }
    }
}
