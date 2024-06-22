using System.Numerics;
using SpaceBattle.Actions;

namespace SpaceBattle.Commands.Simple
{
    public class MoveWithVelocityCommand : ICommand
    {
        private readonly IMovable movable;
        private readonly Vector2 velocity;

        public MoveWithVelocityCommand(IMovable movable, Vector2 velocity)
        {
            this.movable = movable;
            this.velocity = velocity;
        }

        public void Execute()
        {
            movable.Position += velocity;
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}