using System;

namespace Measurements
{
    /// <summary>
    /// Represents a weight.
    /// </summary>
    public struct Weight
    {
        private const double MAX_GRAM = double.MaxValue/1000;
        private const double MIN_GRAM = 0;

        public const int MILLIGRAMS_PER_GRAM = 1000;
        public const int GRAMS_PER_KILOGRAM = 1000;
        public const int GRAMS_PER_METRIC_TON = 1000000;

        public static readonly Weight MAX = new Weight(MAX_GRAM);
        public static readonly Weight MIN = new Weight(MIN_GRAM);

        /// <summary>
        /// Initializes a new instance of the weight structure to the specified weight in grams.
        /// </summary>
        /// <param name="gram">The weight in grams.</param>
        public Weight(double gram)
        {
            if(gram< MIN_GRAM || gram > MAX_GRAM)
            {
                throw new ArgumentOutOfRangeException("Invalid weight");
            }
            Gram = gram;
        }

        /// <summary>
        /// Initializes a new instance of the weight structure to the specified weight in kilograms.
        /// </summary>
        /// <param name="kilograms"></param>
        /// <returns></returns>
        public static Weight FromKilograms(double kilograms)
        {
            return new Weight(kilograms * 1000);
        }

        /// Initializes a new instance of the weight structure to the specified weight in metric tons.
        public static Weight FromMetricTons(double metricTons)
        {
            return new Weight(metricTons * 1000000);
        }

        public double Gram { get; }
        public double Kilogram => Gram / 1000d;
        public double MetricTon => Gram / 1000000d;
        public double Milligram => Gram * 1000;

        public override string ToString()
        {
            if (Gram < GRAMS_PER_KILOGRAM)
            {
                return $"{Gram} grams";
            }
            else if(Gram < GRAMS_PER_METRIC_TON)
            {
                return $"{Kilogram} kilograms";
            }
            else
            {
                return $"{MetricTon} metric tons";
            }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Weight)) return false;
            return this == (Weight)obj;
        }

        public static bool operator ==(Weight w1, Weight w2)
        {
            return w1.Gram == w2.Gram;
        }

        public static bool operator !=(Weight w1, Weight w2)
        {
            return w1.Gram != w2.Gram;
        }

        public override int GetHashCode()
        {
            return Gram.GetHashCode();
        }

        public static bool operator <(Weight w1, Weight w2)
        {
            return w1.Gram < w2.Gram;
        }

        public static bool operator >(Weight w1, Weight w2)
        {
            return w1.Gram > w2.Gram;
        }

        public static bool operator <=(Weight w1, Weight w2)
        {
            return w1.Gram <= w2.Gram;
        }

        public static bool operator >=(Weight w1, Weight w2)
        {
            return w1.Gram >= w2.Gram;
        }

        public static Weight operator +(Weight w1, Weight w2)
        {
            return new Weight(w1.Gram + w2.Gram);
        }

        public static Weight operator -(Weight w1, Weight w2)
        {
            return new Weight(w1.Gram - w2.Gram);
        }

        public static Weight operator *(Weight w1, int multiplier)
        {
            return new Weight(w1.Gram * multiplier);
        }

        public static Weight operator /(Weight w1, int divisor)
        {
            return new Weight(w1.Gram / divisor);
        }

        public static double operator /(Weight w1, Weight w2)
        {
            return w1.Gram / w2.Gram;
        }
    }
}