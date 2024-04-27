using MainPatterns.SpaceBattle.Calculations;
using MainPatterns.SpaceBattle.ObjectParameters;
using MainPatterns.SpaceBattle.Objects;

namespace MainPatterns.SpaceBattle.Commands
{
    public class MoveCommand : ICommand
    {
        private readonly Parameters specifications;

        public readonly SpaceObject spaceObject;

        public readonly Vector velocity;

        public MoveCommand(SpaceObject spaceObject, Vector velocity)
        {
            this.spaceObject = spaceObject;
            this.velocity = velocity;
            this.specifications = this.spaceObject.Get<Parameters>();
        }

        public void Execute()
        {
            try
            {
                this.specifications.Position += this.velocity;
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
