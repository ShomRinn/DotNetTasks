#pragma warning disable SA1600 // documentation
#pragma warning disable SA1201 // ElementsMustAppearInTheCorrectOrder

using System;
using System.Runtime.Intrinsics.X86;

namespace TimeStruct
{
    public readonly struct Time
    {
        /*
         public int Hours { get; }

         public int Minutes { get; }

         public Time(int minutes)
             : this(0, minutes)
         {
         }

         public Time(int hours, int minutes) => (this.Hours, this.Minutes) = NormalizeTime(hours, minutes);

         public new string ToString() => $"{this.Hours:00}:{this.Minutes:00}";

         public void Deconstruct(out int hours, out int minutes) => (hours, minutes) = (this.Hours, this.Minutes);

         private static (int, int) NormalizeTime(int hours, int minutes)
         {
             int totalMinutes = (hours * 60) + minutes;
             totalMinutes = ((totalMinutes % 1440) + 1440) % 1440;

             int normalizedHours = totalMinutes / 60;
             int normalizedMinutes = totalMinutes % 60;

             return (normalizedHours, normalizedMinutes);
         }
        */
        public int Hours { get; }

        public int Minutes { get; }

        public Time(int minutes)
            : this(0, minutes)
        {
        }

        public Time(int hours, int minutes)
        {
            int totalMinutes = (hours * 60) + minutes;
            totalMinutes = ((totalMinutes % 1440) + 1440) % 1440;
            this.Hours = totalMinutes / 60;
            this.Minutes = totalMinutes % 60;
        }

        public override string ToString()
        {
            return $"{this.Hours:00}:{this.Minutes:00}";
        }

        public void Deconstruct(out int hours, out int minutes)
        {
            hours = this.Hours;
            minutes = this.Minutes;
        }
    }
}
