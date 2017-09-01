namespace FileSorter
{
    public interface IFileTypeDetector
    {
        string Detect(File file);
    }
}
