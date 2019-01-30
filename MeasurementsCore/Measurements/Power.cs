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

        public static bool operator ==(Power f1, Power f2)
        {
            return f1.Watt == f2.Watt;
        }

        public static bool operator !=(Power f1, Power f2)
        {
            return !(f1 == f2);
        }

        public static bool operator <(Power f1, Power f2)
        {
            return f1.Watt < f2.Watt;
        }

        public static bool operator <=(Power f1, Power f2)
        {
            return f1.Watt <= f2.Watt;
        }

        public static bool operator >(Power f1, Power f2)
        {
            return f1.Watt > f2.Watt;
        }

        public static bool operator >=(Power f1, Power f2)
        {
            return f1.Watt >= f2.Watt;
        }

        public static Power operator +(Power f1, Power f2)
        {
            return new Power(f1.Watt + f2.Watt);
        }

        public static Power operator -(Power f1, Power f2)
        {
            return new Power(f1.Watt - f2.Watt);
        }

        public static Power operator *(Power f1, double multiplicator)
        {
            return new Power(f1.Watt * multiplicator);
        }

        public static Power operator /(Power f1, double divisor)
        {
            return new Power(f1.Watt / divisor);
        }

        public static double operator /(Power f1, Power f2)
        {
            return f1.Watt / f2.Watt;
        }
    }
}