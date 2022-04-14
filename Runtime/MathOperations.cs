using System;

namespace SorceressSpell.LibrarIoh.Math
{
    public static class MathOperations
    {
        #region Methods

        public static int Abs(int value)
        {
            return System.Math.Abs(value);
        }

        public static float Abs(float value)
        {
            return System.Math.Abs(value);
        }

        public static float AbsCeilingFloat(float value)
        {
            if (value < 0) { return FloorFloat(value); }
            else { return CeilingFloat(value); }
        }

        public static int AbsCeilingInt(float value)
        {
            if (value < 0) { return FloorInt(value); }
            else { return CeilingInt(value); }
        }

        //public static bool Approximately(float a, float b)
        //{
        //    return Approximately(a, b, 0.001f);
        //}
        public static bool Approximately(float a, float b, float interval)
        {
            return (a - b) < interval;
        }

        public static float CeilingFloat(float value)
        {
            return (float)System.Math.Ceiling(value);
        }

        public static int CeilingInt(float value)
        {
            return (int)System.Math.Ceiling(value);
        }

        public static int Clamp(int value, int min, int max)
        {
            if (value < min) { return min; }
            else if (value > max) { return max; }
            else { return value; }
        }

        public static float Clamp(float value, float min, float max)
        {
            if (value < min) { return min; }
            else if (value > max) { return max; }
            else { return value; }
        }

        public static float FloorFloat(float value)
        {
            return (float)System.Math.Floor(value);
        }

        public static int FloorInt(float value)
        {
            return (int)System.Math.Floor(value);
        }

        public static float Lerp(float a, float b, float interpolationValue)
        {
            return a + ((b - a) * interpolationValue);
        }

        public static int Max(int x, int y)
        {
            return System.Math.Max(x, y);
        }

        public static int Max(int x, int y, int z)
        {
            return System.Math.Max(x, Max(y, z));
        }

        public static float Max(float x, float y)
        {
            return System.Math.Max(x, y);
        }

        public static float Max(float x, float y, float z)
        {
            return System.Math.Max(x, Max(y, z));
        }

        public static int Min(int x, int y)
        {
            return System.Math.Min(x, y);
        }

        public static int Min(int x, int y, int z)
        {
            return System.Math.Min(x, Min(y, z));
        }

        public static float Min(float x, float y)
        {
            return System.Math.Min(x, y);
        }

        public static float Min(float x, float y, float z)
        {
            return System.Math.Min(x, Min(y, z));
        }

        public static int Modulo(int a, int n)
        {
            return (System.Math.Abs(a * n) + a) % n;
        }

        public static float Modulo(float a, float n)
        {
            //return (System.Math.Abs(a * n) + a) % n;

            float newA = a;

            while (newA < 0) { newA += n; }
            return newA % n;
        }

        public static float Normalize(float value, float minValue, float maxValue)
        {
            value = (value - minValue) / (maxValue - minValue);

            return value;
        }

        public static float Pow(float b, float exp)
        {
            return (float)System.Math.Pow(b, exp);
        }

        public static float RoundAwayFromZeroFloat(float value)
        {
            return (float)System.Math.Round(value, MidpointRounding.AwayFromZero);
        }

        public static int RoundAwayFromZeroInt(float value)
        {
            return (int)System.Math.Round(value, MidpointRounding.AwayFromZero);
        }

        public static float RoundDecimalPlaces(float value, int decimalPlaces, MidpointRounding MidpointRounding, float modulo)
        {
            float newValue = (float)System.Math.Round(value, decimalPlaces, MidpointRounding);

            float decimalOffset = (float)System.Math.Pow(10f, decimalPlaces);

            newValue *= decimalOffset;

            newValue = (float)(System.Math.Round(newValue / modulo) * modulo);

            newValue /= decimalOffset;

            return newValue;
        }

        public static float RoundFloat(float value)
        {
            return (float)System.Math.Round(value);
        }

        public static int RoundInt(float value)
        {
            return (int)System.Math.Round(value);
        }

        public static float RoundToInterval(float value, float interval)
        {
            return (float)System.Math.Round(value / interval) * interval;
        }

        public static float RoundToIntervalFloat(float value, float interval)
        {
            return (float)System.Math.Round(value / interval) * interval;
        }

        public static float RoundTowardsZeroFloat(float value)
        {
            return (float)System.Math.Truncate(value);
        }

        public static int RoundTowardsZeroInt(float value)
        {
            return (int)System.Math.Truncate(value);
        }

        public static int Sign(int value)
        {
            if (value < 0) { return -1; }
            else { return 1; }
        }

        public static float Sign(float value)
        {
            if (value < 0) { return -1; }
            else { return 1; }
        }

        public static float Sin(float value)
        {
            return (float)System.Math.Sin(value);
        }

        public static float TruncateFloat(float value)
        {
            return (float)System.Math.Truncate(value);
        }

        public static int TruncateInt(float value)
        {
            return (int)System.Math.Truncate(value);
        }

        #endregion Methods
    }
}
