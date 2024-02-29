using System;
using PseudoEnumerableTask.Interfaces;

namespace Transformers
{
    /// <summary>
    /// GetIEEE754FormatAdapter.
    /// </summary>
    /// <seealso>
    ///     <cref>PseudoEnumerableTask.Interfaces.ITransformer&amp;lt;double, string&amp;gt;</cref>
    /// </seealso>
    public class Ieee754FormatTransformer : ITransformer<double, string>
    {
        /// <summary>
        /// Represents a method that converts an object from one type to another type.
        /// </summary>
        /// <param name="obj">The object to convert.</param>
        /// <returns>
        /// The TResult that represents the converted TSource.
        /// </returns>
        public string Transform(double obj)
        {
            ulong binaryRepresentation = (ulong)BitConverter.DoubleToInt64Bits(obj);
            string signBinaryString = (int)((binaryRepresentation >> 63) & 0x01) == 1 ? "1" : "0";
            string exponentBinaryString = Convert.ToString((int)((binaryRepresentation >> 52) & 0x7FF), 2).PadLeft(11, '0');
            string mantissaBinaryString = Convert.ToString((long)binaryRepresentation & 0xFFFFFFFFFFFFFL, 2).PadLeft(52, '0');

            return string.Concat(signBinaryString, exponentBinaryString, mantissaBinaryString);
        }
    }
}
