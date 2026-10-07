namespace mdnote.Application;

public interface ITextFileService
{
    bool IsSupportedFilePath(string? filePath);

    string Load(string filePath);

    void Save(string filePath, string content);
}

public sealed class TextFileService(ITextFileReader fileReader, ITextFileWriter fileWriter) : ITextFileService
{
    public bool IsSupportedFilePath(string? filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
        {
            return false;
        }

        var extension = Path.GetExtension(filePath);
        return string.Equals(extension, ".md", StringComparison.OrdinalIgnoreCase)
            || string.Equals(extension, ".txt", StringComparison.OrdinalIgnoreCase);
    }

    public string Load(string filePath)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(filePath);

        if (!IsSupportedFilePath(filePath))
        {
            throw new NotSupportedException("Only Markdown and text files are supported.");
        }

        return fileReader.ReadAllText(filePath);
    }

    public void Save(string filePath, string content)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(filePath);
        ArgumentNullException.ThrowIfNull(content);

        if (!IsSupportedFilePath(filePath))
        {
            throw new NotSupportedException("Only Markdown and text files are supported.");
        }

        fileWriter.WriteAllText(filePath, content);
    }
}
