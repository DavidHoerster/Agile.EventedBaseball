using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Agile.EventedBaseball.PlayerEventInspector.Events;
using EventStore.ClientAPI;
using Newtonsoft.Json;

namespace Agile.EventedBaseball.PlayerEventInspector
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Player ID: ");
            var playerId = Console.ReadLine();

            Console.WriteLine("Count: ");
            var count = Console.ReadLine();

            BatterAggregate batter1;
            using (var conn = EventStoreConnection.Create(new IPEndPoint(IPAddress.Loopback, 1113)))
            {
                conn.ConnectAsync().Wait();
                batter1 = LoadEvents(conn, playerId + "-" + count);
            }

            Console.WriteLine("For player {0} with a count of {4}: " + Environment.NewLine + " At Bats: {1}  Hits: {2}  AVG: {3}", 
                batter1.PlayerId, batter1.AtBats, batter1.Hits, batter1.Average, count);

            Console.ReadLine();
        }


        internal static BatterAggregate LoadEvents(IEventStoreConnection conn, String streamId)
        {
            var player = new BatterAggregate();

            var slice = conn.ReadStreamEventsForwardAsync(streamId,
                StreamPosition.Start,
                200,
                false).Result;

            var events = slice.Events.Select(e => JsonConvert.DeserializeObject(Encoding.UTF8.GetString(e.Event.Data), typeof(PlayerWasAtBat)) as EventBase);

            player.LoadFromHistory(events);

            return player;
        }

    }
}
