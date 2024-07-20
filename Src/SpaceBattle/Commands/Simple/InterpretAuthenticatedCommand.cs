using SpaceBattle.Actions;
using SpaceBattle.MessageBus;
using System.Collections.Concurrent;
using SpaceBattle.Authentication;

namespace SpaceBattle.Commands.Simple
{
    public class InterpretAuthenticatedCommand: ICommand
    {
        private readonly GameMessage gameMessage;

        private readonly Dictionary<int, ConcurrentQueue<ICommand>> games;

        private readonly IResolvable ioc;

        public InterpretAuthenticatedCommand(GameMessage gameMessage, Dictionary<int, ConcurrentQueue<ICommand>> games, IResolvable ioc)
        {
            this.gameMessage = gameMessage;
            this.games = games;
            this.ioc = ioc;
        }

        public void Execute()
        {
            var authenticationService = this.ioc.Resolve<AuthenticationService>("Services.Authentication");
            if (!authenticationService.ValidateToken(this.gameMessage.ArgsJson!)) return;
            var gameQueue = games[this.gameMessage.GameId];
            var gameObject = ioc.Resolve<IMovable>(this.gameMessage.GameObjectId!);
            var command = ioc.Resolve<ICommand>(this.gameMessage.GameOperationId!, gameObject);
            gameQueue.Enqueue(command);
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
