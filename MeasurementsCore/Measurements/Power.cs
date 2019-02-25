namespace Measurements
{
    public struct Power
    {
        public double Watt { get; }

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