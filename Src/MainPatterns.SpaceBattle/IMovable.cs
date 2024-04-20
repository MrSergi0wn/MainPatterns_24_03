using MainPatterns.SpaceBattle.Calculations;

namespace MainPatterns.SpaceBattle
{
    public interface IMovable
    {
        void SetPosition(Vector position);

        Vector GetPosition();       

        Vector GetVelocity();
    }
}
