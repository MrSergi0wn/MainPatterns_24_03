namespace MainPatterns.SpaceBattle.Commands
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
            this.command.Execute();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
