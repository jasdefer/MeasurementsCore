using Measurements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MeasurementsUnitTests
{
    [TestClass]
    public class DistanceUnitTests
    {
        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(long.MaxValue)]
        public void InvalidDistances(long millimeters)
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Distance.FromMillimeters(millimeters));
        }

        [TestMethod]
        public void ExceedingMaximumDistance()
        {
            long millimeters = (long)int.MaxValue * 1000 + 1;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Distance(millimeters));
        }

        [TestMethod]
        public void MaxValidDistance()
        {
            Distance distance = new Distance((long)int.MaxValue  * 1000);
            Assert.AreEqual(int.MaxValue, distance.Meters);
        }

        [TestMethod]
        public void MinValidDistance()
        {
            Distance distance = new Distance(0);
            Assert.AreEqual(0, distance.Millimeters);
        }

        [TestMethod]
        public void ConstructorFromMeter()
        {
            int millimeters = 15000;
            Distance distanceFromMeters = new Distance(millimeters/1000);
            Assert.AreEqual(millimeters, distanceFromMeters.Millimeters);
        }

        [TestMethod]
        public void ConstructorFromMillimeter()
        {
            long millimeters = 1500;
            Distance distanceFromMeters = new Distance(millimeters);
            Assert.AreEqual(millimeters, distanceFromMeters.Millimeters);
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
    }
}