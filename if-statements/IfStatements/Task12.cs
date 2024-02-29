namespace IfStatements
{
    public static class Task12
    {
        public static int DoSomething(int i)
        {
            int result = i;

            if (i <= -8)
            {
                result = i * i;
            }

            if (i >= -8 && i < -5)
            {
            result = i;
            }

            if (i >= -5 && i < 5)
            {
                result = (i * i) - i;
            }

            if (i >= 5 && i < 10)
            {
                result = i;
            }

            if (i >= 10)
            {
                result = 0 - (i * i);
            }

            return result;
        }
    }
}
