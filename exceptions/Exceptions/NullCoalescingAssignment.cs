namespace Exceptions
{
    public static class NullCoalescingAssignment
    {
        public static object CheckParameterAndThrowException1(object o)
        {
            if (o == null)
            {
                return new object();
            }
            else
            {
                return o;
            }
        }

        public static int[] CheckParameterAndThrowException2(int[] integers)
        {
            return integers == null ? new int[] { 0 } : integers;
        }

        public static string CheckParameterAndThrowException3(string s)
        {
            s ??= "Hello, world!";
            return s;
        }

        public static string CheckParametersAndThrowException4(string s1, string s2)
        {
            s1 ??= "Hello";
            s2 ??= "world";

            return $"{s1}, {s2}!";
        }

        public static string CheckParametersAndThrowException5(string s1, int[] integers, string s2)
        {
            s1 ??= "abc";
            integers ??= new int[] { 0, 1, 2 };
            s2 ??= "123";

            int count = integers.Length;
            return $"{s1}{count}{s2}";
        }
    }
}
