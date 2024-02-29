namespace IfStatements
{
    public static class Task11
    {
        public static int DoSomething(bool b1, bool b2, int i)
        {
            int result = i;

            if (b1)
            {
                if (b2 && i == 0)
                {
                    result = 1;
                }

                if (!b2 && i == 0)
                {
                    result = -1;
                }

                if (b2 && i >= 4 && i < 8)
                {
                    result = i * 2;
                }

                if (!b2 && i > 3 && i <= 7)
                {
                    result = 10 - (i * 2);
                }

                if (b2 && i < -4 && i >= -8)
                {
                    result = i * 3;
                }

                if (!b2 && i <= -3 && i > -7)
                {
                    result = 10 + (i * 3);
                }
            }

            if (!b1)
            {
                if (i == 0)
                {
                    result = 1;
                }

                if (b2 && (i < -8 || i >= 8))
                {
                    result = i - (i * i);
                }

                if (!b2 && (i <= -7 || i > 7))
                {
                    result = i - (i * i * i);
                }

                if (b2 && i != 0 && i > -4 && i <= 4)
                {
                    result = (i * i) - (i * i * i);
                }

                if (!b2 && i != 0 && i >= -3 && i < 3)
                {
                    result = (i * i * i) - (i * i);
                }
            }

            return result;
        }
    }
}
