using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DnaBase;
using DnaImageRendering;

namespace DnaVisualizer
{
    /// <summary>
    /// A collection of data and methods to interact with the Dna visualizer view.
    /// </summary>
    public class DnaVisualizerViewModel : INotifyPropertyChanged
    {
        private Dna currentDna;
        private string dnaBitmapLocation;

        /// <summary>
        /// Gets the location of the image to display.
        /// </summary>
        public string DnaBitmapImageLocation
        {
            get { return this.dnaBitmapLocation; }
            private set
            {
                this.dnaBitmapLocation = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets the collection of <see cref="IDnaRendererUtility"/>.
        /// </summary>
        public IEnumerable<IDnaRendererUtility> DnaRenderers { get; }

        /// <summary>
        /// Triggered whenever a property on <see cref="DnaVisualizerViewModel"/> is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Creates a new instance of <see cref="DnaVisualizerViewModel"/>.
        /// </summary>
        public DnaVisualizerViewModel()
        {
            this.DnaRenderers = DnaRendererLoader.LoadRenderers();
        }

        /// <summary>
        /// Sets the <see cref="Dna"/> for the <see cref="DnaVisualizerViewModel"/> and renders the images for the held renderers.
        /// </summary>
        /// <param name="dna">The <see cref="Dna"/> to render.</param>
        public void SetDna(Dna dna)
        {
            this.currentDna = dna;
            ImageManager.Instance.SetDnaSource(dna);
        }

        /// <summary>
        /// Renders a bitmap for the selected renderer and sets the image.
        /// </summary>
        public void RenderImage(IDnaRendererUtility renderer)
        {
            this.DnaBitmapImageLocation = ImageManager.Instance.RenderImage(renderer);
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (string.IsNullOrEmpty(propertyName)) return;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
