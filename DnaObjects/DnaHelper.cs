using System;
using System.IO;

namespace DnaBase
{
    /// <summary>
    /// Utilities to help with the creation of <see cref="Dna"/>.
    /// </summary>
    public static class DnaHelper
    {
        /// <summary>
        /// Creates a <see cref="Dna"/> from a file given by the provided path.
        /// </summary>
        /// <param name="filePath">The file to load the <see cref="Dna"/> data from.</param>
        /// <param name="dnaSource">A <see cref="IDnaSourceReader"/> to read the data from. This source can be changed if the <see cref="Dna"/> file formats are different between data providers.</param>
        /// <returns>The newly created <see cref="Dna"/>.</returns>
        public static Dna CreateDna(string filePath, IDnaSourceReader dnaSource)
        {
            if (string.IsNullOrEmpty(filePath)) throw new ArgumentException("The file path cannot be null or empty", nameof(filePath));
            if (dnaSource == null) throw new ArgumentNullException(nameof(dnaSource));

            using (var reader = new StreamReader(filePath))
            {
                return dnaSource.ReadDnaFromStream(reader);
            }
        }
    }
}
