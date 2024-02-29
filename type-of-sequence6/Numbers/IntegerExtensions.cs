using System;

namespace Numbers
{
    public static class IntegerExtensions
    {
        /// <summary>
        /// Obtains formalized information in the form of an enum <see cref="ComparisonSigns"/>
        /// about the relationship of the order of two adjacent digits for all digits of a given number.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>Information in the form of an enum <see cref="ComparisonSigns"/>
        /// about the relationship of the order of two adjacent digits for all digits of a given number
        /// or null if the information is not defined.</returns>
        public static ComparisonSigns? GetTypeComparisonSigns(this long number)
        {
            ComparisonSigns? comparison = null;
            if (number == long.MinValue)
            {
                return ComparisonSigns.LessThan | ComparisonSigns.MoreThan | ComparisonSigns.Equals;
            }

            number = Math.Abs(number);
            string strNumber = number.ToString();
            int k = 0, k2 = 0, k3 = 0;
            for (int i = 0; i < strNumber.Length - 1; i++)
            {
                int currDigit = int.Parse(strNumber[i].ToString());
                int nextDigit = int.Parse(strNumber[i + 1].ToString());

                if (currDigit < nextDigit)
                {
                    k++;
                    comparison = ComparisonSigns.LessThan;
                }

                if (currDigit > nextDigit)
                {
                    k2++;
                    comparison = ComparisonSigns.MoreThan;
                }

                if (currDigit == nextDigit)
                {
                    k3++;
                    comparison = ComparisonSigns.Equals;
                }
            }

            if (k > 0 && k2 > 0 && k3 > 0)
            {
                comparison = ComparisonSigns.LessThan | ComparisonSigns.MoreThan | ComparisonSigns.Equals;
            }

            if (k > 0 && k2 > 0 && k3 == 0)
            {
                comparison = ComparisonSigns.LessThan | ComparisonSigns.MoreThan;
            }

            if (k > 0 && k2 == 0 && k3 > 0)
            {
                comparison = ComparisonSigns.LessThan | ComparisonSigns.Equals;
            }

            if (k == 0 && k2 > 0 && k3 > 0)
            {
                comparison = ComparisonSigns.MoreThan | ComparisonSigns.Equals;
            }

            return comparison;
        }

        /// <summary>
        /// Gets information in the form of a string about the type of sequence that the digit of a given number represents.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The information in the form of a string about the type of sequence that the digit of a given number represents.</returns>
        public static string GetTypeOfDigitsSequence(this long number)
        {
            if (number == long.MinValue)
            {
                return "Unordered.";
            }

            int monotonous = 0, strictlyIncreasing = 0, strictlyDecreasing = 0, decreasing = 0, increasing = 0;
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
                    monotonous++;
                }

                if ((lastDigit > nextDigit) && (lastDigit - nextDigit == 1))
                {
                    strictlyIncreasing++;
                }

                if (lastDigit >= nextDigit)
                {
                    increasing++;
                }

                if ((lastDigit < nextDigit) && (nextDigit - lastDigit == 1))
                {
                    strictlyDecreasing++;
                }

                if (lastDigit <= nextDigit)
                {
                    decreasing++;
                }
            }

            if (monotonous == k)
            {
                return "Monotonous.";
            }

            if (strictlyIncreasing == k)
            {
                return "Strictly Increasing.";
            }

            if (increasing == k && strictlyIncreasing < k)
            {
                return "Increasing.";
            }

            if (strictlyDecreasing == k)
            {
                return "Strictly Decreasing.";
            }

            if (decreasing == k && strictlyDecreasing < k)
            {
                return "Decreasing.";
            }

            return "Unordered.";
        }
    }
}
