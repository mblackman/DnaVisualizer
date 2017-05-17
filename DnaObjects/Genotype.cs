using System;

namespace DnaBase
{
    /// <summary>
    /// Represents a possible combination of a genotype.
    /// </summary>
    public enum Genotype
    {
        None = 0,
        AA,
        GG,
        CC,
        AG,
        AC,
        CT,
        GT,
        II,
        DD,
        TT,
        CG,
        AT,
        DI,
        G,
        C,
        T,
        A,
        I,
        D
    }

    /// <summary>
    /// Extension methods to assist with GenoTypes.
    /// </summary>
    public static class GenoTypeExtensions
    {
        /// <summary>
        /// Gets the <see cref="Genotype"/> from the given string.
        /// </summary>
        /// <param name="value">The string to convert into a genotype.</param>
        /// <returns>The <see cref="Genotype"/>.</returns>
        public static Genotype FromString(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentException(nameof(value));

            if (!Enum.TryParse(value, out Genotype genotype))
            {
                return Genotype.None;
            }
            return genotype;
        }
    }
}
