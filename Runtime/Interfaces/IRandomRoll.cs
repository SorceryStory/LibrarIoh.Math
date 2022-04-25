namespace SorceressSpell.LibrarIoh.Math
{
    public interface IRandomRoll<T>
    {
        #region Methods

        public T RandomRoll(T minValue, T maxValue);

        #endregion Methods
    }
}
