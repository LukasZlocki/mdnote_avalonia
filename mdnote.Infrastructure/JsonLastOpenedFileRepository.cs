using System.Text.Json;
using mdnote.Application;

namespace mdnote.Infrastructure;

public sealed class JsonLastOpenedFileRepository : ILastOpenedFileRepository
{
    private readonly string _filePath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "mdnote",
        "last-opened-file.json");

    public string? Load()
    {
        try
        {
            return File.Exists(_filePath)
                ? JsonSerializer.Deserialize(File.ReadAllText(_filePath), MdnoteJsonSerializerContext.Default.String)
                : null;
        }
        catch (IOException)
        {
            return null;
        }
        catch (UnauthorizedAccessException)
        {
            return null;
        }
        catch (JsonException)
        {
            return null;
        }
    }

    public void Save(string filePath)
    {
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_filePath)!);
            File.WriteAllText(_filePath, JsonSerializer.Serialize(filePath, MdnoteJsonSerializerContext.Default.String));
        }
        catch (IOException)
        {
        }
        catch (UnauthorizedAccessException)
        {
        }
    }
}
