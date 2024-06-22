namespace SpaceBattle.Actions
{
    public interface IResolvable
    {
        T Resolve<T>(string key, params object[] args);
    }
}