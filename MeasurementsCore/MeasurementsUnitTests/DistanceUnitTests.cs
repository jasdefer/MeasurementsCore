using Measurements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MeasurementsUnitTests
{
    [TestClass]
    public class DistanceUnitTests
    {
        [DataTestMethod]
        [DataRow(double.MaxValue / 1000)]
        public void InvalidDistances(double meters)
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Distance(meters));
        }

        [TestMethod]
        public void MinValidDistance()
        {
            Distance distance = new Distance(0);
            Assert.AreEqual(0, distance.Millimeters);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1.5)]
        [DataRow(double.MaxValue / 10000)]
        public void ConstructorFromMeter(double meters)
        {
            Distance distanceFromMeters = new Distance(meters);
            Assert.AreEqual(meters, distanceFromMeters.Meters);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1.5)]
        [DataRow(double.MaxValue / 10)]
        public void ConstructorFromMillimeter(double millimeters)
        {
            Distance distanceFromMillimeters = Distance.FromMillimeters(millimeters);
            Assert.AreEqual(millimeters, distanceFromMillimeters.Millimeters);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1.5)]
        [DataRow(double.MaxValue / 10000000)]
        public void ConstructorFromKilometers(double kilometers)
        {
            Distance distanceFromKiloMeters = Distance.FromKilometers(kilometers);
            Assert.AreEqual(kilometers, distanceFromKiloMeters.Kilometers);
        }


        [TestMethod]
        public void CompareUnequal()
        {
            Distance d1 = new Distance(10);
            Distance d2 = new Distance(20);
            Assert.IsTrue(d1 < d2);
            Assert.IsTrue(d1 <= d2);
            Assert.IsFalse(d1 > d2);
            Assert.IsFalse(d1 >= d2);
        }

        [TestMethod]
        public void CompareEqual()
        {
            Distance d1 = new Distance(10);
            Distance d2 = new Distance(10);

            Assert.IsTrue(d1 == d2);
            Assert.IsTrue(d1.Equals(d2));
            Assert.IsTrue(d2 == d1);
            Assert.IsTrue(d2.Equals(d1));

            Assert.IsFalse(d1 != d2);
            Assert.IsFalse(d2 != d1);
        }

        [TestMethod]
        public void CompareNull()
        {
            Distance d1 = new Distance(19);
            Assert.IsFalse(d1.Equals(null));
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(1000)]
        public void Multiply(int multiplier)
        {
            Distance distance = new Distance(10);
            Assert.AreEqual(10 * multiplier, (distance * multiplier).Meters);
            Assert.AreEqual(10 * multiplier, (multiplier * distance).Meters);
        }

        [TestMethod]
        public void InvalidMultiply()
        {
            Distance distance = new Distance(10);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => distance * -1);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => -1 * distance);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(10)]
        [DataRow(1000)]
        public void Subtract(int meters)
        {
            Distance distance = new Distance(1000);
            Distance result = distance - new Distance(meters);
            Assert.AreEqual(result.Meters, distance.Meters - meters);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2.5)]
        public void Division(double divisor)
        {
            Distance distance = new Distance(10);
            Distance result = distance / divisor;
            Assert.AreEqual(distance.Meters / divisor, result.Meters);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(10000.5)]
        public void GetVelocity(double meters)
        {
            Distance distance = new Distance(meters);
            TimeSpan duration = TimeSpan.FromSeconds(1);

            Velocity velocity = distance / duration;

            Assert.AreEqual(TimeSpan.TicksPerSecond * meters / duration.Ticks, velocity.MetersPerSecond);
        }

        [TestMethod]
        public void FromUniformAcceleration()
        {
            var t = TimeSpan.FromSeconds(12);
            var a = new Acceleration(1);
            var v = new Velocity(5);
            var s = new Distance(7);
            Distance distance = Distance.FromUniformAcceleration(t, a, v, s);
            Assert.AreEqual(new Distance(139), distance);
        }

        [TestMethod]
        public void GetTimeForUniformAcceleration()
        {
            var s = new Distance(100);
            var t = s.GetTimeForUniformAcceleration(new Acceleration(1), new Distance(20), new Velocity(5));
            Assert.AreEqual(8.60147, t.TotalSeconds, 0.00001);
        }

        [TestMethod]
        public void GetTimeForUniformNegativeAcceleration()
        {
            var s = new Distance(5);
            var t = s.GetTimeForUniformAcceleration(new Acceleration(-1), new Distance(0), new Velocity(5));
            Assert.AreEqual(1.12702, t.TotalSeconds, 0.00001);
        }
    }
}