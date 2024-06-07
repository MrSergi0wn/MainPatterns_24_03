using SpaceBattle.Components.Calculations;
using SpaceBattle.Components.Objects;
using SpaceBattle.ObjectParameters;

namespace SpaceBattle.Commands.Simple
{
    public class RotateCommand : ICommand
    {
        private readonly Parameters specifications;

        public readonly SpaceObject spaceObject;

        public readonly Vector rotationAngle;

        public RotateCommand(SpaceObject spaceObject, Vector rotationAngle)
        {
            this.spaceObject = spaceObject;
            this.rotationAngle = rotationAngle;
            specifications = this.spaceObject.GetComponent<Parameters>();
        }

        public void Execute()
        {
            try
            {
                specifications.Rotation += rotationAngle;
            }
            catch
            {
                throw new Exception();
            }
        }

        public void Undo()
        {
            specifications.Rotation -= rotationAngle;
        }
    }
}
