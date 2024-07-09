using System.Collections.Concurrent;
using SpaceBattle.Actions;
using SpaceBattle.Commands;
using SpaceBattle.Commands.Simple;
using SpaceBattle.Ioc;
using SpaceBattle.MessageBus;

namespace SpaceBattle.Server
{
    public class GameServer
    {
        public Dictionary<int, ConcurrentQueue<ICommand>> Games { get; }

        private readonly IResolvable ioc;

        public List<IMovable> CollisionObjects { get; } = new();

        public CurrentServerCondition ServerCondition { get; set; }

        public bool SoftStopped { get; set; }

        public bool HardStopped { get; set; }

        public GameServer(IResolvable ioc, ConcurrentQueue<ICommand> gameCommands)
        {
            this.Games = new Dictionary<int, ConcurrentQueue<ICommand>> { { 1, gameCommands } };
            this.ioc = ioc;
            this.ServerCondition = new InitialServerCondition(this);
        }

        public void RunMultithreadCommands()
        {
            foreach (var game in Games)
            {
                Task.Factory.StartNew(() =>
                {
                    while (!HardStopped || (!SoftStopped && !game.Value.Any()))
                    {
                        ServerCondition.Handle(game);
                    }
                });
            }
        }

        public void ReceiveMessage(GameMessage message)
        {
            new InterpretCommand(message, Games, this.ioc).Execute();
        }

        public void AuthenticReceiveMessage(GameMessage message)
        {
            new InterpretAuthenticatedCommand(message, Games, this.ioc).Execute();
        }
    }
}
