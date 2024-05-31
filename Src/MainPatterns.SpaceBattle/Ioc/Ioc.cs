using MainPatterns.SpaceBattle.Ioc.Container;

namespace MainPatterns.SpaceBattle.Ioc
{
    public class Ioc : IIoc
    {
        private IIocContainer container = new IocContainer();

        public void SetContainer(IIocContainer container) => this.container = container;

        public void SetScope(string scope) => this.container.SetScope(scope);

        public T Resolve<T>(string key, params object[] args) => this.container.Resolve<T>(key, args);

        public void Bind(string key, Func<object[], object> strategy) => this.container.Bind(key, strategy);

        public void UnBind(string key) => this.container.Unbind(key);

        public bool IsAlreadyBind(string key) => this.container.IsAlreadyBind(key); 
    }
}
