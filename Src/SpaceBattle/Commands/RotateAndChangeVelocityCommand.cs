using MainPatterns.SpaceBattle.Calculations;
using MainPatterns.SpaceBattle.ObjectParameters;
using MainPatterns.SpaceBattle.Objects;

namespace MainPatterns.SpaceBattle.Commands
{
    public class RotateAndChangeVelocityCommand : ICommand
    {
        private SpaceObject spaceObject;

        private Vector? valueToChangeVelocity;

        private List<ICommand>? commands;

        private MacroCommand? macroCommand;

        public RotateAndChangeVelocityCommand(SpaceObject spaceObject, Vector? valueToChangeVelocity)
        {
            this.spaceObject = spaceObject;
            this.valueToChangeVelocity = valueToChangeVelocity;
            this.Init();
        }

        private void Init()
        {
            this.commands = new List<ICommand>()
            {
                new RotateCommand(this.spaceObject, this.spaceObject.GetComponent<Parameters>().Rotation!),
                new ChangeVelocityCommand(this.spaceObject, this.valueToChangeVelocity)
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
