using System;

namespace TollCalculator
{
    /// <summary>
    /// Represents a bus class.
    /// </summary>
    public class Bus : Vehicle
    {
        private int myPassengers;
        private int myCapacity;

        /// <summary>
        /// Initializes a new instance of the <see cref="Bus"/> class with the specified the base toll, capacity and passengers.
        /// </summary>
        /// <param name="basicToll">A toll of this <see cref="Bus"/> class.</param>
        /// <param name="capacity">A capacity of this <see cref="Bus"/> class.</param>
        /// <param name="passengers">A passengers of this <see cref="Bus"/> class.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="basicToll"/>less than zero.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="capacity"/>less than or equals zero.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="passengers"/>less than zero.</exception>
        public Bus(decimal basicToll, int capacity, int passengers)
        {
            this.BaseToll = basicToll >= 0 ? basicToll : throw new ArgumentOutOfRangeException(nameof(basicToll), "Toll cannot be negative.");
            this.Capacity = capacity > 0 ? capacity : throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be positive.");
            this.Passengers = passengers >= 0 ? passengers : throw new ArgumentOutOfRangeException(nameof(passengers), "Passengers cannot be negative.");
        }

        /// <summary>
        /// Gets or sets the capacity of this <see cref="Bus"/> class.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/>less than zero.</exception>
        public int Capacity
        {
            get => this.myCapacity;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Capacity must be positive.");
                }

                this.myCapacity = value;
            }
        }

        /// <summary>
        /// Gets or sets the passengers of this <see cref="Bus"/> class.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/>less than zero.</exception>
        public int Passengers
        {
            get => this.myPassengers;
            set => this.myPassengers = value < 0 ? throw new ArgumentOutOfRangeException(nameof(value), "Passengers cannot be negative.") : value;
        }

        /// <summary>
        /// Calculates the base toll that relies only on the bus type.
        /// ----------------------------------------------
        /// Passenger filling in %      Extra or discount
        /// ----------------------------------------------
        /// less than 50%               extra $2.00
        /// more than 90%               $1.00 discount.
        /// </summary>
        /// <returns>The base toll of bus.</returns>
        protected override decimal Calculate() => ((double)this.Passengers / this.Capacity) switch
        {
            < 0.50 => this.BaseToll + 2.0m,
            > 0.90 => this.BaseToll - 1.0m,
            _ => this.BaseToll
        };
    }
}
