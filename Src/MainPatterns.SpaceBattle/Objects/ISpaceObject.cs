namespace MainPatterns.SpaceBattle.Objects;

public interface ISpaceObject
{
    void Add(IObject obj);

    T Get<T>() where T : IObject;
}