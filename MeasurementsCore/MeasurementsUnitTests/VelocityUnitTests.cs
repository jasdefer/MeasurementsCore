using Measurements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MeasurementsUnitTests
{
    [TestClass]
    public class VelocityUnitTests
    {
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(Velocity.MaxMetersPerSecond)]
        public void InitializeByMeterPerSecond(int metersPerSecond)
        {
            Velocity velocity = new Velocity(metersPerSecond);
            Assert.AreEqual(metersPerSecond, velocity.MetersPerSecond);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(Velocity.MaxMetersPerSecond)]
        public void InitializeByDistance(int meters)
        {
            Velocity velocity = new Velocity(meters);
            Assert.AreEqual(meters, velocity.MetersPerSecond);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(Velocity.MaxMetersPerSecond)]
        public void InitializeByDistanceAndTime(int meters)
        {
            int seconds = 2;
            Distance distance = new Distance(meters);
            TimeSpan deltaTime = TimeSpan.FromSeconds(seconds);
            Velocity velocity = Velocity.FromDistancePerTime(distance, deltaTime);
            Assert.AreEqual(meters/ (double)seconds, velocity.MetersPerSecond);
        }

        [TestMethod]
        public void TooLargeVelocityDistanceAndVelocity()
        {
            Distance distance = new Distance((long)Velocity.MaxMetersPerSecond * Distance.MILLIMETERS_PER_METER + 1);
            TimeSpan deltaTime = TimeSpan.FromSeconds(1);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Velocity.FromDistancePerTime(distance, deltaTime));
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(10)]
        [DataRow(1250)]
        [DataRow(3333)]
        [DataRow(922337203685)]
        public void GetDurationTest(long distanceInMillimeters)
        {
            Distance distance = new Distance(distanceInMillimeters);
            Velocity velocity = new Velocity(2450);
            TimeSpan duration = distance / velocity;
            Assert.AreEqual(Math.Round(1000 * distanceInMillimeters / 2450d, 4), duration.TotalMilliseconds, 0.0002);
        }

        [TestMethod]
        public void GetDurationForDefaultVelocity()
        {
            Velocity velocity = new Velocity();
            Assert.AreEqual(new TimeSpan(), velocity.GetDuration(0));
            Assert.ThrowsException<Exception>(() => velocity.GetDuration(1));
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3333333)]
        public void Addition(int meters)
        {
            Velocity velocity1 = new Velocity(10);
            Velocity velocity2 = new Velocity(meters);
            Assert.AreEqual(meters + 10, (velocity1 + velocity2).MetersPerSecond);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3333333)]
        public void Subtraction(int meters)
        {
            Velocity velocity1 = new Velocity(3333333);
            Velocity velocity2 = new Velocity(meters);
            Assert.AreEqual(3333333 - meters, (velocity1 - velocity2).MetersPerSecond);
            Assert.AreEqual(meters - 3333333, (velocity2 - velocity1).MetersPerSecond);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3333333)]
        public void Multiplication(int multiplier)
        {
            Velocity velocity1 = new Velocity(10);
            Assert.AreEqual(multiplier * 10, (velocity1 * multiplier).MetersPerSecond);
            Assert.AreEqual(multiplier * 10, (multiplier * velocity1).MetersPerSecond);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3333333)]
        public void Division(int divisor)
        {
            Velocity velocity1 = new Velocity(10);
            Assert.AreEqual(10d / divisor, (velocity1 / divisor).MetersPerSecond);
        }

        [TestMethod]
        public void EqualsWithTolerance()
        {
            var value1 = new Velocity(1);
            var value2 = new Velocity(2);
            var tolerance = new Velocity(1);
            Assert.IsTrue(value1.Equals(value2, tolerance));

            tolerance = new Velocity(0.999);
            Assert.IsFalse(value1.Equals(value2, tolerance));
        }
    }
}