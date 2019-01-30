using Measurements;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeasurementsUnitTests
{
    [TestClass]
    public class WorkUnitTests
    {
        [TestMethod]
        public void Constructor()
        {
            var work = new Work(1);
            Assert.AreEqual(1, work.Joule);
        }

        [TestMethod]
        public void Compare()
        {
            var w1 = new Work(1);
            var w2 = new Work(2);
            var w3 = new Work(2);
            Assert.IsTrue(w1 < w2);
            Assert.IsTrue(w2 > w1);
            Assert.IsTrue(w1 <= w2);
            Assert.IsTrue(w2 >= w1);
            Assert.IsTrue(w2 == w3);
            Assert.IsTrue(w2 <= w3);
            Assert.IsTrue(w2 >= w3);
            Assert.IsTrue(w1 != w2);
        }

        [TestMethod]
        public void Addition()
        {
            var w1 = new Work(1);
            var w2 = new Work(2);
            Assert.AreEqual(3, (w1 + w2).Joule);
        }

        [TestMethod]
        public void Subtraction()
        {
            var w1 = new Work(1);
            var w2 = new Work(2);
            Assert.AreEqual(1, (w2 - w1).Joule);
        }

        [TestMethod]
        public void Multiplication()
        {
            double multiplicator = 3;
            var f = new Work(2);
            Assert.AreEqual(6, (f * multiplicator).Joule);
        }

        [TestMethod]
        public void Division()
        {
            double divisor = 2;
            var f = new Work(5);
            Assert.AreEqual(2.5, (f / divisor).Joule);
        }

        [TestMethod]
        public void SelfDivision()
        {
            var w1 = new Work(10);
            var w2 = new Work(2);
            var result = w1 / w2;
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void ToWattHours()
        {
            var work = new Work(36);
            Assert.AreEqual(0.01, work.WattHour);
        }

        [TestMethod]
        public void ToKilowattHours()
        {
            var work = new Work(36000);
            Assert.AreEqual(0.01, work.KilowattHour);
        }

        [TestMethod]
        public void ToMegawattHours()
        {
            var work = new Work(36000000);
            Assert.AreEqual(0.01, work.MegawattHour);
        }

        [TestMethod]
        public void FromKilowattHours()
        {
            var work = Work.FromKiloWatt(1);
            Assert.AreEqual(1, work.KilowattHour);
        }
    }
}