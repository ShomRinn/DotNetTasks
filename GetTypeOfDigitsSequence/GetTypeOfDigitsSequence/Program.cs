using System;

namespace TypeOfTheSequenceTask
{
    public static class GetTypeOfTheSequence
    {
        public static string GetTypeOfDigitSequence(long number)
        {
            if (number == long.MinValue)
            {
                return "Unordered.";
            }
            int Monotonous = 0, StrictlyIncreasing = 0, StrictlyDecreasing = 0, Decreasing = 0, Increasing = 0;
            number = Math.Abs(number);
            long num1 = number;
            int k = 0, k1;
            while (num1 > 0)
            {
                k++;
                num1 /= 10;
            }
            k1 = k - 1;
            k = k - 1;
            if (number >= 0L && number < 10L)
            {

                return "One digit number.";
            }

            while (k1 > 0)
            {
                k1--;
                long lastDigit = number % 10;
                number /= 10;
                long nextDigit = number % 10;

                if (lastDigit == nextDigit)
                {
                    Monotonous++;
                }
                if ((lastDigit > nextDigit) && (lastDigit - nextDigit == 1))
                {
                    StrictlyIncreasing++;
                }
                if (lastDigit >= nextDigit)
                {
                    Increasing++;
                }
                if ((lastDigit < nextDigit) && (nextDigit - lastDigit == 1))
                {
                    StrictlyDecreasing++;
                }
                if (lastDigit <= nextDigit)
                {
                    Decreasing++;
                }
            }
            if (Monotonous == k)
            {
                return "Monotonous.";
            }
            if (StrictlyIncreasing == k)
            {
                return "StrictlyIncreasing.";
            }
            if (Increasing == k && StrictlyIncreasing < k)
            {
                return "Increasing.";
            }
            if (StrictlyDecreasing == k)
            {
                return "StrictlyDecreasing.";
            }
            if (Decreasing == k && StrictlyDecreasing < k)
            {
                return "Decreasing.";
            }

            return "Unordered.";
        }


    }
}