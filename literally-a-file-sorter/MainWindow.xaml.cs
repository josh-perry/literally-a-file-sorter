using System.Collections.Generic;
using FileSorter;
using FileSorter.FileTypeDetectors;

namespace literally_a_file_sorter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            var x = new Sorter
            {
                FileTypeDetectors = new List<IFileTypeDetector>
                {
                    new ImageFileTypeCategoriser(),
                    new AudioFileTypeCategoriser(),
                    new VideoFileTypeCategoriser()
                },
                RootDirectory = @"C:\Users\Josh\Downloads",
                TargetDirectory = @"C:\Users\Josh\Downloads"
            };
            
            x.GetFileListing();
            x.Sort();
        }
    }
}
