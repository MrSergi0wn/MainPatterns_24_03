using SpaceBattle.Server;

namespace SpaceBattle.Commands.Simple
{
    public class ChangeServerConditionToNormalCommand : ICommand
    {
        private readonly GameServer gameServer;

        public ChangeServerConditionToNormalCommand(GameServer gameServer)
        {
            this.gameServer = gameServer;
        }

        public void Execute()
        {
            this.gameServer.ServerCondition = new NormalServerCondition(gameServer);
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
