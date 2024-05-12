using MainPatterns.SpaceBattle.Ioc.Container;

namespace MainPatterns.SpaceBattle.Ioc;

public interface IIoc
{
    void SetContainer(IIocContainer container);
    void SetScope(string scope);
    T Resolve<T>(string key, params object[] args);
    void Bind(string key, Func<object[], object> strategy);
    void UnBind(string key);
    bool IsAlreadyBind(string key);
}