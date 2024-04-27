using MainPatterns.SpaceBattle.Calculations;
using MainPatterns.SpaceBattle.ObjectParameters;
using MainPatterns.SpaceBattle.Objects;

namespace MainPatterns.SpaceBattle.Commands
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
            this.specifications = this.spaceObject.Get<Parameters>();
        }

        public void Execute()
        {
            try
            {
                this.specifications.Rotation += this.rotationAngle;
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
