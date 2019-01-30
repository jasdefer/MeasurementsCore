using Measurements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MeasurementsUnitTests
{
    [TestClass]
    public class AccelerationUnitTests
    {
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(double.MaxValue/10000)]
        public void Constructor(double meters)
        {
            var acceleration = new Acceleration(new Distance(meters));
            Assert.AreEqual(meters, acceleration.DistancePerSecondSquared.Meters);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(double.MaxValue / 10000)]
        public void FromMillimetersPerSecondsSquared(double millimeters)
        {
            var acceleration = Acceleration.FromMillimetersPerSecondSquared(millimeters);
            Assert.AreEqual(millimeters, acceleration.DistancePerSecondSquared.Millimeters);
        }

        [TestMethod]
        public void Compare()
        {
            var a1 = Acceleration.FromMetersPerSecondSquared(1);
            var a2 = Acceleration.FromMetersPerSecondSquared(2);
            var a3 = Acceleration.FromMetersPerSecondSquared(2);
            Assert.IsTrue(a1 < a2);
            Assert.IsTrue(a2 > a1);
            Assert.IsTrue(a1 <= a2);
            Assert.IsTrue(a2 >= a1);
            Assert.IsTrue(a2 == a3);
            Assert.IsTrue(a2 <= a3);
            Assert.IsTrue(a2 >= a3);
            Assert.IsTrue(a1 != a2);
        }

        [TestMethod]
        public void Addition()
        {
            var a1 = Acceleration.FromMetersPerSecondSquared(1);
            var a2 = Acceleration.FromMetersPerSecondSquared(2);
            Assert.AreEqual(3, (a1+a2).DistancePerSecondSquared.Meters);
        }

        [TestMethod]
        public void Subtraction()
        {
            var a1 = Acceleration.FromMetersPerSecondSquared(1);
            var a2 = Acceleration.FromMetersPerSecondSquared(2);
            Assert.AreEqual(1, (a2 - a1).DistancePerSecondSquared.Meters);
        }

        [TestMethod]
        public void Multiplication()
        {
            double multiplicator = 3;
            var a = Acceleration.FromMetersPerSecondSquared(2);
            Assert.AreEqual(6, (a * multiplicator).DistancePerSecondSquared.Meters);
        }

        [TestMethod]
        public void Division()
        {
            double divisor = 2;
            var a = Acceleration.FromMetersPerSecondSquared(5);
            Assert.AreEqual(2.5, (a / divisor).DistancePerSecondSquared.Meters);
        }

        [TestMethod]
        public void Velocity()
        {
            var acceleration = Acceleration.FromMetersPerSecondSquared(2);
            var time = TimeSpan.FromSeconds(5);
            var velocity = acceleration * time;
            Assert.AreEqual(10, velocity.MetersPerSecond);
        }

        [TestMethod]
        public void Force()
        {
            var acceleration = new Acceleration(new Distance(3));
            var weight = Weight.FromKilograms(4);
            var force = weight * acceleration;
            Assert.AreEqual(12, force.Newton);
        }
    }
}