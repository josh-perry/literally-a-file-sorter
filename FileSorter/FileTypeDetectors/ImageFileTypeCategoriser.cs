using System.Collections.Generic;
using System.IO;

namespace FileSorter.FileTypeDetectors
{
    public class ImageFileTypeCategoriser : IFileTypeDetector
    {
        private readonly List<string> _imageFileExtensions = new List<string>
        {
            "ai",
            "bmp",
            "gif",
            "ico",
            "jpeg",
            "jpg",
            "png",
            "ps",
            "psd",
            "svg",
            "tif",
            "tiff"
        };

        public string Detect(File file)
        {
            var extension = Path.GetExtension(file.Name)?.Replace(".", "");

            return _imageFileExtensions.Contains(extension) ? "Images" : null;
        }
    }
}
