using MainPatterns.SpaceBattle.Commands;
using MainPatterns.SpaceBattle.Handlers;

namespace MainPatterns.SpaceBattle.Runner
{
    public class CommandsRunner : ICommandsRunner
    {
        private Queue<ICommand> queue;

        private readonly IExceptionHandler exceptionHandler;

        public CommandsRunner()
        {
            this.queue = new Queue<ICommand>();
            this.exceptionHandler = new ExceptionHandler();
        }

        public void AddCommandToTheQueue(ICommand command)
        {
            queue.Enqueue(command);
        }

        public int GetQueueSize()
        {
            return this.queue.Count;
        }

        public void ExecuteQueue()
        {
            var command = queue.Dequeue();

            try
            {
                command.Execute();
            }
            catch (Exception e)
            {
                this.exceptionHandler.Handle(command, e);
            }
        }
    }
}
