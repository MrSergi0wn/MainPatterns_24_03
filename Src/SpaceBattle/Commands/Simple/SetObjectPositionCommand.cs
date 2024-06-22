using System.Numerics;
using SpaceBattle.Actions;

namespace SpaceBattle.Commands.Simple
{
    public class SetObjectPositionCommand : ICommand
    {
        private readonly IMovable objectToMove;
        private readonly Vector2 newPosition;

        public SetObjectPositionCommand(IMovable objectToMove, Vector2 newPosition)
        {
            this.objectToMove = objectToMove;
            this.newPosition = newPosition;
        }

        public void Execute()
        {
            objectToMove.Position = newPosition;
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}