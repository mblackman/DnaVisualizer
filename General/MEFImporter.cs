using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace General
{
    /// <summary>
    /// Imports objects from assemblies with a given type.
    /// </summary>
    /// <typeparam name="T">The type of object to import.</typeparam>
    public class MEFImporter<T> : IDisposable
    {
        /// <summary>
        /// Gets the collection of importers.
        /// </summary>
        [ImportMany(AllowRecomposition = true)]
        public IEnumerable<Lazy<T>> Imports { get; set; }

        /// <summary>
        /// The directory catelog of all the assemblies in a given directory.
        /// </summary>
        protected DirectoryCatalog directoryCatalog = null;

        /// <summary>
        /// Creates a new instance of <see cref="MEFImporter{T}"/> pointed at a given path.
        /// </summary>
        /// <param name="path">The path containing the assemblies.</param>
        public MEFImporter(string path)
        {
            directoryCatalog = new DirectoryCatalog(path);
        }

        /// <summary>
        /// Loads the imports from the catalogs.
        /// </summary>
        protected void DoImport()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(directoryCatalog);

            new CompositionContainer(catalog).ComposeParts(this);
        }

        /// <summary>
        /// Loads the objects from the assemblies.
        /// </summary>
        /// <returns>A collection of all the objects which could be imported.</returns>
        public IEnumerable<T> LoadByMEF()
        {
            DoImport();

            foreach (Lazy<T> module in Imports)
            {
                yield return module.Value;
            }
        }

        public void Dispose()
        {
            this.directoryCatalog?.Dispose();
        }
    }
}
