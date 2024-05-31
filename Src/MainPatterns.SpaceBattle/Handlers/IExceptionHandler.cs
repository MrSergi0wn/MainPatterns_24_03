using MainPatterns.SpaceBattle.Commands;

namespace MainPatterns.SpaceBattle.Handlers
{
    public interface IExceptionHandler
    {
        public void Handle(ICommand command, Exception exception);
    }
}
