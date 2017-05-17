using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using General;

namespace DnaImageRendering
{
    /// <summary>
    /// Helper methods to load <see cref="IDnaRendererUtility"/> from the local machine.
    /// </summary>
    public static class DnaRendererLoader
    {
        /// <summary>
        /// Loads all the <see cref="IDnaRendererUtility"/>s from the executing directory's DnaRenderers subdirectory.
        /// </summary>
        /// <returns>A collection of all the <see cref="IDnaRendererUtility"/>.</returns>
        public static IEnumerable<IDnaRendererUtility> LoadRenderers()
        {
            var uri = new UriBuilder(Assembly.GetExecutingAssembly().CodeBase);
            var renderersPath = Path.Combine(Path.GetDirectoryName(Uri.UnescapeDataString(uri.Path)), "DnaRenderers");
            return new MEFLoader().LoadByType<IDnaRendererUtility>(renderersPath);
        }
    }
}
