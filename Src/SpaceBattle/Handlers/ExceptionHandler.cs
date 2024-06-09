using SpaceBattle.Commands;

namespace SpaceBattle.Handlers
{
    public class ExceptionHandler : IExceptionHandler
    {
        private IExceptionHandler exceptionHandler => new ExceptionHandler();
        
        public void Handle(ICommand command, Exception exception)
        {
            this.exceptionHandler.Handle(command, exception);
        }
    }
}
