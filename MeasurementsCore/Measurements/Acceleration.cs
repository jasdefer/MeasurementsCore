using System;

namespace Measurements
{
    public struct Acceleration
    {
        public Distance DistancePerSecondSquared { get; }

        /// <summary>
        /// Initializes a new instance of the acceleration structure to the specified distance per square seconds.
        /// </summary>
        public Acceleration(Distance distancePerSecondSquared)
        {
            DistancePerSecondSquared = distancePerSecondSquared;
        }

        /// <summary>
        /// Initializes a new instance of the acceleration structure to the specified meters per square seconds.
        /// </summary>
        public static Acceleration FromMetersPerSecondSquared(double meters)
        {
            return new Acceleration(new Distance(meters));
        }

        /// <summary>
        /// Initializes a new instance of the acceleration structure to the specified millimeters per square seconds.
        /// </summary>
        public static Acceleration FromMillimetersPerSecondSquared(double millimeters)
        {
            return new Acceleration(Distance.FromMillimeters(millimeters));
        }

        public override string ToString()
        {
            return $"{DistancePerSecondSquared.Meters}m/s²";
        }

        public override int GetHashCode()
        {
            return nameof(Acceleration).GetHashCode() ^ DistancePerSecondSquared.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Acceleration)) return false;
            return this == (Acceleration)obj;
        }

        public static bool operator ==(Acceleration a1, Acceleration a2)
        {
            return a1.DistancePerSecondSquared == a2.DistancePerSecondSquared;
        }

        public static bool operator !=(Acceleration a1, Acceleration a2)
        {
            return !(a1==a2);
        }

        public static bool operator <(Acceleration a1, Acceleration a2)
        {
            return a1.DistancePerSecondSquared < a2.DistancePerSecondSquared;
        }

        public static bool operator <=(Acceleration a1, Acceleration a2)
        {
            return a1.DistancePerSecondSquared <= a2.DistancePerSecondSquared;
        }

        public static bool operator >(Acceleration a1, Acceleration a2)
        {
            return a1.DistancePerSecondSquared > a2.DistancePerSecondSquared;
        }

        public static bool operator >=(Acceleration a1, Acceleration a2)
        {
            return a1.DistancePerSecondSquared >= a2.DistancePerSecondSquared;
        }

        public static Acceleration operator +(Acceleration a1, Acceleration a2)
        {
            return new Acceleration(a1.DistancePerSecondSquared + a2.DistancePerSecondSquared);
        }

        public static Acceleration operator -(Acceleration a1, Acceleration a2)
        {
            return new Acceleration(a1.DistancePerSecondSquared - a2.DistancePerSecondSquared);
        }

        public static Acceleration operator *(Acceleration a1, double multiplicator)
        {
            return new Acceleration(a1.DistancePerSecondSquared * multiplicator);
        }

        public static Acceleration operator /(Acceleration a1, double divisor)
        {
            return new Acceleration(a1.DistancePerSecondSquared / divisor);
        }

        public static Velocity operator *(Acceleration acceleration, TimeSpan time)
        {
            return new Velocity(acceleration.DistancePerSecondSquared * time.TotalSeconds);
        }

        public static Force operator *(Weight weight, Acceleration acceleration)
        {
            return new Force(weight.Kilogram * acceleration.DistancePerSecondSquared.Meters);
        }
    }
}