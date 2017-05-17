using System.Collections.Generic;
using System.Linq;

namespace General
{
    /// <summary>
    /// Loads assemblies through the MEF
    /// </summary>
    public class MEFLoader
    {
        private readonly Dictionary<string, List<object>> importers = new Dictionary<string, List<object>>();

        /// <summary>
        /// Gets a <see cref="MEFImporter{T}"/> pointed at the given path.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of objects to load.</typeparam>
        /// <param name="path">The path to the assemblies.</param>
        /// <returns>The <see cref="MEFImporter{T}"/> to load the assemblies.</returns>
        protected MEFImporter<T> GetImporter<T>(string path)
        {
            var importerList = GetImporterList(path);
            var importer = importerList.OfType<MEFImporter<T>>().FirstOrDefault();

            if (importer == null)
            {
                importer = new MEFImporter<T>(path);
                importerList.Add(importer);
            }

            return importer;
        }

        /// <summary>
        /// Gets a list of importers for the given path.
        /// </summary>
        /// <param name="path">Path to the assemblies.</param>
        /// <returns>List of importers.</returns>
        protected List<object> GetImporterList(string path)
        {
            if (!this.importers.ContainsKey(path))
            {
                importers.Add(path, new List<object>());
            }

            return importers[path];
        }

        /// <summary>
        /// Loads all the assemblies of the given type from the given path.
        /// </summary>
        /// <typeparam name="T">The type of objects to load.</typeparam>
        /// <param name="path">The path to the assemblies.</param>
        /// <returns>A collection of objects loaded from the assemblies.</returns>
        public virtual IEnumerable<T> LoadByType<T>(string path)
        {
            return GetImporter<T>(path).LoadByMEF();
        }
    }
}
