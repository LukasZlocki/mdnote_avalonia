namespace mdnote.Application;

public interface ITextFileWriter
{
    void WriteAllText(string filePath, string content);
}
