using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace DnaImageRendering
{
    /// <summary>
    /// Provides extensions for types built into the system.
    /// </summary>
    internal static class ExtensionMethods
    {
        /// <summary>
        /// Converts a <see cref="WriteableBitmap"/> into a <see cref="BitmapImage"/>.
        /// </summary>
        /// <param name="writeableBitmap">The <see cref="WriteableBitmap"/> to convert into a <see cref="BitmapImage"/>.</param>
        /// <returns>The newly created <see cref="BitmapImage"/>.</returns>
        public static BitmapImage ToBitmapImage(this WriteableBitmap writeableBitmap)
        {
            if (writeableBitmap == null) throw new ArgumentNullException(nameof(writeableBitmap));

            BitmapImage bitmapImage = new BitmapImage();
            using (MemoryStream stream = new MemoryStream())
            {
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(writeableBitmap));
                encoder.Save(stream);
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = stream;
                bitmapImage.EndInit();
                bitmapImage.Freeze();
            }
            return bitmapImage;
        }

        /// <summary>
        /// Saves the image stores on the <see cref="IDnaRendererUtility"/> to the given save path.
        /// </summary>
        /// <param name="renderer">The renderer that produced an image.</param>
        /// <param name="savePath">The path to save the file to.</param>
        /// <returns></returns>
        public static string SaveToFile(this IDnaRendererUtility renderer, string savePath)
        {
            const string fileType = ".jpg";
            var encoder = new JpegBitmapEncoder();
            var saveLocation = Path.Combine(savePath, renderer.Name);

            // TODO fix this hack to get a unique file.
            if (File.Exists(saveLocation + fileType)) saveLocation += Guid.NewGuid().ToString();

            saveLocation += fileType;

            encoder.Frames.Add(BitmapFrame.Create(renderer.Image));

            using (var filestream = new FileStream(saveLocation, FileMode.OpenOrCreate))
            {
                encoder.Save(filestream);
            }

            return saveLocation;
        }
    }
}
