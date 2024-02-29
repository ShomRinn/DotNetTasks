namespace Loop1Tasks
{
    public static class Tasks
    {
        public static int Task(int n, int m)
        {
            int sum = 0;

            for (int i = n; i <= m; i++)
            {
                if (i % 2 != 0)
                {
                    sum += i;
                }
            }

            return sum;
        }
    }
}
