namespace MainPatterns.SpaceBattle.Commands
{
    public class LogExceptionCommand : ICommand
    {
        private readonly ICommand command;

        private readonly Exception exception;

        private string? Log;

        public LogExceptionCommand(ICommand command, Exception exception)
        {
            this.command = command;
            this.exception = exception;
        }

        public void Execute()
        {
            this.Log = $"{DateTime.Now} При выполнении команды: {command.GetType()} возникла ошибка: {exception.Message}";
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }

        public string? GetLog()
        {
            return this.Log;
        }
    }
}
