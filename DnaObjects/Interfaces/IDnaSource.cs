using System.IO;

namespace DnaBase
{
    /// <summary>
    /// Represents utilities to take raw data given representing DNA into <see cref="Dna"/>.
    /// </summary>
    public interface IDnaSourceReader
    {
        /// <summary>
        /// Reads the data from the stream and returns a <see cref="Dna"/>.
        /// </summary>
        /// <param name="stream">The stream containing the DNA information.</param>
        /// <returns>The newly created <see cref="Dna"/>.</returns>
        Dna ReadDnaFromStream(StreamReader stream);
    }
}
