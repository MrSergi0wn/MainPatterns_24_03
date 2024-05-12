namespace MainPatterns.SpaceBattle.Ioc.Resolver
{
    public class DependencyResolver : IDependencyResolver
    {
        private IDictionary<string, Func<object[], object>> dependencies;

        public DependencyResolver(object scope)
        {
            this.dependencies = (IDictionary<string, Func<object[], object>>) scope;
        }

        public object Resolve(string key, params object[] args)
        {
            var dependenciesDictionary = this.dependencies;

            while (true)
            {
                if (dependencies.TryGetValue(key, out var strategy))
                {
                    return strategy(args);
                }

                dependenciesDictionary = (IDictionary<string, Func<object[], object>>) dependenciesDictionary["IoC.Scope.Parent"](args);
            }
        }
    }
}
