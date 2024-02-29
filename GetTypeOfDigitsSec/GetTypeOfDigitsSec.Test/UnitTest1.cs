global using NUnit.Framework;
using System.Threading.Tasks;

namespace GetTypeOfDigitsSec.Test
{
    public class Tests
    {
        [Test]
        public void GetTypeOfDigitSequence_()
        {
            Assert.Throws<ArgumentException>(() => GetTypeOfDigitsSequance(-1L), message: "One digit number.");
            Assert.Throws<ArgumentException>(() => GetTypeOfDigitsSequance(23456789L), message: "Strictly Increasing.");
            Assert.Throws<ArgumentException>(() => GetTypeOfDigitsSequance(long.MinValue), message: "Unordered.");
            Assert.Throws<ArgumentException>(() => GetTypeOfDigitsSequance(long.MaxValue), message: "Unordered.");
            Assert.Throws<ArgumentException>(() => GetTypeOfDigitsSequance(9876543210L), message: "Strictly Decreasing.");
            Assert.Throws<ArgumentException>(() => GetTypeOfDigitsSequance(111111111111111L), message: "Monotonous.");
            Assert.Throws<ArgumentException>(() => GetTypeOfDigitsSequance(8765432110L), message: "Decreasing.");
            Assert.Throws<ArgumentException>(() => GetTypeOfDigitsSequance(11234567889L), message: "Increasing.");
            Assert.Throws<ArgumentException>(() => GetTypeOfDigitsSequance(1L), message: "One digit number.");
        }

            private void GetTypeOfDigitsSequance(long number)
            {
            if (number == long.MinValue)
            {
                throw new ArgumentException("Unordered.");
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
                throw new ArgumentException("One digit number.")    ;
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
                throw new ArgumentException("Monotonous.");
            }
            if (StrictlyIncreasing == k)
            {
                throw new ArgumentException("StrictlyIncreasing.");
            }
            if (Increasing == k && StrictlyIncreasing < k)
            {
                throw new ArgumentException("Increasing.");
            }
            if (StrictlyDecreasing == k)
            {
                throw new ArgumentException("StrictlyDecreasing.");
            }
            if (Decreasing == k && StrictlyDecreasing < k)
            {
                throw new ArgumentException("Decreasing.");
            }
            throw new ArgumentException("Unordered.");
            }
    }
}