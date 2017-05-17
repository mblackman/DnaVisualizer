using System;
using System.Collections.Generic;

namespace DnaBase
{
    /// <summary>
    /// Represents a Chromosome with the given collection of Single Nucleotide Polymorphisms.
    /// </summary>
    public class Chromosome
    {
        private List<Snp> snp = new List<Snp>();

        /// <summary>
        /// Gets the chromosome number.
        /// </summary>
        /// <remarks>23 = X, 24 = Y, 25 = MT</remarks>
        public int Id { get; }

        /// <summary>
        /// Gets the collection of <see cref="Snp"/>.
        /// </summary>
        public IEnumerable<Snp> Snp => this.snp;

        /// <summary>
        /// Creates a new instance of <see cref="Chromosome"/> with the given id.
        /// </summary>
        /// <param name="id">The id of the <see cref="Chromosome"/>.</param>
        public Chromosome(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Creates a new <see cref="Snp"/> with the given values and adds it to the collection of <see cref="Snp"/>.
        /// </summary>
        /// <param name="rsid">The id of the <see cref="Snp"/>.</param>
        /// <param name="position">The position of the <see cref="Snp"/>.</param>
        /// <param name="genotype">The genotype of the <see cref="Snp"/>.</param>
        public void AddSnp(string rsid, int position, Genotype genotype)
        {
            this.snp.Add(new Snp(rsid, position, genotype));
        }

        /// <summary>
        /// Gets the chromosomes id from a given string.
        /// </summary>
        /// <param name="value">The string to convert into an id.</param>
        /// <returns>The identifier from the given string.</returns>
        public static int GetIdFromString(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentException(nameof(value));

            if (!int.TryParse(value, out int id))
            {
                if (value.Equals("X", StringComparison.OrdinalIgnoreCase))
                {
                    id = 23;
                }
                else if (value.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    id = 24;
                }
                else
                {
                    id = 25;
                }
            }

            return id;
        }
    }
}
