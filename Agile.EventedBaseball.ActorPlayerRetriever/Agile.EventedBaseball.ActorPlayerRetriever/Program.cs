using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Agile.EventedBaseball.ActorPlayerRetriever.Actors;
using Agile.EventedBaseball.ActorPlayerRetriever.Messages;
using Akka.Actor;
using EventStore.ClientAPI;

namespace Agile.EventedBaseball.ActorPlayerRetriever
{
    class Program
    {
        internal static IEventStoreConnection _conn = null;
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("playerComposition");

            var searcher = system.ActorOf(PlayerSearchSupervisor.Create(), "supervisor");

            //  akka://playerCOmposition/user/supervisor

            using (_conn = EventStoreConnection.Create(new IPEndPoint(IPAddress.Loopback, 1113)))
            {
                _conn.ConnectAsync().Wait();

                Console.WriteLine("Player ID: ");
                var playerId = Console.ReadLine();

                for (int balls = 0; balls < 4; balls++)
                {
                    for (int strikes = 0; strikes < 3; strikes++)
                    {
                        var count = $"{balls}{strikes}";
                        searcher.Tell(new FindPlayerAndCount(playerId, count));
                    }
                }

                Console.ReadLine();
            }
        }
    }
}