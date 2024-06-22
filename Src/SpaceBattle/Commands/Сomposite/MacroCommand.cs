using SpaceBattle.Exceptions;

namespace SpaceBattle.Commands.Сomposite
{
    public class MacroCommand : ICommand
    {
        private readonly ICommand[] commands;

        private List<ICommand> executedCommands;

        public MacroCommand(params ICommand[] commands)
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

