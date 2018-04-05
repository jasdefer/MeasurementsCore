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
    }
}