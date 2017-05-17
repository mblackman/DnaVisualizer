using System;
using System.IO;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DnaBase;

namespace DnaImageRendering
{
    /// <summary>
    /// Provides a base implementation of a utility which takes a <see cref="Dna"/> and produces a <see cref="BitmapImage"/>.
    /// </summary>
    public sealed class DnaBitmapRenderer
    {
        private Dna dnaSource;

        public Lazy<Uri> SaveLocation { get; } = new Lazy<Uri>(() =>
         {
             var uri = new UriBuilder(Assembly.GetExecutingAssembly().CodeBase);
             return new Uri(Path.Combine(Path.GetDirectoryName(Uri.UnescapeDataString(uri.Path)), "Renders"));
         });

        /// <summary>
        /// Sets the <see cref="Dna"/> used to render the DNA <see cref="BitmapImage"/>.
        /// </summary>
        /// <param name="dna">The <see cref="Dna"/> to be rendered.</param>
        public void SetDnaSource(Dna dna)
        {
            this.dnaSource = dna;
        }

        /// <summary>
        /// Creates a <see cref="BitmapImage"/> from the stored <see cref="Dna"/> and stores it on the <see cref="IDnaRendererUtility"/>.
        /// </summary>
        /// <param name="width">Width of the <see cref="BitmapImage"/>.</param>
        /// <param name="height">Height of the <see cref="BitmapImage"/>.</param>
        /// <param name="renderer">The renderer to create the <see cref="BitmapImage"/> with.</param>
        public void CreateBitmapImage(int width, int height, IDnaRendererUtility renderer)
        {
            if (renderer == null) throw new ArgumentNullException(nameof(renderer));

            renderer.Image = Render(width, height, renderer).ToBitmapImage();
        }

        // Renders the image of a given size to a writeable bitmap.
        private WriteableBitmap Render(int width, int height, IDnaRendererUtility renderer)
        {
            var writeableBitmap = new WriteableBitmap(width, height, 300, 300, PixelFormats.Rgb24, null);

            if (this.dnaSource == null) return writeableBitmap;

            renderer.CreateImage(writeableBitmap, this.dnaSource);

            return writeableBitmap;
        }
    }
}
