using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DnaBase;
using DnaImageRendering;
using Microsoft.Win32;

namespace DnaVisualizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DnaVisualizerViewModel viewModel => (DnaVisualizerViewModel)this.DataContext;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (openFileDialog.ShowDialog() == true)
            {
                var existingCursor = Mouse.OverrideCursor;
                Mouse.OverrideCursor = Cursors.Wait;

                try
                {
                    var dna = DnaHelper.CreateDna(openFileDialog.FileName, new TwentyThreeAndMeDnaSource());
                    this.viewModel.SetDna(dna);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occured while attempting to read the raw DNA data.");
                    Debug.WriteLine(ex.Message);
                }
                finally
                {
                    Mouse.OverrideCursor = existingCursor;
                }
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            var menuItem = (sender as MenuItem)?.DataContext as IDnaRendererUtility;

            if (menuItem == null) return;

            this.viewModel.RenderImage(menuItem);
        }
    }
}
