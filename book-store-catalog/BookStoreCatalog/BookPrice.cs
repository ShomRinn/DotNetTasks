using System;
using System.Globalization;

namespace BookStoreCatalog
{
    /// <summary>
    /// Represents a book price.
    /// </summary>
    public class BookPrice
    {
        private decimal amount;
        private string currency;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookPrice"/> class.
        /// </summary>
        public BookPrice()
            : this(0, "USD")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookPrice"/> class with specified <paramref name="amount"/> and <paramref name="currency"/>.
        /// </summary>
        /// <param name="amount">An amount of money of a book.</param>
        /// <param name="currency">A price currency.</param>
        public BookPrice(decimal amount, string currency)
        {
            ThrowExceptionIfCurrencyIsNotValid(currency, nameof(currency));
            ThrowExceptionIfAmountIsNotValid(amount, nameof(amount));
            this.Amount = amount;
            this.Currency = currency;
        }

        /// <summary>
        /// Gets or sets an amount of money that a book costs.
        /// </summary>
        public decimal Amount
        {
            get => this.amount;
            set
            {
                ThrowExceptionIfAmountIsNotValid(value, nameof(value));
                this.amount = value;
            }
        }

        /// <summary>
        /// Gets or sets a book price currency.
        /// </summary>
        public string Currency
        {
            get => this.currency;
            set
            {
                ThrowExceptionIfCurrencyIsNotValid(value, nameof(value));
                this.currency = value;
            }
        }

        /// <summary>
        /// Returns the string that represents a current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0:N2} {1}", this.amount, this.currency);
        }

        private static void ThrowExceptionIfAmountIsNotValid(decimal amount, string parameterName)
        {
            if (amount < 0)
            {
                throw new ArgumentException("amount is less then zero.", parameterName);
            }
        }

        private static void ThrowExceptionIfCurrencyIsNotValid(string currency, string parameterName)
        {
            if (currency is null)
            {
                throw new ArgumentNullException(parameterName, "currency is not valid.");
            }

            if (currency.Length != 3)
            {
                throw new ArgumentException("currency length must be equal to 3", parameterName);
            }

            for (int i = 0; i < currency.Length; i++)
            {
                if (!char.IsLetter(currency[i]))
                {
                    throw new ArgumentException("each currency character must be a letter.", parameterName);
                }
            }
        }
    }
}
