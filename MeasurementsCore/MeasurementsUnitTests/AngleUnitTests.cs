using Measurements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MeasurementsUnitTests
{
    [TestClass]
    public class AngleUnitTests
    {
        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        [DataRow(1)]
        public void Constructor(double radians)
        {
            var angle = new Angle(radians);
            Assert.AreEqual(radians, angle.Radians);
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        [DataRow(1)]
        public void FromRadians(double radians)
        {
            var angle = Angle.FromRadians(radians);
            Assert.AreEqual(radians, angle.Radians);
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        [DataRow(1)]
        public void FromDegree(double degrees)
        {
            var angle = Angle.FromDegree(degrees);
            Assert.AreEqual(degrees, angle.Degrees);
        }

        [TestMethod]
        public void FlatDegreePositive()
        {
            var angle = Angle.FromDegree(370);
            Assert.AreEqual(10, angle.GetFlatDegrees());
        }

        [TestMethod]
        public void FlatDegreeNegative()
        {
            var angle = Angle.FromDegree(-370);
            Assert.AreEqual(350, angle.GetFlatDegrees());
        }

        [TestMethod]
        public void FlatRadiansPositive()
        {
            var angle = Angle.FromRadians(3*Math.PI);
            Assert.AreEqual(Math.PI, angle.GetFlatRadians());
        }

        [TestMethod]
        public void FlatRadiansNegative()
        {
            var angle = Angle.FromRadians(-2.5 * Math.PI);
            Assert.AreEqual(1.5*Math.PI, angle.GetFlatRadians());
        }
    }
}