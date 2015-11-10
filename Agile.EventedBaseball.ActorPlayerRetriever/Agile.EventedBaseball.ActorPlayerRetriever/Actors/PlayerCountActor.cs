using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agile.EventedBaseball.ActorPlayerRetriever.Events;
using Agile.EventedBaseball.ActorPlayerRetriever.Messages;
using Akka.Actor;
using EventStore.ClientAPI;
using Newtonsoft.Json;

namespace Agile.EventedBaseball.ActorPlayerRetriever.Actors
{
    public class PlayerCountActor : ReceiveActor
    {
        private readonly String _playerId, _count;
        private Int32 _atBats, _hits;
        public static Props Create(String playerId, String count)
        {
            return Props.Create(() => new PlayerCountActor(playerId, count));
        }

        public PlayerCountActor(String playerId, String count)
        {
            _playerId = playerId; _count = count;


            Receive<FindPlayerAndCount>(msg =>
            {
                var streamId = msg.PlayerId + "-" + msg.Count;
                var slice = Program._conn.ReadStreamEventsForwardAsync(streamId,
                                StreamPosition.Start,
                                200,
                                false).Result;
                foreach (var evt in slice.Events)
                {
                    var e = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(evt.Event.Data), typeof(PlayerWasAtBat)) as PlayerWasAtBat;
                    Self.Tell(new PopulatePlayerStats(e.PlayerId, e.Count, e.Info, e.WasAHit));
                }
                Self.Tell(new Complete());
            });

            Receive<PopulatePlayerStats>(msg =>
            {
                _atBats++;
                if (msg.WasAHit)
                {
                    _hits++;
                }
            });

            Receive<Complete>(msg =>
            {
                Console.WriteLine("For player {0} with a count of {4}: " + 
                                    Environment.NewLine + 
                                    " At Bats: {1}  Hits: {2}  AVG: {3}",
                                    _playerId, _atBats, _hits, ((Double)_hits / (Double)_atBats), _count);
            });
        }
    }
}