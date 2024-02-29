using System;
using System.Threading;
#pragma warning disable CA1822
#pragma warning disable SA1204

namespace CustomTimer
{
    /// <summary>
    /// A factory class for creating Timer and CountDownNotifier instances.
    /// </summary>
    public class TimerFactory
    {
        /// <summary>
        /// Creates a new Timer instance.
        /// </summary>
        /// <param name="timerName">The name of the timer.</param>
        /// <param name="ticks">The number of ticks for the timer.</param>
        /// <returns>The created Timer instance.</returns>
        public Timer CreateTimer(string timerName, int ticks)
        {
            return new Timer(timerName, ticks);
        }

        /// <summary>
        /// Creates a new CountDownNotifier instance.
        /// </summary>
        /// <param name="timer">The timer to be associated with the notifier.</param>
        /// <returns>The created CountDownNotifier instance.</returns>
        public static CountDownNotifier CreateCountDownNotifier(Timer timer)
        {
            return new CountDownNotifier(timer);
        }
    }
}
