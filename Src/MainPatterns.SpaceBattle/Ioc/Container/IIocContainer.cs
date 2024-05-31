namespace MainPatterns.SpaceBattle.Ioc.Container;

public interface IIocContainer
{
    void SetScope(string scope);
    T Resolve<T>(string key, params object[] args);
    void Bind(string key, Func<object[], object> strategy);
    void Unbind(string key);
    bool IsAlreadyBind(string key); 
}