using System.Runtime.InteropServices;

namespace Exceptions
{
    public static class ThrowingArgumentNull
    {
        public static bool CheckParameterAndThrowException1(object o)
        {
            if (o == null)
            {
                throw new ArgumentNullException(nameof(o));
            }

            // TODO 2-1. Add the code to throw the ArgumentNullException if the o argument is null.
            return true;
        }

        public static bool CheckParametersAndThrowException2(object o1, object o2)
        {
            if (o1 == null)
            {
                throw new ArgumentNullException(nameof(o1));
            }

            if (o2 == null)
            {
                throw new ArgumentNullException(nameof(o2));
            }

            return true;
        }

        public static int CheckParametersAndThrowException3(int[] integers, long[] longs, float[] floats)
        {
            if (integers == null)
            {
                throw new ArgumentNullException(nameof(integers));
            }

            if (longs == null)
            {
                throw new ArgumentNullException(nameof(longs));
            }

            if (floats == null)
            {
                throw new ArgumentNullException(nameof(floats));
            }

            return integers.Length + longs.Length + floats.Length;
        }

        public static int CheckParameterAndThrowException4(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            return s.Length;
        }

        public static int CheckParametersAndThrowException5(string s1, string s2)
        {
            if (s1 == null)
            {
                throw new ArgumentNullException(nameof(s1));
            }

            if (s2 == null)
            {
                throw new ArgumentNullException(nameof(s2));
            }

            return s1.Length + s2.Length;
        }

        public static int CheckParametersAndThrowException6(string s, int[] integers, string[] strings)
        {
            if (integers == null)
            {
                throw new ArgumentNullException(nameof(integers));
            }

            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            if (strings == null)
            {
                throw new ArgumentNullException(nameof(strings));
            }

            return s.Length + integers.Length + strings.Length;
        }

        public static int CheckParameterAndThrowException7(int[] integers)
        {
            int integersCount;

            if (integers == null)
            {
                throw new ArgumentNullException(nameof(integers));
            }

            integersCount = integers.Length;

            return integersCount;
        }

        public static int CheckParametersAndThrowException8(int[] integers, string s)
        {
            int integersCount, stringLength;

            if (integers == null)
            {
                throw new ArgumentNullException(nameof(integers));
            }

            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            integersCount = integers.Length;
            stringLength = s.Length;

            return integersCount + stringLength;
        }

        public static int CheckParametersAndThrowException9(float[] floats, string s1, double[] doubles, string s2)
        {
            int floatsCount, s1Length, doublesCount, s2Length;

            if (floats == null)
            {
                throw new ArgumentNullException(nameof(floats));
            }

            if (s1 == null)
            {
                throw new ArgumentNullException(nameof(s1));
            }

            if (doubles == null)
            {
                throw new ArgumentNullException(nameof(doubles));
            }

            if (s2 == null)
            {
                throw new ArgumentNullException(nameof(s2));
            }

            floatsCount = floats.Length;
            doublesCount = doubles.Length;
            s1Length = s1.Length;
            s2Length = s2.Length;

            return floatsCount + s1Length + doublesCount + s2Length;
        }
    }
}
