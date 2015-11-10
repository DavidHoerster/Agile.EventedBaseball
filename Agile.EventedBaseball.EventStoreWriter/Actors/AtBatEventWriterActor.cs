using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Agile.EventedBaseball.EventStoreWriter.Events;
using Agile.EventedBaseball.Messages;
using Akka.Actor;
using EventStore.ClientAPI;
using Newtonsoft.Json;

namespace Agile.EventedBaseball.EventStoreWriter.Actors
{
    public class AtBatEventWriterActor : ReceiveActor
    {

        public static Props Create(String playerId, String count)
        {
            return Props.Create(() => new AtBatEventWriterActor(playerId, count));
        }

        private readonly String _playerId, _count, _eventId;
        private List<PlayerWasAtBat> _events;
        public AtBatEventWriterActor(String playerId, String count)
        {
            _playerId = playerId;
            _count = count;
            _eventId = _playerId + "-" + _count;
            _events = new List<PlayerWasAtBat>();

            Receive<AtBatInfoMessage>(msg =>
            {
                _events.Add(new PlayerWasAtBat(msg.PlayerId, msg.Count, msg.HitInfo, msg.IsHit));
            });

            Receive<Complete>(msg =>
            {
                var eventData = _events.Select(e => new EventData(e.Id,
                                                            e.GetType().Name,
                                                            true,
                                                            Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(e)),
                                                            Encoding.UTF8.GetBytes("{}")))
                                                            .ToArray();

                Program._conn.AppendToStreamAsync(_eventId,
                        ExpectedVersion.Any,
                        eventData).PipeTo(Self);

            });
        }
    }
}