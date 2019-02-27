using System;

namespace Measurements
{
    public struct Distance
    {
        /// <summary>
        /// Ensures, that the meter representation in int is still valid
        /// </summary>
        private const double MAX_METERS = double.MaxValue / 10000;
        private const double MIN_METERS = -double.MaxValue / 10000;

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
            return new Distance(millimeters/MILLIMETERS_PER_METER);
        }

        /// <summary>
        /// Initializes a new instance of the distance structure to the specified distance in kilometers.
        /// </summary>
        public static Distance FromKilometers(double kilometers)
        {
            return new Distance(kilometers * 1000);
        }

        /// <summary>
        /// Calculate the distance travelled with an uniform acceleration for a given time: s = s0+v0*t+0.5*a*t²
        /// </summary>
        /// <param name="t">The time of the uniform acceleration</param>
        /// <param name="a">The uniform acceleration</param>
        /// <param name="v0">The initial velocity, defaults to 0</param>
        /// <param name="s0">The initial distance, defaults to 0</param>
        /// <returns>Returns the travelled distance after accelerating for a given time.</returns>
        public static Distance FromUniformAcceleration(TimeSpan t, Acceleration a, Velocity v0 = new Velocity(), Distance s0 = new Distance())
        {
            return s0 + v0 * t + 0.5 * a * t * t;
        }

        /// <summary>
        /// Calculate the time needed to move this distance during a uniform acceleration. Solve for t: s(t) = s0 + v0 * t + 0.5 * a * t²
        /// </summary>
        /// <param name="a">The uniform acceleration.</param>
        /// <param name="s0">The distance already moved.</param>
        /// <param name="v0">The start velocity.</param>
        /// <returns>Always returns the positive time.</returns>
        public TimeSpan GetTimeForUniformAcceleration(Acceleration a, Distance s0 = new Distance(), Velocity v0 = new Velocity())
        {
            if (s0 > this) throw new Exception($"This distance {Meters}m have aready been reached.");
            if(a.MetersPerSecondSquared == 0)
            {
                return (this - s0) / v0;
            }
            double sqrt = 2 * a.MetersPerSecondSquared * (Meters - s0.Meters) + v0.MetersPerSecond * v0.MetersPerSecond;
            if (sqrt < 0) throw new Exception($"This distance is never reached");
            sqrt = Math.Sqrt(sqrt);
            var t1 = (sqrt-v0.MetersPerSecond)/a.MetersPerSecondSquared;
            var t2 = (-sqrt - v0.MetersPerSecond)/a.MetersPerSecondSquared;
            //Return the positive time, when the distance is reached. If there are 
            var seconds = (t1>=0&&t2>=0&&t1<t2)||(t1>=0&&t2<0)? t1 : t2;
            return TimeSpan.FromTicks((long)Math.Round(seconds*TimeSpan.TicksPerSecond));
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

        public static Distance operator *(double multiplier, Distance distance)
        {
            return distance * multiplier;
        }

        public static Distance operator *(Distance distance, int multiplier)
        {
            if (multiplier < 0) throw new ArgumentOutOfRangeException(nameof(multiplier));
            return new Distance(distance.Meters * multiplier);
        }

        public static Distance operator *(int multiplier, Distance distance)
        {
            return distance * multiplier;
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