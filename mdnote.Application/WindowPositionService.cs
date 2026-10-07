using mdnote.Domain;

namespace mdnote.Application;

public interface IWindowPositionRepository
{
    WindowPosition? Load();

    void Save(WindowPosition position);
}

public interface IWindowPositionService
{
    WindowPosition? Load();

    void Save(WindowPosition position);
}

public sealed class WindowPositionService(IWindowPositionRepository repository) : IWindowPositionService
{
    public WindowPosition? Load() => repository.Load();

    public void Save(WindowPosition position) => repository.Save(position);
}
