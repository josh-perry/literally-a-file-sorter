using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileSorter
{
    public class Sorter
    {
        /// <summary>
        /// Which directory are we watching?
        /// </summary>
        public string RootDirectory;

        /// <summary>
        /// Which directory do we want to sort our files into?
        /// </summary>
        public string TargetDirectory;

        /// <summary>
        /// A list of all the files to watch.
        /// </summary>
        public List<File> Files = new List<File>();

        /// <summary>
        /// A detector to determine how the files should be sorted
        /// </summary>
        public List<IFileTypeDetector> FileTypeDetectors;

        /// <summary>
        /// Update the list of files.
        /// </summary>
        public void GetFileListing()
        {
            foreach (var file in Directory.GetFiles(RootDirectory))
            {
                Files.Add(new File(file));
            }
        }

        /// <summary>
        /// Iterate the files and detect their types, then sort them.
        /// </summary>
        public void Sort()
        {
            foreach (var detector in FileTypeDetectors)
            {
                foreach (var file in Files.Where(x => !x.Sorted))
                {
                    // Detect filetype
                    file.Type = detector.Detect(file);

                    // Sort accordingly
                    Sort(file);
                }
            }
        }

        /// <summary>
        /// Sort an individual file into the categories specified by the detector.
        /// </summary>
        /// <param name="file"></param>
        private void Sort(File file)
        {
            var newDirectory = file.Type ?? "Unsorted";
            newDirectory = Path.Combine(RootDirectory, newDirectory);

            if (!Directory.Exists(newDirectory))
            {
                Directory.CreateDirectory(newDirectory);
            }

            System.IO.File.Move(file.FullPath, Path.Combine(newDirectory, file.Name));
            file.Sorted = true;
        }
    }
}
