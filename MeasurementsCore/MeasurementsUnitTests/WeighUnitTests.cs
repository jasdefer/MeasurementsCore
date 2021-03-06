﻿using Measurements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MeasurementsUnitTests
{
    [TestClass]
    public class WeighUnitTests
    {
        [DataTestMethod]
        [DataRow(double.MaxValue / 100)]
        [DataRow(double.MaxValue / -100)]
        public void ConstructorInvalidWeights(double grams)
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Weight(grams));
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(double.MaxValue / 1000)]
        public void Constructor(double grams)
        {
            var weight = new Weight(grams);
            Assert.AreEqual(grams, weight.Gram);
        }

        [TestMethod]
        public void Milligrams()
        {
            var weight = new Weight(1);
            Assert.AreEqual(1000, weight.Milligram);
        }

        [TestMethod]
        public void Kilograms()
        {
            var weight = new Weight(1500);
            Assert.AreEqual(1.5, weight.Kilogram);
        }

        [TestMethod]
        public void MetricTons()
        {
            var weight = new Weight(1500000);
            Assert.AreEqual(1.5, weight.MetricTon);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(double.MaxValue / 10000000)]
        public void FromKilograms(double kilograms)
        {
            var weight = Weight.FromKilograms(kilograms);
            Assert.AreEqual(weight.Kilogram, kilograms);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(double.MaxValue / 1000000000)]
        public void FromMetricTons(double metricTons)
        {
            var weight = Weight.FromMetricTons(metricTons);
            Assert.AreEqual(weight.MetricTon, metricTons);
        }

        [TestMethod]
        public void EqualsWithTolerance()
        {
            var value1 = new Weight(1);
            var value2 = new Weight(2);
            var tolerance = new Weight(1);
            Assert.IsTrue(value1.Equals(value2, tolerance));

            tolerance = new Weight(0.999);
            Assert.IsFalse(value1.Equals(value2, tolerance));
        }
    }
}