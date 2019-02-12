﻿using Measurements;
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
            var acceleration = new Acceleration(meters);
            Assert.AreEqual(meters, acceleration.MetersPerSecondSquared);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(double.MaxValue / 10000)]
        public void FromMillimetersPerSecondsSquared(double millimeters)
        {
            var acceleration = Acceleration.FromMillimetersPerSecondSquared(millimeters);
            Assert.AreEqual(millimeters, acceleration.MetersPerSecondSquared*1000);
        }

        [TestMethod]
        public void Compare()
        {
            var a1 = new Acceleration(1);
            var a2 = new Acceleration(2);
            var a3 = new Acceleration(2);
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
            var a1 = new Acceleration(1);
            var a2 = new Acceleration(2);
            Assert.AreEqual(3, (a1+a2).MetersPerSecondSquared);
        }

        [TestMethod]
        public void Subtraction()
        {
            var a1 = new Acceleration(1);
            var a2 = new Acceleration(2);
            Assert.AreEqual(1, (a2 - a1).MetersPerSecondSquared);
        }

        [TestMethod]
        public void Multiplication()
        {
            double multiplicator = 3;
            var a = new Acceleration(2);
            Assert.AreEqual(6, (a * multiplicator).MetersPerSecondSquared);
        }

        [TestMethod]
        public void Division()
        {
            double divisor = 2;
            var a = new Acceleration(5);
            Assert.AreEqual(2.5, (a / divisor).MetersPerSecondSquared);
        }

        [TestMethod]
        public void Velocity()
        {
            var acceleration = new Acceleration(2);
            var time = TimeSpan.FromSeconds(5);
            var velocity = acceleration * time;
            Assert.AreEqual(10, velocity.MetersPerSecond);
        }

        [TestMethod]
        public void Force()
        {
            var acceleration = new Acceleration(3);
            var weight = Weight.FromKilograms(4);
            var force = weight * acceleration;
            Assert.AreEqual(12, force.Newton);
        }

        [TestMethod]
        public void VelocityDividedByAccelerationPos()
        {
            var velocity = new Velocity(1);
            var acceleration = new Acceleration(2);
            var timespan = velocity / acceleration;
            Assert.AreEqual(0.5, timespan.TotalSeconds);
        }
    }
}