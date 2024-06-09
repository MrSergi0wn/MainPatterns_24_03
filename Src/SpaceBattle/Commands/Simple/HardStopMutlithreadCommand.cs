using SpaceBattle.Exceptions;

namespace SpaceBattle.Commands.Simple
{
    public class HardStopMultithreadCommand : ICommand
    {
        public void Execute()
        {
            throw new HardStopMultitreadException();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
