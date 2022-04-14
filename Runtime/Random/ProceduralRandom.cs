using System;

namespace SorceressSpell.LibrarIoh.Math
{
    public class ProceduralRandom
    {
        #region Fields

        //TODO Keep only one?
        private readonly Random _random;

        private Random _seededRandom;

        #endregion Fields

        #region Properties

        public int Seed { private set; get; }

        #endregion Properties

        #region Constructors

        public ProceduralRandom()
        {
            _random = new Random();

            ReSeed();
        }

        public ProceduralRandom(int seed)
        {
            _random = new Random();

            ReSeed(seed);
        }

        #endregion Constructors

        #region Methods

        public float FullRageFloat()
        {
            return Range(float.MinValue, float.MaxValue);
        }

        public float FullRageSeededFloat()
        {
            return SeededRange(float.MinValue, float.MaxValue);
        }

        public int FullRangeInt()
        {
            return Range(int.MinValue, int.MaxValue);
        }

        public int FullRangeSeededInt()
        {
            return SeededRange(int.MinValue, int.MaxValue);
        }

        public int Range(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }

        //public int SeededNext(int maxValue)
        //{
        //    return SeededRange(0, maxValue);
        //}
        public float Range(float minValue, float maxValue)
        {
            float baseValue = (float)_random.NextDouble();
            return MathOperations.Normalize(baseValue, minValue, maxValue);
        }

        public void ReSeed()
        {
            Seed = _random.Next(int.MinValue, int.MaxValue);
            _seededRandom = new Random(Seed);
        }

        public void ReSeed(int seed)
        {
            Seed = seed;
            _seededRandom = new Random(Seed);
        }

        //public int Next(int maxValue)
        //{
        //    return Range(0, maxValue);
        //}
        public int SeededRange(int minValue, int maxValue)
        {
            return _seededRandom.Next(minValue, maxValue);
        }

        public float SeededRange(float minValue, float maxValue)
        {
            float baseValue = (float)_seededRandom.NextDouble();
            return MathOperations.Normalize(baseValue, minValue, maxValue);
        }

        #endregion Methods

        //public Vector2i Position(int width, int height)
        //{
        //    int x = Range(0, width);
        //    int y = Range(0, height);

        //    return new Vector2i(x, y);
        //}

        //public Vector2i SeededPosition(int width, int height)
        //{
        //    int x = SeededRange(0, width);
        //    int y = SeededRange(0, height);

        //    return new Vector2i(x, y);
        //}
    }
}
