using System.Windows.Media.Imaging;
using DnaBase;

namespace DnaImageRendering
{
    /// <summary>
    /// A base implementation of the <see cref="IDnaRendererUtility"/>.
    /// </summary>
    public abstract class BaseDnaBitmapRendererUtility : IDnaRendererUtility
    {
        /// <summary>
        /// Gets the name of the renderer.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Gets the <see cref="BitmapImage"/> created from the render.
        /// </summary>
        public BitmapImage Image { get; set; }

        /// <summary>
        /// Creates the <see cref="BitmapImage"/> from the stored <see cref="Dna"/>.
        /// </summary>
        /// <param name="writeableBitmap">The <see cref="WriteableBitmap"/> to have date written to.</param>
        /// <param name="toRender">The <see cref="Dna"/> to render.</param>
        public abstract void CreateImage(WriteableBitmap writeableBitmap, Dna toRender);
    }
}
