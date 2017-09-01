using System.IO;

namespace FileSorter
{
    public class File
    {
        /// <summary>
        /// Full path to the file.
        /// </summary>
        public string FullPath;

        /// <summary>
        /// Just the filename without the path.
        /// </summary>
        public string Name => Path.GetFileName(FullPath);
        
        /// <summary>
        /// The file category. Used to decide where to sort files.
        /// </summary>
        public string Type;

        /// <summary>
        /// Has this file been sorted yet?
        /// </summary>
        public bool Sorted = false;

        /// <summary>
        /// Constructor. Takes the fullpath to a file.
        /// </summary>
        /// <param name="fullpath"></param>
        public File(string fullpath)
        {
            FullPath = fullpath;
        }
    }
}