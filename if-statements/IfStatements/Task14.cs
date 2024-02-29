namespace IfStatements
{
    public static class Task14
    {
        public static int DoSomething(bool b1, bool b2, int i)
        {
            int result = i;
            if (b1)
            {
                if (b2)
                {
                    if (i <= -5)
                    {
                        result = 10 - (i * 2);
                    }

                    if (i > -5 && i <= 5)
                    {
                        result = i * (-2);
                    }

                    if (i > 5)
                    {
                        result = 10 - (i * 2);
                    }
                }

                if (!b2)
                {
                    if (i <= -5)
                    {
                        result = i * i * i;
                    }

                    if (i > -5 && i <= 5)
                    {
                        result = i * i;
                    }

                    if (i > 5)
                    {
                        result = i * i * i;
                    }
                }
            }

            if (!b1)
            {
                if (b2)
                {
                    if (i < -9)
                    {
                        result = i * (-1);
                    }

                    if (i >= -9 && i < -7)
                    {
                        result = i;
                    }

                    if (i >= -7 && i < -3)
                    {
                        result = i * 10;
                    }

                    if (i >= -3 && i <= 7)
                    {
                        result = i;
                    }

                    if (i > 7)
                    {
                        result = i * (-1);
                    }
                }

                if (!b2)
                {
                    if (i < -9)
                    {
                        result = i * (-1);
                    }

                    if (i >= -9 && i < -3)
                    {
                        result = i;
                    }

                    if (i >= -3 && i < 0)
                    {
                        result = i * (-100);
                    }

                    if (i == 0)
                    {
                        result = 0;
                    }

                    if (i > 0 && i < 5)
                    {
                        result = i * (-100);
                    }

                    if (i >= 5 && i <= 7)
                    {
                        result = i;
                    }

                    if (i > 7)
                    {
                        result = i * (-1);
                    }
                }
            }

            return result;
        }
    }
}
