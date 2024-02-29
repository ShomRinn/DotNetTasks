namespace GetTypeOfDigits
{
    using System;

    public static class GetTypeOfDigitsSequence
    {
        static long num = 123456;
        public static string GetTypeOfDigitsSequence(long number)
        {
            if (number >= 0L && number < 10L)
            {
                return "One digit number.";
            }

            static string GetMonotonousOfDigitsSequence(long number)
            {
                if (number >= 0L && number < 10L)
                {
                    return "Monotonous.";
                }
                long lastDigit = number % 10;
                number /= 10;
                long nextDigit = number % 10;

                if (lastDigit == nextDigit)
                {
                    GetMonotonousOfDigitsSequence(number);
                }
                else
                {
                    return "aboba";
                }
                return "aboba";
            }
        }
    }
}