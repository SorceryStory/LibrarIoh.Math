namespace SorceressSpell.LibrarIoh.Math
{
    public class Vector2i
    {
        #region Properties

        public static Vector2i One => new Vector2i(1, 1);
        public static Vector2i Zero => new Vector2i(0, 0);
        public int X { set; get; }
        public int Y { set; get; }

        #endregion Properties

        #region Constructors

        public Vector2i()
        {
            Set(0, 0);
        }

        public Vector2i(int x, int y)
        {
            Set(x, y);
        }

        public Vector2i(string valuesString)
        {
            Set(valuesString);
        }

        public Vector2i(Vector2i original)
        {
            Set(original);
        }

        #endregion Constructors

        //public override bool Equals(object obj)
        //{
        //    return base.Equals(obj);
        //}

        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}

        #region Methods

        public static Vector2i operator -(Vector2i a, Vector2i b)
        {
            return new Vector2i(a.X - b.X, a.Y - b.Y);
        }

        public static bool operator !=(Vector2i a, Vector2i b)
        {
            return !(a == b);
        }

        public static Vector2i operator *(int a, Vector2i b)
        {
            return new Vector2i(a * b.X, a * b.Y);
        }

        public static Vector2i operator +(Vector2i a, Vector2i b)
        {
            return new Vector2i(a.X + b.X, a.Y + b.Y);
        }

        public static bool operator ==(Vector2i a, Vector2i b)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(a, b)) { return true; }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null)) { return false; }

            // Return true if the fields match:
            return a.X == b.X && a.Y == b.Y;
        }

        public Vector2i Abs()
        {
            return new Vector2i(MathOperations.Abs(X), MathOperations.Abs(Y));
        }

        public void Add(Vector2i other)
        {
            X += other.X;
            Y += other.Y;
        }

        public override bool Equals(object obj)
        {
            return obj is Vector2i i &&
                   X == i.X &&
                   Y == i.Y;
        }

        public override int GetHashCode()
        {
            int hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }

        public void MultiplyBy(int value)
        {
            X *= value;
            Y *= value;
        }

        public void Set(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Set(string valuesString)
        {
            string[] values = valuesString.Split(',');
            if (values.Length >= 2)
            {
                Set(int.Parse(values[0]), int.Parse(values[1]));
            }
        }

        public void Set(Vector2i original)
        {
            Set(original.X, original.Y);
        }

        public void Subtract(Vector2i other)
        {
            X -= other.X;
            Y -= other.Y;
        }

        public override string ToString()
        {
            return /*"(" +*/ X + ", " + Y /*+ ")"*/;
        }

        #endregion Methods
    }
}
