using SorceressSpell.LibrarIoh.Core;
using System.Collections.Generic;

namespace SorceressSpell.LibrarIoh.Math
{
    public static class RandomDistribution
    {
        #region Methods

        public static List<float> Calculate(ProceduralRandom proceduralRandom, List<DistributionRange> distributionRanges, float increase, float targetSum)
        {
            List<float> finalDistribution = new List<float>();

            foreach (DistributionRange distributionRange in distributionRanges)
            {
                finalDistribution.Add(distributionRange.MinValue);
            }

            while (finalDistribution.Sum() + increase <= targetSum)
            {
                //TODO Toggle for Seeded/Pure Random?
                int rangeIndex = proceduralRandom.Next(0, distributionRanges.Count);

                float finalValue = finalDistribution[rangeIndex] + increase;

                if (finalValue <= distributionRanges[rangeIndex].MaxValue)
                {
                    finalDistribution[rangeIndex] = finalValue;
                }
            }

            return finalDistribution;
        }

        #endregion Methods
    }
}
