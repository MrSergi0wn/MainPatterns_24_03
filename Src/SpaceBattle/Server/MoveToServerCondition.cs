using System.Collections.Concurrent;
using SpaceBattle.Commands;
using SpaceBattle.Exceptions;

namespace SpaceBattle.Server
{
    public class MoveToServerCondition : CurrentServerCondition
    {
        public MoveToServerCondition(GameServer gameServer) : base(gameServer)
        {

        }

        public override void Handle(KeyValuePair<int, ConcurrentQueue<ICommand>> game)
        {
            try
            {
                game.Value.TryDequeue(out var userCommand);
                userCommand?.Execute();
            }
            catch (HardStopMultitreadException)
            {
                gameServer.HardStopped = true;
            }
            catch (SoftStopMultitreadException)
            {
                gameServer.SoftStopped = true;
            }
            catch (Exception)
            {
                //ignore
            }
        }
    }
}
