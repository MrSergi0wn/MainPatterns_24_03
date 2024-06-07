using System.Collections.Concurrent;
using SpaceBattle.Commands;

namespace SpaceBattle.Server
{
    public abstract class CurrentConditionOfServer
    {
        protected readonly GameServer gameServer;

        protected CurrentConditionOfServer(GameServer gameServer)
        {
            this.gameServer = gameServer;
        }

        public abstract void Handle(KeyValuePair<int, ConcurrentQueue<ICommand>> game);
    }
}
