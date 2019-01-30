namespace Measurements
{
    public struct Force
    {
        public double Newton { get; }

        public Force(double newton)
        {
            Newton = newton;
        }

        public override string ToString()
        {
            return $"{Newton} kg*m/s²";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Force)) return false;
            return this == (Force)obj;
        }

        public override int GetHashCode()
        {
            return nameof(Newton).GetHashCode() ^ Newton.GetHashCode();
        }

        public static bool operator ==(Force f1, Force f2)
        {
            return f1.Newton == f2.Newton;
        }

        public static bool operator !=(Force f1, Force f2)
        {
            return !(f1 == f2);
        }

        public static bool operator <(Force f1, Force f2)
        {
            return f1.Newton < f2.Newton;
        }

        public static bool operator <=(Force f1, Force f2)
        {
            return f1.Newton <= f2.Newton;
        }

        public static bool operator >(Force f1, Force f2)
        {
            return f1.Newton > f2.Newton;
        }

        public static bool operator >=(Force f1, Force f2)
        {
            return f1.Newton >= f2.Newton;
        }

        public static Force operator +(Force f1, Force f2)
        {
            return new Force(f1.Newton + f2.Newton);
        }

        public static Force operator -(Force f1, Force f2)
        {
            return new Force(f1.Newton - f2.Newton);
        }

        public static Force operator *(Force f1, double multiplicator)
        {
            return new Force(f1.Newton * multiplicator);
        }

        public static Force operator /(Force f1, double divisor)
        {
            return new Force(f1.Newton / divisor);
        }

        public static double operator /(Force f1, Force f2)
        {
            return f1.Newton / f2.Newton;
        }
    }
}