namespace IfStatements
{
    public static class Task4
    {
        public static bool DoSomething1(bool b1, bool b2)
        {
            bool result = false;
            if (b1 && b2)
            {
                result = false;
            }

            if (b1 ^ b2)
            {
                result = true;
            }

            return result;
        }

        public static bool DoSomething2(bool b1, bool b2)
        {
            bool result = false;
            if (b1 is true && b2 is true)
            {
                result = false;
            }

            if (b1 is true ^ b2 is true)
            {
                result = true;
            }

            return result;
        }
    }
}
