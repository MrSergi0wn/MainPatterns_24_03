using MainPatterns.SpaceBattle.Calculations;
using MainPatterns.SpaceBattle.ObjectParameters;
using MainPatterns.SpaceBattle.Objects;

namespace MainPatterns.SpaceBattle.Commands.Simple
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
            specifications = this.spaceObject.GetComponent<Parameters>();
        }

        public void Execute()
        {
            try
            {
                specifications.Position += velocity;
            }
            catch
            {
                throw new Exception();
            }
        }

        public void Undo()
        {
            specifications.Position -= velocity;
        }
    }
}
