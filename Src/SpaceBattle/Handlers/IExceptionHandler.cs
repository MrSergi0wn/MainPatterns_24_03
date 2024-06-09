using SpaceBattle.Commands;

namespace SpaceBattle.Handlers
{
    public interface IExceptionHandler
    {
        public void Handle(ICommand command, Exception exception);
    }
}
