using MainPatterns.SpaceBattle.Calculations;
using MainPatterns.SpaceBattle.Objects;

namespace MainPatterns.SpaceBattle.Commands
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
            this.Init();
        }

        private void Init()
        {
            this.fuel = this.spaceObject.GetComponent<Fuel>();

            this.commands = new List<ICommand>
            {
                new CheckFuelCommand(this.fuel),
                new BurnFuelCommand(this.fuel),
                new MoveCommand(this.spaceObject, this.velocity)
            };

            this.macroCommand = new MacroCommand(this.commands);
        }

        public void Execute()
        {
            this.macroCommand?.Execute();
        }

        public void Undo()
        {
            this.macroCommand?.Undo();
        }
    }
}
