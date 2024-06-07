using SpaceBattle.Components.Calculations;
using SpaceBattle.Components.Objects;
using SpaceBattle.ObjectParameters;

namespace SpaceBattle.Commands.Simple
{
    public class ChangeVelocityCommand : ICommand
    {
        private readonly SpaceObject spaceObject;

        private readonly Vector? valueToChangeVelocity;

        private Parameters? parameters;

        public ChangeVelocityCommand(SpaceObject spaceObject, Vector? valueToChangeVelocity)
        {
            this.spaceObject = spaceObject;
            this.valueToChangeVelocity = valueToChangeVelocity;
            Init();
        }

        private void Init()
        {
            parameters = spaceObject.GetComponent<Parameters>();
        }

        public void Execute()
        {
            if (!parameters!.Velocity!.Equals(new Vector(0, 0)))
            {
                parameters!.Velocity += valueToChangeVelocity;
            }
            else
            {
                throw new Exception();
            }
        }

        public void Undo()
        {
            if (!parameters!.Velocity!.Equals(new Vector(0, 0)))
            {
                parameters!.Velocity -= valueToChangeVelocity;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}

