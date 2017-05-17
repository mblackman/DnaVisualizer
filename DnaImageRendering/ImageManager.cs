using System;
using System.IO;
using DnaBase;

namespace DnaImageRendering
{
    /// <summary>
    /// Handles rendering and managing bitmaps.
    /// </summary>
    public class ImageManager
    {
        private static readonly Lazy<ImageManager> instance = new Lazy<ImageManager>(() => new ImageManager());
        private readonly DnaBitmapRenderer dnaBitmapRenderer = new DnaBitmapRenderer();
        private int renderWidth = 320, renderHeight = 320;
        private static readonly string executingFolder = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
        private readonly string errorImageLocation = executingFolder + "\\..\\..\\Resources\\MissingImage.bmp";
        private readonly string saveLocation = General.Utilities.CreateApplicationFileSubDirectory("Resources");

        /// <summary>
        /// Gets the singleton instance of <see cref="ImageManager"/>.
        /// </summary>
        public static ImageManager Instance => instance.Value;

        private ImageManager()
        {
            if (!Directory.Exists(saveLocation))
            {
                Directory.CreateDirectory(saveLocation);
            }
        }

        /// <summary>
        /// Sets the size of the images to be rendered.
        /// </summary>
        /// <param name="width">Width of the image to be rendered.</param>
        /// <param name="height">Height of the image to be rendered.</param>
        public void SetRenderSize(int width, int height)
        {
            this.renderWidth = width;
            this.renderHeight = height;
        }

        /// <summary>
        /// Sets the <see cref="Dna"/> to use for rendering.
        /// </summary>
        /// <param name="dna"></param>
        public void SetDnaSource(Dna dna)
        {
            this.dnaBitmapRenderer.SetDnaSource(dna);
        }

        /// <summary>
        /// Renders the stored <see cref="Dna"/> with the given <see cref="IDnaRendererUtility"/>.
        /// </summary>
        /// <param name="renderer">The renderer to create the image with.</param>
        /// <returns>The location of the image.</returns>
        public string RenderImage(IDnaRendererUtility renderer)
        {
            if (renderer == null) return errorImageLocation;

            this.dnaBitmapRenderer.CreateBitmapImage(this.renderWidth, this.renderHeight, renderer);

            if (renderer.Image == null) return errorImageLocation;

            return renderer.SaveToFile(saveLocation);
        }
    }
}
