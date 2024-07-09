using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceBattle.Commands;
using SpaceBattle.Exceptions;

namespace SpaceBattle.Server
{
    public class NormalServerCondition : CurrentServerCondition
    {
        public NormalServerCondition(GameServer gameServer) : base(gameServer)
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
