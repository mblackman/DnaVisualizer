using System.IO;

namespace General
{
    public static class Utilities
    {
        /// <summary>
        /// Creates a folder for the given sub folder name and returns the path.
        /// </summary>
        /// <param name="subFolderName">The name of the sub directory to create.</param>
        /// <returns>The path to the new directory.</returns>
        public static string CreateApplicationFileSubDirectory(string subFolderName)
        {
            var tempFolder = Path.Combine(Path.GetTempPath(), "vDNAResources");
            if (!Directory.Exists(tempFolder)) Directory.CreateDirectory(tempFolder);

            var subFolder = Path.Combine(tempFolder, subFolderName);
            if (!Directory.Exists(subFolder)) Directory.CreateDirectory(subFolder);
            return subFolder;
        }
    }
}
