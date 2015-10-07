using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agile.EventedBaseball.Runner.Messages;
using Akka.Actor;

namespace Agile.EventedBaseball.Runner.Actors
{
    public class PlayerSupervisor : ReceiveActor
    {
        public static Props Create()
        {
            return Props.Create(() => new PlayerSupervisor());
        }

        public PlayerSupervisor()
        {

            Receive<BatterEventMessage>(msg =>
            {
                var playerActor = Context.Child("batter-" + msg.PlayerId);
                if (playerActor == ActorRefs.Nobody)
                {
                    playerActor = Context.ActorOf(BatterActor.Create(msg.PlayerId), "batter-" + msg.PlayerId);
                }

                playerActor.Tell(msg);
            });

            Receive<EndOfFeed>(msg =>
            {
                var playerActors = Context.GetChildren();
                foreach (var playerActor in playerActors)
                {
                    playerActor.Tell(msg);
                }
            });
        }
    }
}
