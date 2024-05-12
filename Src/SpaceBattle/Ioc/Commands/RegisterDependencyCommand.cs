using MainPatterns.SpaceBattle.Commands;

namespace MainPatterns.SpaceBattle.Ioc.Commands
{
    public class RegisterDependencyCommand : ICommand
    {
        private string dependency;

        private Func<object[], object> strategy;

        public RegisterDependencyCommand(string dependency, Func<object[], object> strategy)
        {
            this.dependency = dependency;
            this.strategy = strategy;
        }

        public void Execute()
        {
            //var currentScope = Ioc.Resolve<IDictionary<string, Func<object[], object>>>("IoC.Scope.Current");
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
