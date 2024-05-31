using MainPatterns.SpaceBattle.Exceptions;

namespace MainPatterns.SpaceBattle.Commands.Сomposite
{
    public class MacroCommand : ICommand
    {
        private readonly List<ICommand> commands;

        private List<ICommand> executedCommands;

        public MacroCommand(List<ICommand> commands)
        {
            this.commands = commands;
            executedCommands = new List<ICommand>();
        }

        public void Execute()
        {
            foreach (var command in commands)
            {
                try
                {
                    command.Execute();
                    executedCommands.Add(command);
                }
                catch (Exception e)
                {
                    throw new CommandException(command, e);
                }
            }
        }

        public void Undo()
        {
            foreach (var command in commands) command.Undo();
        }
    }
}

