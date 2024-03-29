﻿using System.Globalization;

namespace RgbConverter
{
    /// <summary>
    /// Represents a color in the RGB color model.
    /// </summary>
    public struct RgbColor : IEquatable<RgbColor>
    {
        private readonly byte red;
        private readonly byte green;
        private readonly byte blue;

        /// <summary>
        /// Initializes a new instance of the <see cref="RgbColor"/> struct with the specified <paramref name="red"/>, <paramref name="green"/> and <paramref name="blue"/> primary colors.
        /// </summary>
        /// <param name="red">A red primary color.</param>
        /// <param name="green">A green primary color.</param>
        /// <param name="blue">A blue primary color.</param>
        public RgbColor(byte red, byte green, byte blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
        }

        /// <summary>
        /// Gets a red primary color.
        /// </summary>
        public byte Red => this.red;

        /// <summary>
        /// Gets a green primary color.
        /// </summary>
        public byte Green => this.green;

        /// <summary>
        /// Gets a blue primary color.
        /// </summary>
        public byte Blue => this.blue;

        /// <summary>
        /// Compares the <paramref name="left"/> and <paramref name="right"/> objects. Returns true if the left <see cref="RgbColor"/> is equal to the right <see cref="RgbColor"/>; otherwise, false.
        /// </summary>
        /// <param name="left">A left <see cref="RgbColor"/>.</param>
        /// <param name="right">A right <see cref="RgbColor"/>.</param>
        /// <returns>true if the left <see cref="RgbColor"/> is equal to the right <see cref="RgbColor"/>; otherwise, false.</returns>
        public static bool operator ==(RgbColor left, RgbColor right) => left.red == right.red && left.green == right.green && left.blue == right.blue;

        /// <summary>
        /// Compares the <paramref name="left"/> and <paramref name="right"/> objects. Returns true if the left <see cref="RgbColor"/> is not equal to the right <see cref="RgbColor"/>; otherwise, false.
        /// </summary>
        /// <param name="left">A left <see cref="RgbColor"/>.</param>
        /// <param name="right">A right <see cref="RgbColor"/>.</param>
        /// <returns>true if the left <see cref="RgbColor"/> is not equal to the right <see cref="RgbColor"/>; otherwise, false.</returns>
        public static bool operator !=(RgbColor left, RgbColor right) => !(left == right);

        /// <summary>
        /// Converts the string representation of a color to its <see cref="RgbColor"/> equivalent.
        /// </summary>
        /// <param name="rgbString">A string containing a color to convert.</param>
        /// <returns>A <see cref="RgbColor"/> equivalent to the color contained in <paramref name="rgbString"/>.</returns>
        public static RgbColor Parse(string rgbString)
        {
            if (rgbString.Length != 6)
            {
                throw new ArgumentException("String must be 6 characters long.", nameof(rgbString));
            }

            if (!int.TryParse(rgbString, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int hexValue))
            {
                throw new ArgumentException("String must contain hex number.", nameof(rgbString));
            }

            return new RgbColor(
               Convert.ToByte(rgbString.Substring(0, 2), 16),
               Convert.ToByte(rgbString.Substring(2, 2), 16),
               Convert.ToByte(rgbString.Substring(4, 2), 16));
        }

        /// <summary>
        /// Converts the string representation of a color to its <see cref="RgbColor"/> equivalent. A return value indicates whether the operation succeeded.
        /// </summary>
        /// <param name="rgbString">A string containing a color to convert.</param>
        /// <param name="rgbColor">A <see cref="RgbColor"/> equivalent to the color contained in <paramref name="rgbString"/>.</param>
        /// <returns>true if <paramref name="rgbString"/> was converted successfully; otherwise, false.</returns>
        public static bool TryParse(string rgbString, out RgbColor rgbColor)
        {
            rgbColor = default;

            if (rgbString.Length != 6)
            {
                return false;
            }

            if (!int.TryParse(rgbString, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int hexValue))
            {
                return false;
            }

            rgbColor = Parse(rgbString);
            return true;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="RgbColor"/> struct with specified <paramref name="red"/>, <paramref name="green"/> and <paramref name="blue"/> primary colors.
        /// </summary>
        /// <param name="red">A red primary color.</param>
        /// <param name="green">A green primary color.</param>
        /// <param name="blue">A blue primary color.</param>
        /// <returns>A <see cref="RgbColor"/> that is initializes with specified <paramref name="red"/>, <paramref name="green"/> and <paramref name="blue"/> primary colors.</returns>
        public static RgbColor Create(int red, int green, int blue)
        {
            ThrowExceptionIfValueIsNotValid(red, "red");
            ThrowExceptionIfValueIsNotValid(green, "green");
            ThrowExceptionIfValueIsNotValid(blue, "blue");
            return new RgbColor((byte)red, (byte)green, (byte)blue);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="RgbColor"/> struct with specified <paramref name="red"/>, <paramref name="green"/> and <paramref name="blue"/> primary colors.
        /// </summary>
        /// <param name="red">A red primary color.</param>
        /// <param name="green">A green primary color.</param>
        /// <param name="blue">A blue primary color.</param>
        /// <returns>A <see cref="RgbColor"/> that is initializes with specified <paramref name="red"/>, <paramref name="green"/> and <paramref name="blue"/> primary colors.</returns>
        public static RgbColor Create(long red, long green, long blue)
        {
            ThrowExceptionIfValueIsNotValid(red, "red");
            ThrowExceptionIfValueIsNotValid(green, "green");
            ThrowExceptionIfValueIsNotValid(blue, "blue");
            return new RgbColor((byte)red, (byte)green, (byte)blue);
        }

        /// <summary>
        /// Determines whether the specified <see cref="RgbColor"/> is equal to the current <see cref="RgbColor"/>.
        /// </summary>
        /// <param name="other">The <see cref="RgbColor"/> to compare with the current <see cref="RgbColor"/>.</param>
        /// <returns>true if the specified <see cref="RgbColor"/> is equal to the current <see cref="RgbColor"/>; otherwise, false.</returns>
        public bool Equals(RgbColor other) => other == new RgbColor(this.red, this.green, this.blue);

        /// <summary>
        /// Determines whether the specified <see cref="RgbColor"/> is equal to the current <see cref="RgbColor"/>.
        /// </summary>
        /// <param name="obj">The object to compare with the current <see cref="RgbColor"/>.</param>
        /// <returns>true if the specified <see cref="RgbColor"/> is equal to the current <see cref="RgbColor"/>; otherwise, false.</returns>
        public override bool Equals(object? obj) => obj is RgbColor color && this.Equals(color);

        /// <summary>
        /// Returns a string that represents the current <see cref="RgbColor"/>.
        /// </summary>
        /// <returns>A string that represents the current <see cref="RgbColor"/>.</returns>
        public override string ToString() => $"{this.red:X2}{this.green:X2}{this.blue:X2}";

        /// <summary>
        /// Gets a hash code of the current <see cref="RgbColor"/>.
        /// </summary>
        /// <returns>A hash code of the current <see cref="RgbColor"/>.</returns>
        public override int GetHashCode() => (this.blue << 16) + (this.green << 8) + this.red;

        private static void ThrowExceptionIfValueIsNotValid(long value, string parametrName)
        {
            if (value < 0 || value > byte.MaxValue)
            {
                throw new ArgumentException("invalid value.", parametrName);
            }
        }
    }
}
