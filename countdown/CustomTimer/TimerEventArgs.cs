using System;
using System.Threading;

namespace CustomTimer
{
    /// <summary>
    /// A custom class for simulating a countdown clock, which implements the ability to send messages and additional
    /// information about the Started, Tick, and Stopped events to any types that are subscribing to the specified events.
    /// - When creating a Timer object, it must be assigned:
    ///     - name (not null or empty string, otherwise an ArgumentException will be thrown);
    ///     - the number of ticks (the number must be greater than 0, otherwise an exception will throw an ArgumentException).
    /// - After the timer has been created, it should fire the Started event, which contains information about
    /// the name of the timer and the number of ticks to start.
    /// - After starting the timer, it fires Tick events, which contain information about the name of the timer and
    /// the number of ticks left for triggering. There should be delays between Tick events, and the delays are modeled by Thread.Sleep.
    /// - After all Tick events are triggered, the timer should start the Stopped event, which contains information about
    /// the name of the timer.
    /// </summary>
    public class TimerEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the name of the timer.
        /// </summary>
        public string? TimerName { get; set; }

        /// <summary>
        /// Gets or sets the number of ticks left for triggering.
        /// </summary>
        public int TicksLeft { get; set; }
    }
}
