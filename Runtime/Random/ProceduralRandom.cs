using System;

namespace SorceressSpell.LibrarIoh.Math
{
    public class ProceduralRandom : IRandomRoll<int>, IRandomRoll<float>
    {
        #region Fields

        private byte[] _bytes;
        private Random _random;
        private Random _seededRandom;

        #endregion Fields

        #region Properties

        public int Seed { private set; get; }

        #endregion Properties

        #region Constructors

        public ProceduralRandom()
        {
            Initialize();
            ReSeed();
        }

        public ProceduralRandom(int seed)
        {
            Initialize();
            ReSeed(seed);
        }

        #endregion Constructors

        #region Methods

        public int Next(int minValue, int maxValue)
        {
            return NextStrategy(_random, minValue, maxValue);
        }

        public float Next(float minValue, float maxValue)
        {
            return NextStrategy(_random, minValue, maxValue);
        }

        public int NextSeeded(int minValue, int maxValue)
        {
            return NextStrategy(_seededRandom, minValue, maxValue);
        }

        public float NextSeeded(float minValue, float maxValue)
        {
            return NextStrategy(_seededRandom, minValue, maxValue);
        }

        public int RandomRoll(int minValue, int maxValue)
        {
            return Next(minValue, maxValue);
        }

        public float RandomRoll(float minValue, float maxValue)
        {
            return Next(minValue, maxValue);
        }

        public int Range(int minValue, int maxValue)
        {
            return Next(minValue, maxValue);
        }

        public float Range(float minValue, float maxValue)
        {
            return Next(minValue, maxValue);
        }

        public int RangeSeeded(int minValue, int maxValue)
        {
            return NextSeeded(minValue, maxValue);
        }

        public float RangeSeeded(float minValue, float maxValue)
        {
            return NextSeeded(minValue, maxValue);
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

        private void Initialize()
        {
            _random = new Random();
            _bytes = new byte[sizeof(int)];
        }

        private int NextStrategy(Random random, int minValue, int maxValue)
        {
            if (maxValue < int.MaxValue)
            {
                return random.Next(minValue, maxValue + 1);
            }

            if (minValue > int.MinValue)
            {
                return random.Next(minValue - 1, maxValue) + 1;
            }

            random.NextBytes(_bytes);
            return BitConverter.ToInt32(_bytes, 0);
        }

        private float NextStrategy(Random random, float minValue, float maxValue)
        {
            return MathOperations.Lerp(minValue, maxValue, (float)random.Next(Int32.MaxValue) / (Int32.MaxValue - 1));
        }

        #endregion Methods
    }
}
