using System.Windows.Media.Imaging;
using DnaBase;

namespace DnaImageRendering
{
    /// <summary>
    /// Provides an interface to render <see cref="Dna"/> to a bitmap.
    /// </summary>
    public interface IDnaRendererUtility
    {
        /// <summary>
        /// Gets the name of the renderer.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the <see cref="BitmapImage"/> created from the render.
        /// </summary>
        BitmapImage Image { get; set; }

        /// <summary>
        /// Creates the <see cref="BitmapImage"/> from the stored <see cref="Dna"/>.
        /// </summary>
        /// <param name="writeableBitmap">The <see cref="WriteableBitmap"/> to have date written to.</param>
        /// <param name="toRender">The <see cref="Dna"/> to render.</param>
        void CreateImage(WriteableBitmap writeableBitmap, Dna toRender);
    }
}
