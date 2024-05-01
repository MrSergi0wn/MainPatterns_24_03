using MainPatterns.SpaceBattle.Calculations;
using MainPatterns.SpaceBattle.ObjectParameters;
using MainPatterns.SpaceBattle.Objects;

namespace MainPatterns.SpaceBattle.Commands
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
            this.Init();
        }

        private void Init()
        {
            this.parameters = this.spaceObject.GetComponent<Parameters>();
        }

        public void Execute()
        {
            if (!this.parameters!.Velocity!.Equals(new Vector(0, 0)))
            {
                this.parameters!.Velocity += this.valueToChangeVelocity;
            }
            else
            {
                throw new Exception();
            }
        }

        public void Undo()
        {
            if (!this.parameters!.Velocity!.Equals(new Vector(0, 0)))
            {
                this.parameters!.Velocity -= this.valueToChangeVelocity;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
