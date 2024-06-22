using SpaceBattle.Actions;
using SpaceBattle.Commands.Simple;

namespace SpaceBattle.Commands.Сomposite
{
    public class MoveAndBurnFuelCommand : ICommand
    {
        private IMovable movable;

        private IBurningFuel burningFuel;

        private readonly MacroCommand? macroCommand;

        public MoveAndBurnFuelCommand(IMovable movable, IBurningFuel burningFuel)
        {
            this.movable = movable;
            this.burningFuel = burningFuel;
            this.macroCommand = new MacroCommand(new CheckFuelCommand(this.burningFuel), new BurnFuelCommand(this.burningFuel),
                new MoveCommand(movable));
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
