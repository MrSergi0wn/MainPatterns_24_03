namespace MainPatterns.SpaceBattle.Commands.Simple
{
    public class RepeatCommand : ICommand
    {
        private ICommand command;

        public RepeatCommand(ICommand command)
        {
            this.command = command;
        }

        public void Execute()
        {
            command.Execute();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
