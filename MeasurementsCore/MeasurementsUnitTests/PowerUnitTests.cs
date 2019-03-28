using Measurements;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeasurementsUnitTests
{
    [TestClass]
    public class PowerUnitTests
    {
        [TestMethod]
        public void Constructor()
        {
            var Power = new Power(1);
            Assert.AreEqual(1, Power.Watt);
        }

        [TestMethod]
        public void Compare()
        {
            var p1 = new Power(1);
            var p2 = new Power(2);
            var f3 = new Power(2);
            Assert.IsTrue(p1 < p2);
            Assert.IsTrue(p2 > p1);
            Assert.IsTrue(p1 <= p2);
            Assert.IsTrue(p2 >= p1);
            Assert.IsTrue(p2 == f3);
            Assert.IsTrue(p2 <= f3);
            Assert.IsTrue(p2 >= f3);
            Assert.IsTrue(p1 != p2);
        }

        [TestMethod]
        public void Addition()
        {
            var p1 = new Power(1);
            var p2 = new Power(2);
            Assert.AreEqual(3, (p1 + p2).Watt);
        }

        [TestMethod]
        public void Subtraction()
        {
            var p1 = new Power(1);
            var p2 = new Power(2);
            Assert.AreEqual(1, (p2 - p1).Watt);
        }

        [TestMethod]
        public void Multiplication()
        {
            double multiplicator = 3;
            var f = new Power(2);
            Assert.AreEqual(6, (f * multiplicator).Watt);
        }

        [TestMethod]
        public void Division()
        {
            double divisor = 2;
            var f = new Power(5);
            Assert.AreEqual(2.5, (f / divisor).Watt);
        }

        [TestMethod]
        public void SelfDivision()
        {
            var p1 = new Power(10);
            var p2 = new Power(2);
            var result = p1 / p2;
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void KiloWatt()
        {
            var power = new Power(1000);
            Assert.AreEqual(1, power.KiloWatt);
        }

        [TestMethod]
        public void MegeWatt()
        {
            var power = new Power(1000000);
            Assert.AreEqual(1, power.MegaWatt);
        }

        [TestMethod]
        public void GigaWatt()
        {
            var power = new Power(1000000000);
            Assert.AreEqual(1, power.GigaWatt);
        }

        [TestMethod]
        public void EqualsWithTolerance()
        {
            var value1 = new Power(1);
            var value2 = new Power(2);
            var tolerance = new Power(1);
            Assert.IsTrue(value1.Equals(value2, tolerance));

            tolerance = new Power(0.999);
            Assert.IsFalse(value1.Equals(value2, tolerance));
        }
    }
}