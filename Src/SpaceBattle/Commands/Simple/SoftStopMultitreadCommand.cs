using SpaceBattle.Exceptions;

namespace SpaceBattle.Commands.Simple
{
    public class SoftStopMultitreadCommand : ICommand
    {
        public void Execute()
        {
            throw new SoftStopMultitreadException();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
