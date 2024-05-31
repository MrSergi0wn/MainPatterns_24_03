namespace MainPatterns.SpaceBattle.Commands
{
    public interface ICommand
    {
        public void Execute();

        public void Undo();
    }
}
