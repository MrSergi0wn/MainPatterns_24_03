using System.Numerics;
using SpaceBattle.Actions;
using SpaceBattle.Commands.Simple;

namespace SpaceBattle.Commands.Сomposite
{
    public class RotateAndChangeVelocityCommand : ICommand
    {
        private IMovable movable;

        private IRotatable rotateble;

        private Vector2 valueToChangeVelocity;

        private MacroCommand? macroCommand;

        public RotateAndChangeVelocityCommand(IMovable movable, IRotatable rotatable, Vector2 valueToChangeVelocity)
        {
            this.movable = movable;
            this.rotateble = rotatable;
            this.valueToChangeVelocity = valueToChangeVelocity;
            this.macroCommand = new MacroCommand(new RotateCommand(this.rotateble), new MoveWithVelocityCommand(this.movable, this.valueToChangeVelocity));
        }

        public void Execute()
        {
            macroCommand?.Execute();
        }

        public void Undo()
        {
            macroCommand?.Undo();
        }
    }
}

