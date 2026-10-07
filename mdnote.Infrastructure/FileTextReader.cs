using mdnote.Application;

namespace mdnote.Infrastructure;

public sealed class FileTextReader : ITextFileReader
{
    public string ReadAllText(string filePath) => File.ReadAllText(filePath);
}
