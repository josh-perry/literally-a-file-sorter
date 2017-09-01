using System.Collections.Generic;
using System.IO;

namespace FileSorter.FileTypeDetectors
{
    public class AudioFileTypeCategoriser : IFileTypeDetector
    {
        private readonly List<string> _audioFileExtensions = new List<string>
        {
            "aif",
            "cda",
            "mid",
            "midi",
            "mp3",
            "mpa",
            "ogg",
            "wav",
            "wma",
            "wpl"
        };

        public string Detect(File file)
        {
            var extension = Path.GetExtension(file.Name)?.Replace(".", "");
            
            return _audioFileExtensions.Contains(extension) ? "Audio" : null;
        }
    }
}