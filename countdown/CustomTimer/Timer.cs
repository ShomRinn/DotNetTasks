using System;
using System.Threading;
#pragma warning disable SA1201
#pragma warning disable S1450

namespace CustomTimer
{
    /// <summary>
    /// Represents a countdown timer.
    /// </summary>
    public class Timer
    {
        private readonly string timerName;
        private readonly int ticks;
        private int currentTicks;

        /// <summary>
        /// Event that is fired when the timer starts.
        /// </summary>
        public event EventHandler<TimerEventArgs>? Started;

        /// <summary>
        /// Event that is fired on each tick of the timer.
        /// </summary>
        public event EventHandler<TimerEventArgs>? Tick;

        /// <summary>
        /// Event that is fired when the timer stops.
        /// </summary>
        public event EventHandler<TimerEventArgs>? Stopped;

        /// <summary>
        /// Initializes a new instance of the <see cref="Timer"/> class.
        /// </summary>
        /// <param name="timerName">The name of the timer.</param>
        /// <param name="ticks">The number of ticks for the timer.</param>
        public Timer(string timerName, int ticks)
        {
            if (string.IsNullOrWhiteSpace(timerName))
            {
                throw new ArgumentException("Timer name must be a non-empty string.");
            }

            if (ticks <= 0)
            {
                throw new ArgumentException("Number of ticks must be greater than zero.");
            }

            this.timerName = timerName;
            this.ticks = ticks;
        }

        /// <summary>
        /// Runs the timer.
        /// </summary>
        public void Run()
        {
            this.currentTicks = this.ticks;

            this.Started?.Invoke(this, new TimerEventArgs { TimerName = this.timerName, TicksLeft = this.currentTicks });

            while (this.currentTicks > 0)
            {
                Thread.Sleep(1000);
                this.currentTicks--;

                this.Tick?.Invoke(this, new TimerEventArgs { TimerName = this.timerName, TicksLeft = this.currentTicks });
            }

            this.Stopped?.Invoke(this, new TimerEventArgs { TimerName = this.timerName });
        }
    }
}
