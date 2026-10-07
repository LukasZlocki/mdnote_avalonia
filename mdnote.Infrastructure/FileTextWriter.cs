using mdnote.Application;

namespace mdnote.Infrastructure;

public sealed class FileTextWriter : ITextFileWriter
{
    public void WriteAllText(string filePath, string content) => File.WriteAllText(filePath, content);
}
