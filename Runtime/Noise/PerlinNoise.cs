namespace SorceressSpell.LibrarIoh.Math
{
    // Original Source: https://adrianb.io/2014/08/09/perlinnoise.html Adapted to fix a few bugs
    public static class PerlinNoise
    {
        #region Fields

        // floatd permutation to avoid overflow
        private static readonly int[] _p;

        // Hash lookup table as defined by Ken Perlin. This is a randomly arranged array of all
        // numbers from 0-255 inclusive.
        private static readonly int[] _permutation = { 151,160,137,91,90,15,
            131,13,201,95,96,53,194,233,7,225,140,36,103,30,69,142,8,99,37,240,21,10,23,
            190, 6,148,247,120,234,75,0,26,197,62,94,252,219,203,117,35,11,32,57,177,33,
            88,237,149,56,87,174,20,125,136,171,168, 68,175,74,165,71,134,139,48,27,166,
            77,146,158,231,83,111,229,122,60,211,133,230,220,105,92,41,55,46,245,40,244,
            102,143,54, 65,25,63,161, 1,216,80,73,209,76,132,187,208, 89,18,169,200,196,
            135,130,116,188,159,86,164,100,109,198,173,186, 3,64,52,217,226,250,124,123,
            5,202,38,147,118,126,255,82,85,212,207,206,59,227,47,16,58,17,182,189,28,42,
            223,183,170,213,119,248,152, 2,44,154,163, 70,221,153,101,155,167, 43,172,9,
            129,22,39,253, 19,98,108,110,79,113,224,232,178,185, 112,104,218,246,97,228,
            251,34,242,193,238,210,144,12,191,179,162,241, 81,51,145,235,249,14,239,107,
            49,192,214, 31,181,199,106,157,184, 84,204,176,115,121,50,45,127, 4,150,254,
            138,236,205,93,222,114,67,29,24,72,243,141,128,195,78,66,215,61,156,180
        };

        #endregion Fields

        #region Constructors

        static PerlinNoise()
        {
            _p = new int[512];
            for (int x = 0; x < 512; x++)
            {
                _p[x] = _permutation[x % 256];
            }
        }

        #endregion Constructors

        #region Methods

        public static float Perlin(float x, float y, float z)
        {
            return Perlin(x, y, z, -1);
        }

        public static float Perlin(float x, float y, float z, int repeat)
        {
            // If we have any repeat on, change the coordinates to their "local" repetitions
            if (repeat > 0)
            {
                x %= repeat;
                y %= repeat;
                z %= repeat;
            }

            ////////////////////////////////////////////////////////////////////////////////////////////
            // Calculate the "unit cube" that the point asked will be located in The left bound is (
            // |_x_|,|_y_|,|_z_| ) and the right bound is that plus 1. Next we calculate the
            // location (from 0.0 to 1.0) in that cube. We also fade the location to smooth the result.
            //int xi = (int)x & 255;
            //int yi = (int)y & 255;
            //int zi = (int)z & 255;

            //float xf = x - (int)x;
            //float yf = y - (int)y;
            //float zf = z - (int)z;
            ////////////////////////////////////////////////////////////////////////////////////////////

            ////////////////////////////////////////////////////////////////////////////////////////////
            // Apparently the original code above wouldn't work under negative values for the coordinates.
            // Source: https://gist.github.com/Flafla2/1a0b9ebef678bbce3215?permalink_comment_id=3850418#gistcomment-3850418
            int xi, yi, zi;
            float xf, yf, zf;

            // Added support for negative values
            if (x < 0f)
            {
                xi = 255 - ((int)(-x) & 255);
                xf = 1 + x - (int)x;
            }
            else
            {
                xi = (int)x & 255;
                xf = x - (int)x;
            }

            if (y < 0f)
            {
                yi = 255 - ((int)(-y) & 255);
                yf = 1 + y - (int)y;
            }
            else
            {
                yi = (int)y & 255;
                yf = y - (int)y;
            }

            if (z < 0f)
            {
                zi = 255 - ((int)(-z) & 255);
                zf = 1 + z - (int)z;
            }
            else
            {
                zi = (int)z & 255;
                zf = z - (int)z;
            }
            ////////////////////////////////////////////////////////////////////////////////////////////

            float u = Fade(xf);
            float v = Fade(yf);
            float w = Fade(zf);

            int aaa, aba, aab, abb, baa, bba, bab, bbb;
            aaa = _p[_p[_p[xi] + yi] + zi];
            aba = _p[_p[_p[xi] + Inc(yi, repeat)] + zi];
            aab = _p[_p[_p[xi] + yi] + Inc(zi, repeat)];
            abb = _p[_p[_p[xi] + Inc(yi, repeat)] + Inc(zi, repeat)];
            baa = _p[_p[_p[Inc(xi, repeat)] + yi] + zi];
            bba = _p[_p[_p[Inc(xi, repeat)] + Inc(yi, repeat)] + zi];
            bab = _p[_p[_p[Inc(xi, repeat)] + yi] + Inc(zi, repeat)];
            bbb = _p[_p[_p[Inc(xi, repeat)] + Inc(yi, repeat)] + Inc(zi, repeat)];

            float x1, x2, y1, y2;

            x1 = MathOperations.Lerp(
                Gradient(aaa, xf, yf, zf),
                Gradient(baa, xf - 1, yf, zf),
                u);

            // This is all then lerped together as a sort of weighted average based on the faded
            // (u,v,w) values we made earlier.
            x2 = MathOperations.Lerp(
                Gradient(aba, xf, yf - 1, zf),
                Gradient(bba, xf - 1, yf - 1, zf),
                u);

            y1 = MathOperations.Lerp(x1, x2, v);

            x1 = MathOperations.Lerp(
                Gradient(aab, xf, yf, zf - 1),
                Gradient(bab, xf - 1, yf, zf - 1),
                u);

            x2 = MathOperations.Lerp(
                Gradient(abb, xf, yf - 1, zf - 1),
                Gradient(bbb, xf - 1, yf - 1, zf - 1),
                u);

            y2 = MathOperations.Lerp(x1, x2, v);

            // For convenience we bound it to 0 - 1 (theoretical min/max before is -1 - 1)
            return (MathOperations.Lerp(y1, y2, w) + 1) / 2;
        }

        private static float Fade(float t)
        {
            // Fade function as defined by Ken Perlin. This eases coordinate values so that they
            // will "ease" towards integral values. This ends up smoothing the final output.

            // 6t^5 - 15t^4 + 10t^3
            return t * t * t * (t * (t * 6 - 15) + 10);
        }

        // The gradient function calculates the dot product between a pseudorandom gradient vector
        // and the vector from the input coordinate to the 8 surrounding points in its unit cube.
        private static float Gradient(int hash, float x, float y, float z)
        {
            ////////////////////////////////////////////////////////////////////////////////////////////
            //// Take the hashed value and take the first 4 bits of it (15 == 0b1111)
            //int h = hash & 15;

            //// If the most significant bit (MSB) of the hash is 0 then set u = x.  Otherwise y.
            //float u = h < 8 ? x : y;

            //// If the first and second significant bits are 0 set v = y
            //// If the first and second significant bits are 1 set v = x
            //// If the first and second significant bits are not equal (0/1, 1/0) set v = z
            //float v = (h < 4) ? y : ((h == 12 || h == 14) ? x : z);

            //// Use the last 2 bits to decide if u and v are positive or negative.  Then return their addition.
            //return ((h & 1) == 0 ? u : -u) + ((h & 2) == 0 ? v : -v);
            ////////////////////////////////////////////////////////////////////////////////////////////

            ////////////////////////////////////////////////////////////////////////////////////////////
            // A more optimized code to replace the original above
            // Source: http://riven8192.blogspot.com/2010/08/calculate-perlinnoise-twice-as-fast.html
            switch (hash & 0xF)
            {
                case 0x0: return x + y;
                case 0x1: return -x + y;
                case 0x2: return x - y;
                case 0x3: return -x - y;
                case 0x4: return x + z;
                case 0x5: return -x + z;
                case 0x6: return x - z;
                case 0x7: return -x - z;
                case 0x8: return y + z;
                case 0x9: return -y + z;
                case 0xA: return y - z;
                case 0xB: return -y - z;
                case 0xC: return y + x;
                case 0xD: return -y + z;
                case 0xE: return y - x;
                case 0xF: return -y - z;
                default: return 0; // never happens
            }
            ////////////////////////////////////////////////////////////////////////////////////////////
        }

        private static int Inc(int num, int repeat)
        {
            num++;
            if (repeat > 0) num %= repeat;

            return num;
        }

        #endregion Methods
    }
}
