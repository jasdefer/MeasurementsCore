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
            Distance distance = new Distance(meters);
            Velocity velocity = new Velocity(distance);
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
            Velocity velocity = new Velocity(distance, deltaTime);
            Assert.AreEqual(meters/ seconds, velocity.MetersPerSecond);
        }

        [TestMethod]
        public void InitializeMaxByDistanceAndTime()
        {
            long millimeters = long.MaxValue / TimeSpan.TicksPerSecond;
            Distance distance = new Distance(millimeters);

            //Ensure that the speed of light is not exceeded
            TimeSpan deltaTime = TimeSpan.FromSeconds(millimeters/1000);

            Velocity velocity = new Velocity(distance, deltaTime);
            Assert.AreEqual(1, velocity.MetersPerSecond);
        }

        [TestMethod]
        public void TooLargeVelocityByDistance()
        {
            Distance distance = new Distance(Velocity.MaxMetersPerSecond + 1);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Velocity(distance));
        }

        [TestMethod]
        public void TooLargeVelocityByMetersPerSecond()
        {
            int metersPerSecond = Velocity.MaxMetersPerSecond + 1;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Velocity(metersPerSecond));
        }

        [TestMethod]
        public void TooLargeVelocityDistanceAndVelocity()
        {
            Distance distance = new Distance((long)Velocity.MaxMetersPerSecond * Distance.MillimetersPerMeter + 1);
            TimeSpan deltaTime = TimeSpan.FromSeconds(1);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Velocity(distance, deltaTime));
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
            Velocity velocity = new Velocity(new Distance((long)2450));
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
        }

        [TestMethod]
        public void InvalidSubtraction()
        {
            Velocity velocity1 = new Velocity(10);
            Velocity velocity2 = new Velocity(20);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => velocity1 - velocity2);
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
            Assert.AreEqual(10000 / divisor, (velocity1 / divisor).DistancePerSecond.Millimeters);
        }
    }
}