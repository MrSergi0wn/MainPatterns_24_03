using SpaceBattle.Components.Actions;

namespace SpaceBattle.Components.Objects;

public interface ISpaceObject : IObject
{
    void Add(IObject obj);

    T GetComponent<T>() where T : IObject;
}