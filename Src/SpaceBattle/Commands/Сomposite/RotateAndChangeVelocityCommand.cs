using SpaceBattle.Commands.Simple;
using SpaceBattle.Components.Calculations;
using SpaceBattle.Components.Objects;
using SpaceBattle.ObjectParameters;

namespace SpaceBattle.Commands.Сomposite
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
            Init();
        }

        private void Init()
        {
            commands = new List<ICommand>()
            {
                new RotateCommand(spaceObject, spaceObject.GetComponent<Parameters>().Rotation!),
                new ChangeVelocityCommand(spaceObject, valueToChangeVelocity)
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

