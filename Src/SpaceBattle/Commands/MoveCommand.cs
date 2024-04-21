using MainPatterns.SpaceBattle.Calculations;
using MainPatterns.SpaceBattle.Objects;

namespace MainPatterns.SpaceBattle.Commands
{
    public class MoveCommand
    {
        //public readonly SpaceObject SpaceObject;

        //public readonly Vector Direction;

        //private Specifications specifications;

        public readonly SpaceObject spaceObject;

        private readonly Specifications specifications;

        public MoveCommand(SpaceObject spaceObject)
        {
            this.spaceObject = spaceObject;
            this.specifications = this.spaceObject.Get<Specifications>();


            //this.SpaceObject = spaceObject;
            //this.Direction = direction;
            //this.specifications = this.SpaceObject.Get<Specifications>();
        }

        public void Execute()
        {
            try
            {
                this.specifications.Position += this.specifications.Velocity;   
            }
            catch
            {
                throw new NullReferenceException();
            }
        }
    }
}
