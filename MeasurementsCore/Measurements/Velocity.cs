﻿using System;

namespace Measurements
{
    public class Velocity
    {
        /// <summary>
        /// Distance per second
        /// </summary>
        private readonly Distance Distance;

        /// <summary>
        /// Initializes a new instance of the velocity structure to the specified distance per second.
        /// </summary>
        public Velocity(Distance distance)
        {
            Distance = distance;
        }

        /// <summary>
        /// Initializes a new instance of the velocity structure to the specified distance in meters per second.
        /// </summary>
        /// <param name="metersPerSecond">The distance in meters per second.</param>
        public Velocity(int metersPerSecond) : this(new Distance(metersPerSecond)) { }

        /// <summary>
        /// Initializes a new instance of the velocity structure to the specified distance in the specified time.
        /// </summary>
        /// <param name="distance">The distance part of the velocity.</param>
        /// <param name="deltaTime">The timespam part of the velocity.</param>
        public Velocity(Distance distance, TimeSpan deltaTime)
        {
            Distance = new Distance(distance.Millimeters/(deltaTime.Ticks*TimeSpan.TicksPerSecond));
        }

        /// <summary>
        /// Get the timespan needed to cover the specified distance with this velocity.
        /// </summary>
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