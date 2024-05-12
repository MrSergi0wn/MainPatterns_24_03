namespace MainPatterns.SpaceBattle.Ioc.Resolver;

public interface IDependencyResolver
{
    object Resolve(string key, params object[] args);
}