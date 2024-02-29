namespace Ieee754FormatTask
{
    /// <summary>
    /// Double extension class.
    /// </summary>
    public static class DoubleExtension
    {
        /// <summary>
        /// Returns a string representation of a double type number
        /// in the IEEE754 (see https://en.wikipedia.org/wiki/IEEE_754) format.
        /// </summary>
        /// <param name="number">Input number.</param>
        /// <returns>A string representation of a double type number in the IEEE754 format.</returns>
        public static string GetIEEE754Format(this double number)
        {
            long binaryRepresentation = DoubleToInt64Bits(number);

            int sign = (int)((binaryRepresentation >> 63) & 0x01);
            int exponent = (int)((binaryRepresentation >> 52) & 0x7FF);
            long mantissa = binaryRepresentation & 0xFFFFFFFFFFFFFL;

            string signBinaryString = sign == 1 ? "1" : "0";
            string exponentBinaryString = IntToStringBinary(exponent, 11);
            string mantissaBinaryString = LongToStringBinary(mantissa, 52);

            string ieee754Format = $"{signBinaryString}{exponentBinaryString}{mantissaBinaryString}";

            return ieee754Format;
        }

        private static unsafe long DoubleToInt64Bits(double value)
        {
            long result = 0;
            byte* bytePtr = (byte*)&value;

            for (int i = 0; i < sizeof(double); i++)
            {
                result |= ((long)*bytePtr) << (8 * i);
                bytePtr++;
            }

            return result;
        }

        private static string IntToStringBinary(int value, int length)
        {
            char[] bits = new char[length];
            int bitIndex = length - 1;

            for (int i = 0; i < length; i++)
            {
                bits[bitIndex] = (value & 1) == 1 ? '1' : '0';
                value >>= 1;
                bitIndex--;
            }

            return new string(bits);
        }

        private static string LongToStringBinary(long value, int length)
        {
            char[] bits = new char[length];
            int bitIndex = length - 1;

            for (int i = 0; i < length; i++)
            {
                bits[bitIndex] = (value & 1) == 1 ? '1' : '0';
                value >>= 1;
                bitIndex--;
            }

            return new string(bits);
        }
    }
}
