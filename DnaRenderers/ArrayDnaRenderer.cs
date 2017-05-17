using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Media.Imaging;
using DnaBase;
using DnaImageRendering;

namespace DnaRenderers
{
    /// <summary>
    /// Creates a image of a given <see cref="Dna"/> by drawing every protein bond as a colored pixel on the canvas.
    /// </summary>
    [Export(typeof(IDnaRendererUtility))]
    public class ArrayDnaRenderer : BaseDnaBitmapRendererUtility
    {
        /// <summary>
        /// Gets the name of the renderer.
        /// </summary>
        public override string Name => "Array";

        /// <summary>
        /// Creates the <see cref="BitmapImage"/> from the stored <see cref="Dna"/>.
        /// </summary>
        /// <param name="writeableBitmap">The <see cref="WriteableBitmap"/> to have date written to.</param>
        /// <param name="toRender">The <see cref="Dna"/> to render.</param>
        public override void CreateImage(WriteableBitmap writeableBitmap, Dna toRender)
        {
            writeableBitmap.Lock();

            unsafe
            {
                int pBackBuffer = (int)writeableBitmap.BackBuffer;

                // Compute the pixel's color.
                int color_data = 255 << 16; // R
                color_data |= 128 << 8;   // G
                color_data |= 255 << 0;   // B

                // Assign the color data to the pixel.
                *((int*)pBackBuffer) = color_data;
            }

            writeableBitmap.AddDirtyRect(new Int32Rect(0, 0, 250, 250));
            writeableBitmap.Unlock();
        }
    }
}
