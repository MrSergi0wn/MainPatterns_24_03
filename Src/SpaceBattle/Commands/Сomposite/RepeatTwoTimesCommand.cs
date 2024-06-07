namespace SpaceBattle.Commands.Сomposite
{
    public class RepeatTwoTimesCommand : ICommand
    {
        private ICommand command;

        public int timesToRepeat;

        public RepeatTwoTimesCommand(ICommand command, int timesToRepeat = 1)
        {
            this.command = command;
            this.timesToRepeat = timesToRepeat;
        }

        public void Execute()
        {
            for (var i = 0; i < timesToRepeat; i++) command.Execute();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
