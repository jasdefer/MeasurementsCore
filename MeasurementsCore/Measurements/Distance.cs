using System;

namespace Measurements
{
    public struct Distance
    {
        /// <summary>
        /// Ensures, that the meter representation in int is still valid
        /// </summary>
        public const long MaxMillimeters = (long)MillimetersPerMeter * int.MaxValue;
        public const long MinMillimeters = 0;

        public const int MillimetersPerCentimeter = 10;
        public const int MillimetersPerMeter = 1000;
        public const int MillimetersPerKiloMeter = 1000000;

        public static Distance MinValue = new Distance(MinMillimeters);
        public static Distance MaxValue = new Distance(MaxMillimeters);

        public long Millimeters { get; }
        public long Centimeters { get => Millimeters / MillimetersPerCentimeter; }
        public int Meters { get => (int)(Millimeters / MillimetersPerMeter); }
        public int Kilometers { get => (int)Millimeters / MillimetersPerKiloMeter; }

        /// <summary>
        /// Initializes a new instance of the distance structure to the specified distance in millimeters.
        /// </summary>
        public Distance(long millimeters)
        {
            if (millimeters < 0 || millimeters > MaxMillimeters)
            {
                throw new ArgumentOutOfRangeException("Invalid Distance");
            }
            Millimeters = millimeters;
        }

        /// <summary>
        /// Initializes a new instance of the distance structure to the specified distance in meters.
        /// </summary>
        public Distance(int meters) : this(MillimetersPerMeter * (long)meters) { }

        /// <summary>
        /// Initializes a new instance of the distance structure to the specified distance in millimeters.
        /// </summary>
        public static Distance FromMillimeters(long millimeters)
        {
            return new Distance(millimeters);
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
            return distance1.Millimeters == distance2.Millimeters;
        }

        public static bool operator !=(Distance distance1, Distance distance2)
        {
            return distance1.Millimeters != distance2.Millimeters;
        }

        public override int GetHashCode()
        {
            return Millimeters.GetHashCode();
        }

        public static bool operator <(Distance distanceOne, Distance distanceTwo)
        {
            return distanceOne.Millimeters < distanceTwo.Millimeters;
        }

        public static bool operator >(Distance distanceOne, Distance distanceTwo)
        {
            return distanceOne.Millimeters > distanceTwo.Millimeters;
        }

        public static bool operator <=(Distance distanceOne, Distance distanceTwo)
        {
            return distanceOne.Millimeters <= distanceTwo.Millimeters;
        }

        public static bool operator >=(Distance distanceOne, Distance distanceTwo)
        {
            return distanceOne.Millimeters >= distanceTwo.Millimeters;
        }

        public static Distance operator +(Distance distanceOne, Distance distanceTwo)
        {
            return FromMillimeters(distanceOne.Millimeters + distanceTwo.Millimeters);
        }

        public static Distance operator *(Distance distance, int multiplier)
        {
            if (multiplier < 0) throw new ArgumentOutOfRangeException(nameof(multiplier));
            return FromMillimeters(distance.Millimeters * multiplier);
        }

        public static Distance operator *(int multiplier, Distance distance)
        {
            return distance * multiplier;
        }

        public static Distance operator -(Distance distanceOne, Distance distanceTwo)
        {
            return FromMillimeters(distanceOne.Millimeters - distanceTwo.Millimeters);
        }
    }
}