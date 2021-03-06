﻿using System;

namespace Measurements
{
    public struct Acceleration
    {
        public double MetersPerSecondSquared { get; }

        public static readonly Acceleration MinValue = new Acceleration(double.MinValue);
        public static readonly Acceleration MaxValue = new Acceleration(double.MaxValue);

        /// <summary>
        /// Initializes a new instance of the acceleration structure to the specified meters per square seconds.
        /// </summary>
        public Acceleration(double metersPerSecondSquared)
        {
            MetersPerSecondSquared = metersPerSecondSquared;
        }

        /// <summary>
        /// Initializes a new instance of the acceleration structure to the specified millimeters per square seconds.
        /// </summary>
        public static Acceleration FromMillimetersPerSecondSquared(double millimeters)
        {
            return new Acceleration(millimeters/Distance.MILLIMETERS_PER_METER);
        }

        public override string ToString()
        {
            return $"{MetersPerSecondSquared}m/s²";
        }

        public override int GetHashCode()
        {
            return nameof(Acceleration).GetHashCode() ^ MetersPerSecondSquared.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Acceleration)) return false;
            return this == (Acceleration)obj;
        }

        /// <summary>
        /// Checks, if the absolute difference between this and another instance is inside the given tolerance.
        /// </summary>
        /// <returns>Returns false, if the absolute difference is greater than the given tolerance.</returns>
        public bool Equals(Acceleration acceleration, Acceleration tolerance)
        {
            var diff = Math.Abs(MetersPerSecondSquared - acceleration.MetersPerSecondSquared);
            return diff <= tolerance.MetersPerSecondSquared;
        }

        public static bool operator ==(Acceleration a1, Acceleration a2)
        {
            return a1.MetersPerSecondSquared == a2.MetersPerSecondSquared;
        }

        public static bool operator !=(Acceleration a1, Acceleration a2)
        {
            return !(a1==a2);
        }

        public static bool operator <(Acceleration a1, Acceleration a2)
        {
            return a1.MetersPerSecondSquared < a2.MetersPerSecondSquared;
        }

        public static bool operator <=(Acceleration a1, Acceleration a2)
        {
            return a1.MetersPerSecondSquared <= a2.MetersPerSecondSquared;
        }

        public static bool operator >(Acceleration a1, Acceleration a2)
        {
            return a1.MetersPerSecondSquared > a2.MetersPerSecondSquared;
        }

        public static bool operator >=(Acceleration a1, Acceleration a2)
        {
            return a1.MetersPerSecondSquared >= a2.MetersPerSecondSquared;
        }

        public static Acceleration operator +(Acceleration a1, Acceleration a2)
        {
            return new Acceleration(a1.MetersPerSecondSquared + a2.MetersPerSecondSquared);
        }

        public static Acceleration operator -(Acceleration a1, Acceleration a2)
        {
            return new Acceleration(a1.MetersPerSecondSquared - a2.MetersPerSecondSquared);
        }

        public static Acceleration operator *(Acceleration a, double multiplicator)
        {
            return new Acceleration(a.MetersPerSecondSquared * multiplicator);
        }

        public static Acceleration operator *(double multiplicator, Acceleration a)
        {
            return a * multiplicator;
        }

        public static Acceleration operator /(Acceleration a1, double divisor)
        {
            return new Acceleration(a1.MetersPerSecondSquared / divisor);
        }

        public static Velocity operator *(Acceleration acceleration, TimeSpan time)
        {
            return new Velocity(acceleration.MetersPerSecondSquared * time.TotalSeconds);
        }

        public static Velocity operator *(TimeSpan time, Acceleration acceleration)
        {
            return acceleration * time;
        }

        public static TimeSpan operator /(Velocity velocity, Acceleration acceleration)
        {
            return TimeSpan.FromTicks((long)Math.Round(TimeSpan.TicksPerSecond * velocity.MetersPerSecond / acceleration.MetersPerSecondSquared));
        }

        public static Force operator *(Weight weight, Acceleration acceleration)
        {
            return new Force(weight.Kilogram * acceleration.MetersPerSecondSquared);
        }

        public static Force operator *(Acceleration acceleration, Weight weight)
        {
            return weight * acceleration;
        }
    }
}