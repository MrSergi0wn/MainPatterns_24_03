using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceBattle.Server;

namespace SpaceBattle.Commands.Simple
{
    public class ChangeServerConditionToMoveToCommand : ICommand
    {
        private readonly GameServer gameServer;

        public ChangeServerConditionToMoveToCommand(GameServer gameServer)
        {
            this.gameServer = gameServer;
        }

        public void Execute()
        {
            this.gameServer.ServerCondition = new MoveToServerCondition(this.gameServer);
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
