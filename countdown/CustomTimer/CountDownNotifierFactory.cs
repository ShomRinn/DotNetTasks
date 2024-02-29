using System;
using System.Threading;
#pragma warning disable S1118
#pragma warning disable CA1822

namespace CustomTimer
{
    /// <summary>
    /// A factory class for creating CountDownNotifier instances.
    /// </summary>
    public class CountDownNotifierFactory
    {
        /// <summary>
        /// Creates a new CountDownNotifier instance for the specified timer.
        /// </summary>
        /// <param name="timer">The timer to be associated with the notifier.</param>
        /// <returns>The created CountDownNotifier instance.</returns>
        public CountDownNotifier CreateNotifierForTimer(Timer timer)
        {
            if (timer == null)
            {
                throw new ArgumentNullException(nameof(timer), "Timer can't be null");
            }

            return new CountDownNotifier(timer);
        }
    }
}
