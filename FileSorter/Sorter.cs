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
                var f = new File(file);

                if (ShouldIgnore(f))
                {
                    continue;
                }

                Files.Add(f);
            }
        }

        /// <summary>
        /// Should this file be ignored?
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public bool ShouldIgnore(File file)
        {
            return Path.GetExtension(file.FullPath) == ".tmp";
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
            newDirectory = Path.Combine(TargetDirectory, newDirectory);

            var newPath = Path.Combine(newDirectory, file.Name);

            if (!Directory.Exists(newDirectory))
            {
                Directory.CreateDirectory(newDirectory);
            }

            if (System.IO.File.Exists(newPath))
            {
                return;
            }

            System.IO.File.Move(file.FullPath, newPath);
            file.Sorted = true;
        }
    }
}
