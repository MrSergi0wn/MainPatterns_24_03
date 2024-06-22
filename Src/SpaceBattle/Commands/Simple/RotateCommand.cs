using SpaceBattle.Actions;

namespace SpaceBattle.Commands.Simple
{
    public class RotateCommand : ICommand
    {
        private readonly IRotatable rotatable;

        public RotateCommand(IRotatable rotatable)
        {
            this.rotatable = rotatable;
        }

        public void Execute()
        {
            try
            {
                this.rotatable.Direction += this.rotatable.AngularVelocity % this.rotatable.Direction;
            }
            catch
            {
                throw new Exception();
            }
        }

        public void Undo()
        {
            this.rotatable.Direction -= this.rotatable.AngularVelocity % this.rotatable.Direction;
        }
    }
}
