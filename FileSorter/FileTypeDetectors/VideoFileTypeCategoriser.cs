using System.Collections.Generic;
using System.IO;

namespace FileSorter.FileTypeDetectors
{
    public class VideoFileTypeCategoriser : IFileTypeDetector
    {
        private readonly List<string> _videoFileExtensions = new List<string>
        {
            "3g2",
            "3gp",
            "avi",
            "flv",
            "h264",
            "m4v",
            "mkv",
            "mov",
            "mp4",
            "mpg",
            "mpeg",
            "rm",
            "swf",
            "vob",
            "wmv"
        };

        public string Detect(File file)
        {
            var extension = Path.GetExtension(file.Name)?.Replace(".", "");

            return _videoFileExtensions.Contains(extension) ? "Videos" : null;
        }
    }
}
