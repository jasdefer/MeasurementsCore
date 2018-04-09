using System;

namespace Measurements
{
    public struct Velocity
    {
        public const int MaxMetersPerSecond = 299792458;
        public static readonly Velocity SpeedOfLight = new Velocity(MaxMetersPerSecond);

        /// <summary>
        /// Distance per second
        /// </summary>
        private readonly Distance distance;

        /// <summary>
        /// Initializes a new instance of the velocity structure to the specified distance per second.
        /// </summary>
        public Velocity(Distance distance)
        {
            if (distance.Meters > MaxMetersPerSecond) throw new ArgumentOutOfRangeException(nameof(distance));
            this.distance = distance;
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
            //Ensure that the distances calculation does not exceed the long.MaxValue limit
            if (distance.Millimeters > long.MaxValue / TimeSpan.TicksPerSecond)
            {
                throw new ArgumentOutOfRangeException(nameof(distance),"The distance is to large. Consider decreasing the distance as well as the delta time.");
            }

            this.distance = new Distance(TimeSpan.TicksPerSecond*distance.Millimeters/ deltaTime.Ticks );
            if (this > SpeedOfLight) throw new ArgumentOutOfRangeException(nameof(distance));
        }

        /// <summary>
        /// Get the velocity in meters per second.
        /// </summary>
        public int MetersPerSecond => distance.Meters;

        /// <summary>
        /// Get the velocity in the distance per second.
        /// </summary>
        public Distance DistancePerSecond => distance;

        /// <summary>
        /// Get the timespan needed to cover the specified distance with this velocity.
        /// </summary>
        public TimeSpan GetDuration(Distance distance)
        {
            if (distance.Millimeters == 0) return new TimeSpan();
            else if (this.distance.Millimeters == 0) throw new Exception("A velocity of 0 m/s cannot cover any distances greater than 0.");

            //Ensure that the duration calculation does not exceed the long.MaxValue limit
            if (distance.Millimeters> long.MaxValue / TimeSpan.TicksPerSecond)
            {
                throw new ArgumentOutOfRangeException(nameof(distance));
            }
            return TimeSpan.FromTicks(TimeSpan.TicksPerSecond * distance.Millimeters / this.distance.Millimeters);
        }

        /// <summary>
        /// Get the timespan needed to cover the specified distance in meter with this velocity.
        /// </summary>
        public TimeSpan GetDuration(int distanceInMeter)
        {
            return GetDuration(new Distance(distanceInMeter));
        }

        public static TimeSpan operator /(Distance distance, Velocity velocity)
        {
            //Ensure that the duration calculation does not exceed the long.MaxValue limit
            if (distance.Millimeters > long.MaxValue / TimeSpan.TicksPerSecond)
            {
                throw new ArgumentOutOfRangeException(nameof(distance));
            }
            return TimeSpan.FromTicks(TimeSpan.TicksPerSecond * distance.Millimeters / velocity.distance.Millimeters);
        }

        public static bool operator <(Velocity v1, Velocity v2)
        {
            return v1.distance.Millimeters < v2.distance.Millimeters;
        }

        public static bool operator <=(Velocity v1, Velocity v2)
        {
            return v1.distance.Millimeters <= v2.distance.Millimeters;
        }

        public static bool operator >(Velocity v1, Velocity v2)
        {
            return v1.distance.Millimeters > v2.distance.Millimeters;
        }

        public static bool operator >=(Velocity v1, Velocity v2)
        {
            return v1.distance.Millimeters >= v2.distance.Millimeters;
        }

        public static bool operator ==(Velocity v1, Velocity v2)
        {
            return v1.distance.Millimeters == v2.distance.Millimeters;
        }

        public static bool operator !=(Velocity v1, Velocity v2)
        {
            return v1.distance.Millimeters != v2.distance.Millimeters;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Velocity)) return false;
            return distance.Millimeters == ((Distance)obj).Millimeters;
        }

        public override int GetHashCode()
        {
            return distance.GetHashCode();
        }

        public override string ToString()
        {
            return $"{distance.Meters}m/s";
        }
    }
}