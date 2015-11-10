using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agile.EventedBaseball.ActorPlayerRetriever.Messages;
using Akka.Actor;

namespace Agile.EventedBaseball.ActorPlayerRetriever.Actors
{
    public class PlayerSearchSupervisor : ReceiveActor
    {

        public static Props Create()
        {
            return Props.Create(() => new PlayerSearchSupervisor());
        }


        public PlayerSearchSupervisor()
        {
            Receive<FindPlayerAndCount>(msg =>
            {

                var playerCountActor = Context.Child(String.Format("{0}-{1}", msg.PlayerId, msg.Count));
                if (playerCountActor == ActorRefs.Nobody)
                {
                    playerCountActor = Context.ActorOf(PlayerCountActor.Create(msg.PlayerId, msg.Count), String.Format("{0}-{1}", msg.PlayerId, msg.Count));
                }

                playerCountActor.Tell(msg);
            });
        }
    }
}
