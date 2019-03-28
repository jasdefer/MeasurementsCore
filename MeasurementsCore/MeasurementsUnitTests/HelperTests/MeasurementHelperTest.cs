using Measurements;
using Measurements.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeasurementsUnitTests.HelperTests
{
    [TestClass]
    public class MeasurementHelperTest
    {
        [TestMethod]
        public void MinAcceleration()
        {
            var values = new Acceleration[]
            {
                new Acceleration(-1),
                new Acceleration(1),
                new Acceleration(-2),
                new Acceleration(3),
            };
            var min = MeasurementHelper.Min(values);
            Assert.AreEqual(values[2], min);
        }

        [TestMethod]
        public void MinDistance()
        {
            var values = new Distance[]
            {
                new Distance(-1),
                new Distance(1),
                new Distance(-2),
                new Distance(3),
            };
            var min = MeasurementHelper.Min(values);
            Assert.AreEqual(values[2], min);
        }

        [TestMethod]
        public void MinForce()
        {
            var values = new Force[]
            {
                new Force(-1),
                new Force(1),
                new Force(-2),
                new Force(3),
            };
            var min = MeasurementHelper.Min(values);
            Assert.AreEqual(values[2], min);
        }

        [TestMethod]
        public void MinPower()
        {
            var values = new Power[]
            {
                new Power(-1),
                new Power(1),
                new Power(-2),
                new Power(3),
            };
            var min = MeasurementHelper.Min(values);
            Assert.AreEqual(values[2], min);
        }

        [TestMethod]
        public void MinVelocity()
        {
            var values = new Velocity[]
            {
                new Velocity(-1),
                new Velocity(1),
                new Velocity(-2),
                new Velocity(3),
            };
            var min = MeasurementHelper.Min(values);
            Assert.AreEqual(values[2], min);
        }

        [TestMethod]
        public void MinWeight()
        {
            var values = new Weight[]
            {
                new Weight(-1),
                new Weight(1),
                new Weight(-2),
                new Weight(3),
            };
            var min = MeasurementHelper.Min(values);
            Assert.AreEqual(values[2], min);
        }

        [TestMethod]
        public void MinWork()
        {
            var values = new Work[]
            {
                new Work(-1),
                new Work(1),
                new Work(-2),
                new Work(3),
            };
            var min = MeasurementHelper.Min(values);
            Assert.AreEqual(values[2], min);
        }

        [TestMethod]
        public void MaxAcceleration()
        {
            var values = new Acceleration[]
            {
                new Acceleration(-1),
                new Acceleration(1),
                new Acceleration(-2),
                new Acceleration(3),
            };
            var Max = MeasurementHelper.Max(values);
            Assert.AreEqual(values[3], Max);
        }

        [TestMethod]
        public void MaxDistance()
        {
            var values = new Distance[]
            {
                new Distance(-1),
                new Distance(1),
                new Distance(-2),
                new Distance(3),
            };
            var Max = MeasurementHelper.Max(values);
            Assert.AreEqual(values[3], Max);
        }

        [TestMethod]
        public void MaxForce()
        {
            var values = new Force[]
            {
                new Force(-1),
                new Force(1),
                new Force(-2),
                new Force(3),
            };
            var Max = MeasurementHelper.Max(values);
            Assert.AreEqual(values[3], Max);
        }

        [TestMethod]
        public void MaxPower()
        {
            var values = new Power[]
            {
                new Power(-1),
                new Power(1),
                new Power(-2),
                new Power(3),
            };
            var Max = MeasurementHelper.Max(values);
            Assert.AreEqual(values[3], Max);
        }

        [TestMethod]
        public void MaxVelocity()
        {
            var values = new Velocity[]
            {
                new Velocity(-1),
                new Velocity(1),
                new Velocity(-2),
                new Velocity(3),
            };
            var Max = MeasurementHelper.Max(values);
            Assert.AreEqual(values[3], Max);
        }

        [TestMethod]
        public void MaxWeight()
        {
            var values = new Weight[]
            {
                new Weight(-1),
                new Weight(1),
                new Weight(-2),
                new Weight(3),
            };
            var Max = MeasurementHelper.Max(values);
            Assert.AreEqual(values[3], Max);
        }

        [TestMethod]
        public void MaxWork()
        {
            var values = new Work[]
            {
                new Work(-1),
                new Work(1),
                new Work(-2),
                new Work(3),
            };
            var Max = MeasurementHelper.Max(values);
            Assert.AreEqual(values[3], Max);
        }
    }
}