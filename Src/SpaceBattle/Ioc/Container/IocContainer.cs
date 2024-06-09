using static System.String;

namespace SpaceBattle.Ioc.Container
{
    public class IocContainer : IIocContainer
    {
        private IDictionary<(string, string), Func<object[], object>>? container;

        private string currentScope;

        public IocContainer()
        {
            this.container = new Dictionary<(string, string), Func<object[], object>>();
            this.currentScope = "defaultScope";
        }

        public void SetScope(string scope)
        {
            if (!IsNullOrWhiteSpace(scope))
            {
                this.currentScope = scope;
            }
            else
            {
                throw new Exception("Scope не может быть нулевым!");
            }
        }

        public T Resolve<T>(string? key, params object[] args)
        {
            if (this.container != null)
            {
                this.container.TryGetValue((this.currentScope, key)!, out var strategy);

                return (T)strategy?.Invoke(args)!;
            }

            return default!;
        }

        public void Bind(string key, Func<object[], object> strategy)
        {
            if (IsNullOrEmpty(key)) throw new Exception("Key не может быть нулевым!");

            if (strategy == null) throw new Exception("Strategy не может быть нулевой!");

            if (container!.ContainsKey((this.currentScope, key))) Unbind(key);

            this.container!.Add((this.currentScope, key), strategy);
        }

        public void Unbind(string key) =>
            this.container?.Remove((this.currentScope, key));

        public bool IsAlreadyBind(string key)
        {
            return this.container != null && container.ContainsKey((this.currentScope, key));
        }
    }
}
