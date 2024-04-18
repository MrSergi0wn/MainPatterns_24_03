using MainPatterns.SpaceBattle.Calculations;

namespace MainPatterns.SpaceBattle
{
    public interface IMovable
    {
        Vector GetPosition();

        void SetPosition(Vector position);

        Vector GetVelocity();
    }
}
