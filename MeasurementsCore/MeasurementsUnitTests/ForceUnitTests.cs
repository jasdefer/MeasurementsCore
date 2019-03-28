using Measurements;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeasurementsUnitTests
{
    [TestClass]
    public class ForceUnitTests
    {
        [TestMethod]
        public void Constructor()
        {
            var force = new Force(1);
            Assert.AreEqual(1, force.Newton);
        }

        [TestMethod]
        public void Compare()
        {
            var f1 = new Force(1);
            var f2 = new Force(2);
            var f3 = new Force(2);
            Assert.IsTrue(f1 < f2);
            Assert.IsTrue(f2 > f1);
            Assert.IsTrue(f1 <= f2);
            Assert.IsTrue(f2 >= f1);
            Assert.IsTrue(f2 == f3);
            Assert.IsTrue(f2 <= f3);
            Assert.IsTrue(f2 >= f3);
            Assert.IsTrue(f1 != f2);
        }

        [TestMethod]
        public void Addition()
        {
            var f1 = new Force(1);
            var f2 = new Force(2);
            Assert.AreEqual(3, (f1 + f2).Newton);
        }

        [TestMethod]
        public void Subtraction()
        {
            var f1 = new Force(1);
            var f2 = new Force(2);
            Assert.AreEqual(1, (f2 - f1).Newton);
        }

        [TestMethod]
        public void Multiplication()
        {
            double multiplicator = 3;
            var f = new Force(2);
            Assert.AreEqual(6, (f * multiplicator).Newton);
        }

        [TestMethod]
        public void Division()
        {
            double divisor = 2;
            var f = new Force(5);
            Assert.AreEqual(2.5, (f / divisor).Newton);
        }

        [TestMethod]
        public void SelfDivision()
        {
            var f1 = new Force(10);
            var f2 = new Force(2);
            var result = f1 / f2;
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void EqualsWithTolerance()
        {
            var value1 = new Force(1);
            var value2 = new Force(2);
            var tolerance = new Force(1);
            Assert.IsTrue(value1.Equals(value2, tolerance));

            tolerance = new Force(0.999);
            Assert.IsFalse(value1.Equals(value2, tolerance));
        }
    }
}