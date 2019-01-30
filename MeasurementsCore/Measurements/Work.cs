using System;

namespace Measurements
{
    public struct Work
    {
        public double Joule { get; }

        public double WattHour => Joule / 3600;

        public double KilowattHour => Joule / 3600000;

        public double MegawattHour => Joule / 3600000000;

        /// <summary>
        /// Initializes a new instance of the work structure to the specified work in joule.
        /// </summary>
        public Work(double joule)
        {
            Joule = joule;
        }

        /// <summary>
        /// Initializes a new instance of the work structure to the specified work in kilowatt hours.
        /// </summary>
        public static Work FromKiloWatt(double kilowattHours)
        {
            return new Work(kilowattHours * 3600000);
        }

        public override string ToString()
        {
            return $"{Joule} kg*m/s²";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Work)) return false;
            return this == (Work)obj;
        }

        public override int GetHashCode()
        {
            return nameof(Joule).GetHashCode() ^ Joule.GetHashCode();
        }

        public static bool operator ==(Work f1, Work f2)
        {
            return f1.Joule == f2.Joule;
        }

        public static bool operator !=(Work f1, Work f2)
        {
            return !(f1 == f2);
        }

        public static bool operator <(Work f1, Work f2)
        {
            return f1.Joule < f2.Joule;
        }

        public static bool operator <=(Work f1, Work f2)
        {
            return f1.Joule <= f2.Joule;
        }

        public static bool operator >(Work f1, Work f2)
        {
            return f1.Joule > f2.Joule;
        }

        public static bool operator >=(Work f1, Work f2)
        {
            return f1.Joule >= f2.Joule;
        }

        public static Work operator +(Work f1, Work f2)
        {
            return new Work(f1.Joule + f2.Joule);
        }

        public static Work operator -(Work f1, Work f2)
        {
            return new Work(f1.Joule - f2.Joule);
        }

        public static Work operator *(Work f1, double multiplicator)
        {
            return new Work(f1.Joule * multiplicator);
        }

        public static Work operator /(Work f1, double divisor)
        {
            return new Work(f1.Joule / divisor);
        }

        public static double operator /(Work f1, Work f2)
        {
            return f1.Joule / f2.Joule;
        }

        public static Power operator /(Work work, TimeSpan time)
        {
            return new Power(work.Joule/time.TotalSeconds);
        }
    }
}