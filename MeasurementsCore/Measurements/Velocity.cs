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
        public double MetersPerSecond { get; }

        /// <summary>
        /// Initializes a new instance of the velocity structure to the specified distance in meters per second.
        /// </summary>
        /// <param name="metersPerSecond">The distance in meters per second.</param>
        public Velocity(double metersPerSecond)
        {
            MetersPerSecond = metersPerSecond;
        }

        /// <summary>
        /// Initializes a new instance of the velocity structure to the specified distance in the specified time.
        /// </summary>
        /// <param name="distance">The distance part of the velocity.</param>
        /// <param name="deltaTime">The timespam part of the velocity.</param>
        public static Velocity FromDistancePerTime(Distance distance, TimeSpan deltaTime)
        {
            //Ensure that the distances calculation does not exceed the long.MaxValue limit
            if (distance.Meters > long.MaxValue / TimeSpan.TicksPerSecond)
            {
                throw new ArgumentOutOfRangeException(nameof(distance), "The distance is to large. Consider decreasing the distance as well as the delta time.");
            }

            double metersPerSecond = TimeSpan.TicksPerSecond * distance.Meters / deltaTime.Ticks;
            if (metersPerSecond > SpeedOfLight.MetersPerSecond) throw new ArgumentOutOfRangeException(nameof(distance));
            return new Velocity(metersPerSecond);
        }

        /// <summary>
        /// Initializes a new instance of the velocity structure when accelerating uniformly for a given amount of time.
        /// </summary>
        /// <param name="deltaTime">The duration of uniform acceleration.</param>
        /// <param name="acceleration">The uniform acceleration.</param>
        /// <param name="startVelocity">The start velocity.</param>
        public static Velocity FromUniformAcceleration(TimeSpan deltaTime, Acceleration acceleration, Velocity startVelocity = new Velocity())
        {
            return startVelocity + deltaTime * acceleration;
        }

        /// <summary>
        /// Get the timespan needed to cover the specified distance with this velocity.
        /// </summary>
        public TimeSpan GetDuration(Distance distance)
        {
            if (distance.Meters == 0) return new TimeSpan();
            else if (MetersPerSecond == 0) throw new Exception("A velocity of 0 m/s cannot cover any distances greater than 0.");

            //Ensure that the duration calculation does not exceed the long.MaxValue limit
            if (distance.Meters > long.MaxValue / TimeSpan.TicksPerSecond)
            {
                throw new ArgumentOutOfRangeException(nameof(distance));
            }
            var ticks = TimeSpan.TicksPerSecond * distance.Meters / MetersPerSecond;
            return TimeSpan.FromTicks((long)Math.Round(ticks, 0,MidpointRounding.AwayFromZero));
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
            if (distance.Meters > long.MaxValue / TimeSpan.TicksPerSecond)
            {
                throw new ArgumentOutOfRangeException(nameof(distance));
            }
            var ticks = TimeSpan.TicksPerSecond * distance.Meters / velocity.MetersPerSecond;
            return TimeSpan.FromTicks((long)Math.Round(ticks, 0, MidpointRounding.AwayFromZero));
        }

        public static bool operator <(Velocity v1, Velocity v2)
        {
            return v1.MetersPerSecond < v2.MetersPerSecond;
        }

        public static bool operator <=(Velocity v1, Velocity v2)
        {
            return v1.MetersPerSecond <= v2.MetersPerSecond;
        }

        public static bool operator >(Velocity v1, Velocity v2)
        {
            return v1.MetersPerSecond > v2.MetersPerSecond;
        }

        public static bool operator >=(Velocity v1, Velocity v2)
        {
            return v1.MetersPerSecond >= v2.MetersPerSecond;
        }

        public static bool operator ==(Velocity v1, Velocity v2)
        {
            return v1.MetersPerSecond == v2.MetersPerSecond;
        }

        public static bool operator !=(Velocity v1, Velocity v2)
        {
            return v1.MetersPerSecond != v2.MetersPerSecond;
        }

        public static Velocity operator +(Velocity v1, Velocity v2)
        {
            return new Velocity(v1.MetersPerSecond + v2.MetersPerSecond);
        }
        
        public static Velocity operator *(Velocity velocity, int multiplier)
        {
            return new Velocity(velocity.MetersPerSecond * multiplier);
        }

        public static Velocity operator *(Velocity velocity, double multiplier)
        {
            return new Velocity(velocity.MetersPerSecond * multiplier);
        }

        public static Velocity operator *(double multiplier, Velocity velocity)
        {
            return velocity*multiplier;
        }

        public static Velocity operator *(int multiplier, Velocity velocity)
        {
            return velocity * multiplier;
        }

        public static Velocity operator -(Velocity v1, Velocity v2)
        {
            return new Velocity(v1.MetersPerSecond - v2.MetersPerSecond);
        }

        public static Velocity operator /(Velocity velocity, int factor)
        {
            return new Velocity(velocity.MetersPerSecond / factor);
        }

        public static Acceleration operator /(Velocity v, TimeSpan t)
        {
            return new Acceleration(v.MetersPerSecond / t.TotalSeconds);
        }

        public static Distance operator *(Velocity v, TimeSpan t)
        {
            return new Distance(v.MetersPerSecond * t.TotalSeconds);
        }

        public static Distance operator *(TimeSpan t, Velocity v)
        {
            return v * t;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Velocity)) return false;
            return MetersPerSecond == ((Distance)obj).Meters;
        }

        public override int GetHashCode()
        {
            return MetersPerSecond.GetHashCode();
        }

        public override string ToString()
        {
            return $"{MetersPerSecond}m/s";
        }
    }
}