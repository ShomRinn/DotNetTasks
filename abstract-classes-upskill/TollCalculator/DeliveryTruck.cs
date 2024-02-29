using System;

namespace TollCalculator
{
    /// <summary>
    /// Represents a delivery truck class.
    /// </summary>
    public class DeliveryTruck : Vehicle
    {
        private int myWeight;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryTruck"/> class with
        /// the specified <paramref name="baseToll"/> and <paramref name="grossWeightClass"/>.
        /// </summary>
        /// <param name="baseToll">A baseToll of this <see cref="DeliveryTruck"/> class.</param>
        /// <param name="grossWeightClass">A grossWeightClass of this <see cref="DeliveryTruck"/> class.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="baseToll"/>less than zero.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="grossWeightClass"/>less than zero.</exception>
        public DeliveryTruck(decimal baseToll, int grossWeightClass)
        {
            this.GrossWeightClass = grossWeightClass >= 0 ? grossWeightClass : throw new ArgumentOutOfRangeException(nameof(grossWeightClass), "Gross weight class cannot be negative.");
            this.BaseToll = baseToll >= 0 ? baseToll : throw new ArgumentOutOfRangeException(nameof(baseToll), "Base toll cannot be negative.");
        }

        /// <summary>
        /// Gets or sets a gross weight class.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/>less than zero.</exception>
        public int GrossWeightClass
        {
            get => this.myWeight;
            set => this.myWeight = value <= 0 ? throw new ArgumentOutOfRangeException(nameof(value)) : value;
        }

        /// <summary>
        /// Calculates the base toll that relies only on the delivery truck type.
        /// ----------------------------------------------
        /// Weight class        Extra or discount
        /// ----------------------------------------------
        /// over 5000 lbs       extra $5.00
        /// under 3000 lbs      $2.00 discount.
        /// </summary>
        /// <returns>The base toll of delivery truck.</returns>
        protected override decimal Calculate() => ((decimal)this.myWeight) switch
        {
            < 3000 => 10 - 2.0m,
            > 5000 => 10 + 5.0m,
            _ => 10
        };
    }
}
