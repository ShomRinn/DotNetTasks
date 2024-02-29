using System;
using System.Globalization;
using System.Text;

namespace ConverterDictionaryAggregation
{
    /// <summary>
    /// Converts a real number to string.
    /// </summary>
    public class Converter
    {
        private readonly CharsDictionary charsDictionary;

        /// <summary>
        /// Initializes a new instance of the <see cref="Converter"/> class.
        /// </summary>
        /// <param name="charsDictionary">The dictionary with rules of converting.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when dictionary is null.</exception>
        /// <exception cref="System.ArgumentException">Thrown when charsDictionary.Dictionary is empty.</exception>
        public Converter(CharsDictionary? charsDictionary)
        {
            if (charsDictionary == null)
            {
                throw new ArgumentNullException(nameof(charsDictionary));
            }

            if (charsDictionary.Dictionary == null)
            {
                throw new ArgumentNullException(nameof(charsDictionary));
            }

            if (charsDictionary.Dictionary.Count == 0)
            {
                throw new ArgumentException("CharsDictionary.Dictionary is empty.", nameof(charsDictionary));
            }

            this.charsDictionary = charsDictionary;
        }

        /// <summary>
        /// Converts double number into string.
        /// </summary>
        /// <param name="number">Double number to convert.</param>
        /// <returns>A number string representation.</returns>
        public string Convert(double number) =>
            number switch
            {
                double.NaN => this.charsDictionary.Dictionary![Сharacter.NaN],
                double.PositiveInfinity => this.charsDictionary.Dictionary![Сharacter.PositiveInfinity],
                double.NegativeInfinity => this.charsDictionary.Dictionary![Сharacter.NegativeInfinity],
                double.Epsilon => this.charsDictionary.Dictionary![Сharacter.Epsilon],
                _ => this.ConvertNumber(number),
            };

        private string ConvertNumber(double number)
        {
            StringBuilder result = new StringBuilder();
            string stringNumber = number.ToString(CultureInfo.GetCultureInfo(this.charsDictionary.CultureName!));

            for (int i = 0; i < stringNumber.Length; i++)
            {
                string paste = this.GetCharacter(stringNumber[i]);
                if (!string.IsNullOrEmpty(paste))
                {
                    if (result.Length > 0)
                    {
                        result.Append(' ');
                    }

                    result.Append(paste);
                }
            }

            return result.ToString();
        }

        private string GetCharacter(char c)
        {
            return c switch
            {
                '0' => this.charsDictionary.Dictionary![Сharacter.Zero],
                '1' => this.charsDictionary.Dictionary![Сharacter.One],
                '2' => this.charsDictionary.Dictionary![Сharacter.Two],
                '3' => this.charsDictionary.Dictionary![Сharacter.Three],
                '4' => this.charsDictionary.Dictionary![Сharacter.Four],
                '5' => this.charsDictionary.Dictionary![Сharacter.Five],
                '6' => this.charsDictionary.Dictionary![Сharacter.Six],
                '7' => this.charsDictionary.Dictionary![Сharacter.Seven],
                '8' => this.charsDictionary.Dictionary![Сharacter.Eight],
                '9' => this.charsDictionary.Dictionary![Сharacter.Nine],
                '+' => this.charsDictionary.Dictionary![Сharacter.Plus],
                '-' => this.charsDictionary.Dictionary![Сharacter.Minus],
                '.' => this.charsDictionary.Dictionary![Сharacter.Point],
                ',' => this.charsDictionary.Dictionary![Сharacter.Comma],
                'E' => this.charsDictionary.Dictionary![Сharacter.Exponent],
                _ => string.Empty,
            };
        }
    }
}
