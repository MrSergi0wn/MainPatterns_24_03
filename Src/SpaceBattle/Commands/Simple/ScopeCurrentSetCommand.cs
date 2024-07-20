using System.Collections.Concurrent;
using SpaceBattle.IocContainer;

namespace SpaceBattle.Commands.Simple
{
    public class ScopeCurrentSetCommand : ICommand
    {
        private readonly IocC ioC;
        private readonly ConcurrentDictionary<string, Scope> scopes;
        private readonly string scopeIdToSet;

        public ScopeCurrentSetCommand(IocC ioC, ConcurrentDictionary<string, Scope> scopes, string scopeIdToSet)
        {
            this.ioC = ioC;
            this.scopes = scopes;
            this.scopeIdToSet = scopeIdToSet;
        }

        public void Execute()
        {
            if (!scopes.TryGetValue(scopeIdToSet, out var scopeToSet))
            {
                throw new Exception($"Scope {scopeIdToSet} not registered");
            }

            ioC.CurrentScope.Value = scopeToSet;
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}