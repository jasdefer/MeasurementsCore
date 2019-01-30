using System;

namespace Measurements
{
    /// <summary>
    /// Represents an angle in radians or degrees.
    /// </summary>
    public struct Angle
    {
        /// <summary>
        /// Create a new angle using radians.
        /// </summary>
        /// <param name="radians">The angle in radians.</param>
        public Angle(double radians)
        {
            Radians = radians;
        }

        /// <summary>
        /// Get the angle in degrees.
        /// </summary>
        public double Degrees => Radians * 180 / Math.PI;

        /// <summary>
        /// Get the angle in radians.
        /// </summary>
        /// <returns></returns>
        public double Radians { get; }

        /// <summary>
        /// Map the angle to degrees in [0, 360)
        /// </summary>
        public double GetFlatDegrees()
        {
            var degrees = Degrees;
            if (degrees < 0)
            {
                return degrees % 360 + 360;
            }
            else
            {
                return degrees % 360;
            }
        }

        /// <summary>
        /// Map the angle to radians in [0,2pi(
        /// </summary>
        /// <returns></returns>
        public double GetFlatRadians()
        {
            var radians = Radians;
            if (radians < 0)
            {
                return radians % (2 * Math.PI) + 2 * Math.PI;
            }
            else
            {
                return radians % (2 * Math.PI);
            }
        }

        /// <summary>
        /// Create a new angle using degrees.
        /// </summary>
        /// <param name="degrees">The angle in degrees.</param>
        public static Angle FromDegree(double degrees)
        {
            return new Angle(degrees * Math.PI / 180);
        }

        /// <summary>
        /// Create a new angle using radians.
        /// </summary>
        /// <param name="radians">The angle in radians.</param>
        public static Angle FromRadians(double radians)
        {
            return new Angle(radians);
        }

        public override string ToString()
        {
            return $"{Radians} radians";
        }

        public override int GetHashCode()
        {
            return Radians.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Angle)) return false;
            return this == (Angle)obj;
        }

        public static Angle operator +(Angle a, Angle b)
        {
            return new Angle(a.Radians + b.Radians);
        }
        
        public static Angle operator -(Angle a, Angle b)
        {
            return new Angle(a.Radians - b.Radians);
        }

        public static Angle operator /(Angle a, Angle b)
        {
            return new Angle(a.Radians / b.Radians);
        }

        public static Angle operator *(Angle a, Angle b)
        {
            return new Angle(a.Radians * b.Radians);
        }

        public static bool operator ==(Angle a, Angle b)
        {
            return a.Radians == b.Radians;
        }

        public static bool operator !=(Angle a, Angle b)
        {
            return a.Radians != b.Radians;
        }

        public static bool operator <(Angle a, Angle b)
        {
            return a.Radians < b.Radians;
        }

        public static bool operator <=(Angle a, Angle b)
        {
            return a.Radians <= b.Radians;
        }

        public static bool operator >(Angle a, Angle b)
        {
            return a.Radians > b.Radians;
        }

        public static bool operator >=(Angle a, Angle b)
        {
            return a.Radians >= b.Radians;
        }
    }
}