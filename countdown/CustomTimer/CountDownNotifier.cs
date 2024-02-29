using System;
using System.Threading;
#pragma warning disable CS8622

namespace CustomTimer
{
    /// <summary>
    /// Notifier class that handles events from a Timer instance.
    /// </summary>
    public class CountDownNotifier
    {
        private readonly Timer timer;
        private Action<string, int>? onStart;
        private Action<string>? onStop;
        private Action<string, int>? onTick;

        /// <summary>
        /// Initializes a new instance of the <see cref="CountDownNotifier"/> class.
        /// </summary>
        /// <param name="timer">The timer to be associated with the notifier.</param>
        public CountDownNotifier(Timer timer)
        {
            this.timer = timer ?? throw new ArgumentNullException(nameof(timer));

            this.timer.Started += this.TimerStarted;
            this.timer.Tick += this.TimerTick;
            this.timer.Stopped += this.TimerStopped;
        }

        /// <summary>
        /// Initializes the callback actions for the notifier.
        /// </summary>
        /// <param name="onStart">The action to be called when the timer starts.</param>
        /// <param name="onStop">The action to be called when the timer stops.</param>
        /// <param name="onTick">The action to be called on each tick of the timer.</param>
        public void Init(Action<string, int> onStart, Action<string> onStop, Action<string, int> onTick)
        {
            this.onStart = onStart;
            this.onStop = onStop;
            this.onTick = onTick;
        }

        /// <summary>
        /// Runs the timer associated with the notifier.
        /// </summary>
        public void Run()
        {
            this.timer.Run();
        }

        private void TimerStarted(object sender, TimerEventArgs e)
        {
            this.onStart?.Invoke(e.TimerName!, e.TicksLeft);
        }

        private void TimerTick(object sender, TimerEventArgs e)
        {
            this.onTick?.Invoke(e.TimerName!, e.TicksLeft);
        }

        private void TimerStopped(object sender, TimerEventArgs e)
        {
            this.onStop?.Invoke(e.TimerName!);
        }
    }
}
