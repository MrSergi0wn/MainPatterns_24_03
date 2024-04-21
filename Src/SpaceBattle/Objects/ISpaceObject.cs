using MainPatterns.SpaceBattle.Interfaces;

namespace MainPatterns.SpaceBattle.Objects;

public interface ISpaceObject : IObject
{
    void Add(IObject obj);

    T Get<T>() where T : IObject;
}