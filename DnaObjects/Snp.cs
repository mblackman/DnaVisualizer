namespace DnaBase
{
    /// <summary>
    /// Represents a Single Nucleotide Polymorphism.
    /// </summary>
    public class Snp
    {
        /// <summary>
        /// Gets the gene identifier
        /// </summary>
        public string Rsid { get; }

        /// <summary>
        /// Gets the position of the SNP
        /// </summary>
        public int Position { get; }

        /// <summary>
        /// Gets the genotype of the SNP
        /// </summary>
        public Genotype Genotype { get; }

        /// <summary>
        /// Creates a instance of a <see cref="Snp"/>.
        /// </summary>
        /// <param name="rsid">The gene identifier.</param>
        /// <param name="position">The gene position.</param>
        /// <param name="genotype">The genotype.</param>
        public Snp(string rsid, int position, Genotype genotype)
        {
            this.Rsid = rsid;
            this.Position = position;
            this.Genotype = genotype;
        }
    }
}
