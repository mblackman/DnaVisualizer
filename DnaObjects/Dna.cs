using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DnaBase
{
    /// <summary>
    /// Represents the sum of chromosomes.
    /// </summary>
    public class Dna
    {
        private Dictionary<int, Chromosome> chromosomes;

        /// <summary>
        /// Gets the dictionary of <see cref="Chromosome"/> which are looked up by the chromosome id.
        /// </summary>
        /// <remarks>
        /// Chromosomes 1-22 are int 1-22. X = 23, Y = 24, and MT = 25.
        /// </remarks>
        public ReadOnlyDictionary<int, Chromosome> Chromosomes { get; }
        
        /// <summary>
        /// Creates a new isntance of <see cref="Dna"/>.
        /// </summary>
        public Dna()
        {
            this.chromosomes = new Dictionary<int, Chromosome>();
            this.Chromosomes = new ReadOnlyDictionary<int, Chromosome>(this.chromosomes);
        }

        /// <summary>
        /// Adds a <see cref="Chromosome"/> to the Dna.
        /// </summary>
        /// <param name="chromosome">The <see cref="Chromosome"/> to add.</param>
        public void AddChromosome(Chromosome chromosome)
        {
            if (chromosome == null) throw new ArgumentNullException(nameof(chromosome));

            this.chromosomes.Add(chromosome.Id, chromosome);
        }
    }
}
