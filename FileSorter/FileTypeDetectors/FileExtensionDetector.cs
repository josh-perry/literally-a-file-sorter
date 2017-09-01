using System.IO;

namespace FileSorter.FileTypeDetectors
{
    /// <summary>
    /// Implements IFileTypeDetector
    /// </summary>
    public class FileExtensionDetector : IFileTypeDetector
    {
        /// <summary>
        /// Returns the file extension as a category.
        /// </summary>
        /// <param name="file">The file to detect the type of</param>
        /// <returns></returns>
        public string Detect(File file)
        {
            var extension = Path.GetExtension(file.Name);

            return extension;
        }
    }
}
