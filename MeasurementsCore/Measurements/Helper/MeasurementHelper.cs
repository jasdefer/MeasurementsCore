namespace Measurements.Helper
{
    public static class MeasurementHelper
    {
        public static Acceleration Min(params Acceleration[] values)
        {
            var min = Acceleration.MaxValue;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < min) min = values[i];
            }
            return min;
        }

        public static Distance Min(params Distance[] values)
        {
            var min = Distance.MaxValue;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < min) min = values[i];
            }
            return min;
        }

        public static Force Min(params Force[] values)
        {
            var min = Force.MaxValue;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < min) min = values[i];
            }
            return min;
        }
        public static Power Min(params Power[] values)
        {
            var min = Power.MaxValue;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < min) min = values[i];
            }
            return min;
        }
        public static Velocity Min(params Velocity[] values)
        {
            var min = Velocity.MaxValue;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < min) min = values[i];
            }
            return min;
        }
        public static Weight Min(params Weight[] values)
        {
            var min = Weight.MaxValue;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < min) min = values[i];
            }
            return min;
        }
        public static Work Min(params Work[] values)
        {
            var min = Work.MaxValue;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < min) min = values[i];
            }
            return min;
        }
        public static Acceleration Max(params Acceleration[] values)
        {
            var max = Acceleration.MinValue;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > max) max = values[i];
            }
            return max;
        }

        public static Distance Max(params Distance[] values)
        {
            var max = Distance.MinValue;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > max) max = values[i];
            }
            return max;
        }

        public static Force Max(params Force[] values)
        {
            var max = Force.MinValue;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > max) max = values[i];
            }
            return max;
        }
        public static Power Max(params Power[] values)
        {
            var max = Power.MinValue;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > max) max = values[i];
            }
            return max;
        }
        public static Velocity Max(params Velocity[] values)
        {
            var max = Velocity.MinValue;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > max) max = values[i];
            }
            return max;
        }
        public static Weight Max(params Weight[] values)
        {
            var max = Weight.MinValue;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > max) max = values[i];
            }
            return max;
        }
        public static Work Max(params Work[] values)
        {
            var max = Work.MinValue;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > max) max = values[i];
            }
            return max;
        }
    }
}
