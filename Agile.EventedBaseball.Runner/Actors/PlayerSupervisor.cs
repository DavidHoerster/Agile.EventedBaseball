using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agile.EventedBaseball.Messages;
using Akka.Actor;

namespace Agile.EventedBaseball.Runner.Actors
{
    public class PlayerSupervisor : ReceiveActor
    {
        private readonly ActorSelection _eventWriter;
        public static Props Create(ActorSelection eventWriter)
        {
            return Props.Create(() => new PlayerSupervisor(eventWriter));
        }

        public PlayerSupervisor(ActorSelection eventWriter)
        {
            _eventWriter = eventWriter;
            Receive<BatterEventMessage>(msg =>
            {
                _eventWriter.Tell(msg);
                var playerActor = Context.Child("batter-" + msg.PlayerId);
                if (playerActor == ActorRefs.Nobody)
                {
                    playerActor = Context.ActorOf(BatterActor.Create(msg.PlayerId), "batter-" + msg.PlayerId);
                }

                playerActor.Tell(msg);
            });

            Receive<EndOfFeed>(msg =>
            {
                _eventWriter.Tell(msg);
                var playerActors = Context.GetChildren();
                foreach (var playerActor in playerActors)
                {
                    playerActor.Tell(msg);
                }
            });
        }
    }
}
