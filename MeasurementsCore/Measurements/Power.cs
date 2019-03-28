using System;

namespace Measurements
{
    public struct Power
    {
        public const int WATT_PER_KILOWATT = 1000;
        public const int WATT_PER_MEGAWATT = 1000000;
        public const int WATT_PER_GIGAWATT = 1000000000;

        public static readonly Power MinValue = new Power(double.MinValue);
        public static readonly Power MaxValue = new Power(double.MaxValue);

        public double Watt { get; }
        public double KiloWatt => Watt / WATT_PER_KILOWATT;
        public double GigaWatt => Watt / WATT_PER_GIGAWATT;
        public double MegaWatt => Watt / WATT_PER_MEGAWATT;

        /// <summary>
        /// Initializes a new instance of the power structure to the specified power in watt.
        /// </summary>
        public Power(double newton)
        {
            Watt = newton;
        }

        public override string ToString()
        {
            return $"{Watt} kg*m/s²";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Power)) return false;
            return this == (Power)obj;
        }

        /// <summary>
        /// Checks, if the absolute difference between this and another instance is inside the given tolerance.
        /// </summary>
        /// <returns>Returns false, if the absolute difference is greater than the given tolerance.</returns>
        public bool Equals(Power comparison, Power tolerance)
        {
            var diff = Math.Abs(Watt - comparison.Watt);
            return diff <= tolerance.Watt;
        }

        public override int GetHashCode()
        {
            return nameof(Watt).GetHashCode() ^ Watt.GetHashCode();
        }

        public static bool operator ==(Power p1, Power p2)
        {
            return p1.Watt == p2.Watt;
        }

        public static bool operator !=(Power p1, Power p2)
        {
            return !(p1 == p2);
        }

        public static bool operator <(Power p1, Power p2)
        {
            return p1.Watt < p2.Watt;
        }

        public static bool operator <=(Power p1, Power p2)
        {
            return p1.Watt <= p2.Watt;
        }

        public static bool operator >(Power p1, Power p2)
        {
            return p1.Watt > p2.Watt;
        }

        public static bool operator >=(Power p1, Power p2)
        {
            return p1.Watt >= p2.Watt;
        }

        public static Power operator +(Power p1, Power p2)
        {
            return new Power(p1.Watt + p2.Watt);
        }

        public static Power operator -(Power p1, Power p2)
        {
            return new Power(p1.Watt - p2.Watt);
        }

        public static Power operator *(Power p, double multiplicator)
        {
            return new Power(p.Watt * multiplicator);
        }

        public static Power operator *(double multiplicator, Power p)
        {
            return p * multiplicator;
        }

        public static Power operator /(Power p, double divisor)
        {
            return new Power(p.Watt / divisor);
        }

        public static double operator /(Power p1, Power p2)
        {
            return p1.Watt / p2.Watt;
        }
    }
}