using System;

namespace Measurements
{
    public struct Work
    {
        public double Joule { get; }

        public double WattHour => Joule / 36000;

        public double KilowattHour => Joule / 36000000;

        public double MegawattHour => Joule / 36000000000;

        public Work(double joule)
        {
            Joule = joule;
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