using System;

namespace Measurements
{
    public struct Distance
    {
        /// <summary>
        /// Ensures, that the meter representation in int is still valid
        /// </summary>
        private const double MAX_METERS = double.MaxValue / 10000;
        private const double MIN_METERS = 0;

        public static Distance MinValue = new Distance(MIN_METERS);
        public static Distance MaxValue = new Distance(MAX_METERS);

        public const int MILLIMETERS_PER_METER = 1000;
        public const int CENTIMETERS_PER_METER = 100;
        public const int METERS_PER_KILOMETER = 1000;

        public double Millimeters => Meters * MILLIMETERS_PER_METER;
        public double Centimeters => Meters * CENTIMETERS_PER_METER;
        public double Meters { get; }
        public double Kilometers => Meters / METERS_PER_KILOMETER;

        /// <summary>
        /// Initializes a new instance of the distance structure to the specified distance in meters.
        /// </summary>
        public Distance(double meters)
        {
            if (meters < MIN_METERS || meters > MAX_METERS)
            {
                throw new ArgumentOutOfRangeException("Invalid Distance");
            }
            Meters = meters;
        }

        /// <summary>
        /// Initializes a new instance of the distance structure to the specified distance in millimeters.
        /// </summary>
        public static Distance FromMillimeters(double millimeters)
        {
            return new Distance(millimeters/1000);
        }

        /// <summary>
        /// Initializes a new instance of the distance structure to the specified distance in kilometers.
        /// </summary>
        public static Distance FromKilometers(double kilometers)
        {
            return new Distance(kilometers * 1000);
        }

        public override string ToString()
        {
            return $"{Meters}m";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Distance)) return false;
            return this == (Distance)obj;
        }

        public static bool operator ==(Distance distance1, Distance distance2)
        {
            return distance1.Meters == distance2.Meters;
        }

        public static bool operator !=(Distance distance1, Distance distance2)
        {
            return distance1.Meters != distance2.Meters;
        }

        public override int GetHashCode()
        {
            return Meters.GetHashCode();
        }

        public static bool operator <(Distance distanceOne, Distance distanceTwo)
        {
            return distanceOne.Meters < distanceTwo.Meters;
        }

        public static bool operator >(Distance distanceOne, Distance distanceTwo)
        {
            return distanceOne.Meters > distanceTwo.Meters;
        }

        public static bool operator <=(Distance distanceOne, Distance distanceTwo)
        {
            return distanceOne.Meters <= distanceTwo.Meters;
        }

        public static bool operator >=(Distance distanceOne, Distance distanceTwo)
        {
            return distanceOne.Meters >= distanceTwo.Meters;
        }

        public static Distance operator +(Distance distanceOne, Distance distanceTwo)
        {
            return new Distance(distanceOne.Meters + distanceTwo.Meters);
        }

        public static Distance operator *(Distance distance, double multiplier)
        {
            if (multiplier < 0) throw new ArgumentOutOfRangeException(nameof(multiplier));
            return new Distance(distance.Meters * multiplier);
        }

        public static Distance operator *(Distance distance, int multiplier)
        {
            if (multiplier < 0) throw new ArgumentOutOfRangeException(nameof(multiplier));
            return new Distance(distance.Meters * multiplier);
        }

        public static Distance operator *(int multiplier, Distance distance)
        {
            if (multiplier < 0) throw new ArgumentOutOfRangeException(nameof(multiplier));
            return new Distance(distance.Meters * multiplier);
        }

        public static Distance operator -(Distance distanceOne, Distance distanceTwo)
        {
            return new Distance(distanceOne.Meters - distanceTwo.Meters);
        }

        public static Distance operator /(Distance distance, double divisor)
        {
            if (divisor < 0) throw new ArgumentOutOfRangeException(nameof(divisor));
            return new Distance(distance.Meters / divisor);
        }

        public static Velocity operator /(Distance distance, TimeSpan timeSpan)
        {
            return new Velocity(TimeSpan.TicksPerSecond * distance.Meters / timeSpan.Ticks);
        }
    }
}