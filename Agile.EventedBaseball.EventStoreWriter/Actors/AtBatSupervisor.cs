using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agile.EventedBaseball.Domain.Game.Parsers;
using Agile.EventedBaseball.Entity;
using Agile.EventedBaseball.Messages;
using Akka.Actor;

namespace Agile.EventedBaseball.EventStoreWriter.Actors
{
    public class AtBatSupervisor : ReceiveActor
    {
        public static Props Create()
        {
            return Props.Create(() => new AtBatSupervisor());
        }

        public AtBatSupervisor()
        {
            Receive<BatterEventMessage>(msg =>
            {
                Boolean isHit = false;
                BatterEventType hitType = BatterEventParser.BatterEventResult(msg.BatterEvent);

                switch (hitType)
                {
                    case BatterEventType.Single:
                    case BatterEventType.Double:
                    case BatterEventType.Triple:
                    case BatterEventType.Homer:
                        isHit = true;
                        break;
                    default:
                        isHit = false;
                        break;
                }

                var atBatActor = Context.Child(msg.PlayerId + "-" + msg.Count);
                if (atBatActor == ActorRefs.Nobody)
                {
                    atBatActor = Context.ActorOf(AtBatEventWriterActor.Create(msg.PlayerId, msg.Count), msg.PlayerId + "-" + msg.Count);
                }
                atBatActor.Tell(new AtBatInfoMessage(msg.PlayerId, msg.Count, isHit, hitType.ToString()));
            });

            Receive<EndOfFeed>(msg =>
            {
                Console.WriteLine("About to write events to store");
                var atBatActors = Context.GetChildren();
                foreach (var actor in atBatActors)
                {
                    actor.Tell(new Complete());
                }
            });
        }
    }
}