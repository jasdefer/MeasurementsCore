using System;

namespace Measurements
{
    public class Velocity
    {
        /// <summary>
        /// Distance per second
        /// </summary>
        private readonly Distance Distance;

        /// <summary>
        /// Initializes a new instance of the Velocity structure to the specified distance per second.
        /// </summary>
        public Velocity(Distance distance)
        {
            Distance = distance;
        }

        public Velocity(int metersPerSecond) : this(new Distance(metersPerSecond)) { }

        public Velocity(Distance distance, TimeSpan deltaTime)
        {
            Distance = new Distance(distance.Millimeters/(deltaTime.Ticks*TimeSpan.TicksPerSecond));
        }

        public TimeSpan GetDuration(Distance distance)
        {
            if (distance.Millimeters == 0) return new TimeSpan();
            return TimeSpan.FromTicks(TimeSpan.TicksPerSecond * distance.Meters / Distance.Meters);
        }

        public static TimeSpan operator /(Distance distance, Velocity velocity)
        {
            return TimeSpan.FromTicks(TimeSpan.TicksPerSecond * distance.Meters / velocity.Distance.Meters);
        }

        public static bool operator <(Velocity v1, Velocity v2)
        {
            return v1.Distance.Millimeters < v2.Distance.Millimeters;
        }

        public static bool operator <=(Velocity v1, Velocity v2)
        {
            return v1.Distance.Millimeters <= v2.Distance.Millimeters;
        }

        public static bool operator >(Velocity v1, Velocity v2)
        {
            return v1.Distance.Millimeters > v2.Distance.Millimeters;
        }

        public static bool operator >=(Velocity v1, Velocity v2)
        {
            return v1.Distance.Millimeters >= v2.Distance.Millimeters;
        }

        public static bool operator ==(Velocity v1, Velocity v2)
        {
            return v1.Distance.Millimeters == v2.Distance.Millimeters;
        }

        public static bool operator !=(Velocity v1, Velocity v2)
        {
            return v1.Distance.Millimeters != v2.Distance.Millimeters;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Velocity)) return false;
            return Distance.Millimeters == ((Distance)obj).Millimeters;
        }

        public override int GetHashCode()
        {
            return Distance.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Distance.Meters}m/s";
        }
    }
}