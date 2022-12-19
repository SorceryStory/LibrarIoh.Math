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

        public static float AbsCeiling(float value)
        {
            return (value < 0) ? Floor(value) : Ceiling(value);
        }

        public static int AbsCeilingToInt(float value)
        {
            return (value < 0) ? FloorToInt(value) : CeilingToInt(value);
        }

        public static bool Approximately(float a, float b, float maxInterval)
        {
            return (a - b) <= maxInterval;
        }

        public static float Ceiling(float value)
        {
            return (float)System.Math.Ceiling(value);
        }

        public static int CeilingToInt(float value)
        {
            return (int)System.Math.Ceiling(value);
        }

        public static int Clamp(int value, int min, int max)
        {
            return (value < min) ? min : ((value > max) ? max : value);
        }

        public static float Clamp(float value, float min, float max)
        {
            return (value < min) ? min : ((value > max) ? max : value);
        }

        public static float Floor(float value)
        {
            return (float)System.Math.Floor(value);
        }

        public static int FloorToInt(float value)
        {
            return (int)System.Math.Floor(value);
        }

        public static float InverseLerp(float startValue, float endValue, float interpolationValue)
        {
            float range = endValue - startValue;

            if (range == 0f)
            {
                return startValue;
            }

            return (interpolationValue - startValue) / range;
        }

        public static float Lerp(float startValue, float endValue, float interpolationValue)
        {
            return startValue + (interpolationValue * (endValue - startValue));
        }

        public static float LerpClamp(float startValue, float endValue, float interpolationValue)
        {
            return Lerp(startValue, endValue, Clamp(interpolationValue, 0f, 1f));
        }

        public static float LerpMap(float originStartValue, float originEndValue, float targetStartValue, float targetEndValue, float interpolationValue)
        {
            float originalRange = originEndValue - originStartValue;

            if (originalRange == 0)
            {
                return (targetStartValue + targetEndValue) / 2;
            }

            return targetStartValue + (interpolationValue - originStartValue) * (targetEndValue - targetStartValue) / originalRange;
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

        public static int Modulo(int value, int modulus)
        {
            return (value < 0) ? (((value % modulus) + modulus) % modulus) : (value % modulus);
        }

        public static float Modulo(float value, float modulus)
        {
            return (value < 0) ? (((value % modulus) + modulus) % modulus) : (value % modulus);
        }

        public static float Normalize(float value, float minValue, float maxValue)
        {
            return (value - minValue) / (maxValue - minValue);
        }

        public static int Pow(int b, int exp)
        {
            return (int)System.Math.Pow(b, exp);
        }

        public static float Pow(float b, float exp)
        {
            return (float)System.Math.Pow(b, exp);
        }

        public static float Round(float value)
        {
            return (float)System.Math.Round(value);
        }

        public static float Round(float value, MidpointRounding midpointRounding)
        {
            return (float)System.Math.Round(value, midpointRounding);
        }

        public static float RoundAwayFromZero(float value)
        {
            return (float)System.Math.Round(value, MidpointRounding.AwayFromZero);
        }

        public static int RoundAwayFromZeroToInt(float value)
        {
            return (int)System.Math.Round(value, MidpointRounding.AwayFromZero);
        }

        public static float RoundDecimalPlaces(float value, int decimalPlaces, MidpointRounding midpointRounding, float modulo)
        {
            float newValue = (float)System.Math.Round(value, decimalPlaces, midpointRounding);
            float decimalOffset = (float)System.Math.Pow(10f, decimalPlaces);

            newValue *= decimalOffset;
            newValue = (float)(System.Math.Round(newValue / modulo) * modulo);
            newValue /= decimalOffset;

            return newValue;
        }

        public static int RoundToInt(float value)
        {
            return (int)System.Math.Round(value);
        }

        public static int RoundToInt(float value, MidpointRounding midpointRounding)
        {
            return (int)System.Math.Round(value, midpointRounding);
        }

        public static float RoundToNearestMultiplier(float value, float multiplier)
        {
            return Round(value / multiplier) * multiplier;
        }

        public static float RoundTowardsZero(float value)
        {
            return (float)System.Math.Truncate(value);
        }

        public static int RoundTowardsZeroToInt(float value)
        {
            return (int)System.Math.Truncate(value);
        }

        public static int Sign(int value)
        {
            return value < 0 ? -1 : 1;
        }

        public static float Sign(float value)
        {
            return value < 0f ? -1f : 1f;
        }

        public static float Sin(float value)
        {
            return (float)System.Math.Sin(value);
        }

        public static float Truncate(float value)
        {
            return (float)System.Math.Truncate(value);
        }

        public static int TruncateToInt(float value)
        {
            return (int)System.Math.Truncate(value);
        }

        #endregion Methods
    }
}
