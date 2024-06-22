using SpaceBattle.Actions;

namespace SpaceBattle.Commands.Simple
{
    public class MoveCommand : ICommand
    {
        public readonly IMovable movable;

        public MoveCommand(IMovable movable)
        {
            this.movable = movable;
        }

        public void Execute()
        {
            if (this.movable == null)
            {
                throw new Exception("Невозможно сдвинуть объект!");
            }

            if (float.IsInfinity(this.movable.Position.X) ||
                float.IsInfinity(this.movable.Position.Y) ||
                float.IsNaN(this.movable.Position.X) ||
                float.IsNaN(this.movable.Position.Y))
            {
                throw new Exception("Невозможно получить положение объекта!");
            }

            if (float.IsInfinity(this.movable.Velocity.X) ||
                float.IsInfinity(this.movable.Velocity.Y) ||
                float.IsNaN(this.movable.Velocity.X) ||
                float.IsNaN(this.movable.Velocity.Y))
            {
                throw new Exception("Невозможно получить скорость объекта!");
            }

            this.movable.Position += this.movable.Velocity;
        }

        public void Undo()
        {
            this.movable.Position -= this.movable.Velocity;
        }
    }
}
