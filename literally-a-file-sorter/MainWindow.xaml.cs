using System.Collections.Generic;
using System.Windows;
using FileSorter;
using FileSorter.FileTypeDetectors;

namespace literally_a_file_sorter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private const string SourceDialogTitle = "Select a folder to be sorted";
        private const string OutputDialogTitle = "Select a parent folder to put the sorted files";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBrowseSource_OnClick(object sender, RoutedEventArgs e)
        {
            ShowDirectoryDialog(DialogType.Source);
        }

        private void ButtonBrowseOutput_OnClick(object sender, RoutedEventArgs e)
        {
            ShowDirectoryDialog(DialogType.Output);
        }

        private void SortButton_OnClick(object sender, RoutedEventArgs e)
        {
            DoSorting();
        }

        private void DoSorting()
        {
            var sorter = new Sorter
            {
                FileTypeDetectors = new List<IFileTypeDetector>
                {
                    new ImageFileTypeCategoriser(),
                    new AudioFileTypeCategoriser(),
                    new VideoFileTypeCategoriser()
                },
                RootDirectory = TextBoxSourceDirectory.Text,
                TargetDirectory = TextBoxOutputDirectory.Text
            };

            sorter.GetFileListing();
            sorter.Sort();
        }

        private void ShowDirectoryDialog(DialogType type)
        {
            // Show dialog
            var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog
            {
                Description = type == DialogType.Source ? SourceDialogTitle : OutputDialogTitle,
                UseDescriptionForTitle = true
            };
            
            // If the user cancelled or didn't select a path, return
            if (dialog.ShowDialog() != true)
            {
                return;
            }

            // Set relevant textbox contents
            if (type == DialogType.Source)
            {
                TextBoxSourceDirectory.Text = dialog.SelectedPath;
                return;
            }

            TextBoxOutputDirectory.Text = dialog.SelectedPath;
        }
    }
}
