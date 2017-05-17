using System;
using System.IO;

namespace DnaBase
{

    /// <summary>
    /// Represents utilities to take raw data given representing DNA into <see cref="Dna"/> from a raw data file from 23andMe.
    /// </summary>
    public class TwentyThreeAndMeDnaSource : IDnaSourceReader
    {
        /// <summary>
        /// Reads the data from the stream and returns a <see cref="Dna"/>.
        /// </summary>
        /// <param name="stream">The stream containing the DNA information.</param>
        /// <returns>The newly created <see cref="Dna"/>.</returns>
        public Dna ReadDnaFromStream(StreamReader stream)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            string line = string.Empty;
            var dna = new Dna();

            while ((line = stream.ReadLine()) != null)
            {
                if (!line.StartsWith("#", StringComparison.Ordinal))
                {
                    string[] splitLine = line.Split('\t');
                    string rsid = splitLine[0], chromosomeString = splitLine[1], positionString = splitLine[2], genotypeString = splitLine[3];
                    int chromosomeId = Chromosome.GetIdFromString(chromosomeString);
                    int position = int.Parse(positionString);

                    if (!dna.Chromosomes.TryGetValue(chromosomeId, out Chromosome chromosome))
                    {
                        chromosome = new Chromosome(chromosomeId);
                        dna.AddChromosome(chromosome);
                    }

                    chromosome.AddSnp(rsid, position, GenoTypeExtensions.FromString(genotypeString));
                }
            }

            return dna;
        }
    }
}
