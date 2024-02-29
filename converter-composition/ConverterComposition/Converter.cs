using System;
using System.Globalization;
using System.Text;

namespace ConverterComposition
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
        /// <param name="dictionaryFactory">Factory of the dictionary with rules of converting.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when dictionary factory is null.</exception>
        public Converter(ICharsDictionaryFactory? dictionaryFactory)
        {
            if (dictionaryFactory == null)
            {
                throw new ArgumentNullException(nameof(dictionaryFactory));
            }

            this.charsDictionary = dictionaryFactory.CreateDictionary();
        }

        /// <summary>
        /// Converts double number into string.
        /// </summary>
        /// <param name="number">Double number to convert.</param>
        /// <returns>A number string representation.</returns>
        public string Convert(double number)
        {
            var specialNumbers = new Dictionary<double, Character>
            {
            { double.NaN, Character.NaN },
            { double.PositiveInfinity, Character.PositiveInfinity },
            { double.NegativeInfinity, Character.NegativeInfinity },
            { double.Epsilon, Character.Epsilon },
            };

            if (specialNumbers.ContainsKey(number))
            {
                return this.charsDictionary.Dictionary![specialNumbers[number]];
            }

            return this.ConvertNumber(number);
        }

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
                '0' => this.charsDictionary.Dictionary![Character.Zero],
                '1' => this.charsDictionary.Dictionary![Character.One],
                '2' => this.charsDictionary.Dictionary![Character.Two],
                '3' => this.charsDictionary.Dictionary![Character.Three],
                '4' => this.charsDictionary.Dictionary![Character.Four],
                '5' => this.charsDictionary.Dictionary![Character.Five],
                '6' => this.charsDictionary.Dictionary![Character.Six],
                '7' => this.charsDictionary.Dictionary![Character.Seven],
                '8' => this.charsDictionary.Dictionary![Character.Eight],
                '9' => this.charsDictionary.Dictionary![Character.Nine],
                '+' => this.charsDictionary.Dictionary![Character.Plus],
                '-' => this.charsDictionary.Dictionary![Character.Minus],
                '.' => this.charsDictionary.Dictionary![Character.Point],
                ',' => this.charsDictionary.Dictionary![Character.Comma],
                'E' => this.charsDictionary.Dictionary![Character.Exponent],
                _ => string.Empty,
            };
        }
    }
}
