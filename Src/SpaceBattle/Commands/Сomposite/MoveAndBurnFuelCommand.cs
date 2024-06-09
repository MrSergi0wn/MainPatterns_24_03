using SpaceBattle.Commands.Simple;
using SpaceBattle.Components.Calculations;
using SpaceBattle.Components.Objects;

namespace SpaceBattle.Commands.Сomposite
{
    public class MoveAndBurnFuelCommand : ICommand
    {
        private SpaceObject spaceObject;

        private readonly Vector velocity;

        private Fuel? fuel;

        private List<ICommand>? commands;

        private MacroCommand? macroCommand;

        public MoveAndBurnFuelCommand(SpaceObject spaceObject, Vector velocity)
        {
            this.spaceObject = spaceObject;
            this.velocity = velocity;
            Init();
        }

        private void Init()
        {
            fuel = spaceObject.GetComponent<Fuel>();

            commands = new List<ICommand>
            {
                new CheckFuelCommand(fuel),
                new BurnFuelCommand(fuel),
                new MoveCommand(spaceObject, velocity)
            };

            macroCommand = new MacroCommand(commands);
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
