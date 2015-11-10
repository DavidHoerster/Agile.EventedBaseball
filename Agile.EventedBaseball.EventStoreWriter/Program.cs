using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Agile.EventedBaseball.EventStoreWriter.Actors;
using Akka.Actor;
using Akka.Configuration;
using EventStore.ClientAPI;

namespace Agile.EventedBaseball.EventStoreWriter
{
    class Program
    {
        internal static IEventStoreConnection _conn = null;
        static void Main(string[] args)
        {
            using (_conn = EventStoreConnection.Create(new IPEndPoint(IPAddress.Loopback, 1113)))
            {
                _conn.ConnectAsync().Wait();


                var config = ConfigurationFactory.ParseString(@"akka {  
                        actor {
                            provider = ""Akka.Remote.RemoteActorRefProvider, Akka.Remote""
                        }
                            remote {
                            helios.tcp {
                                port = 50000 #bound to a static port
                                hostname = localhost
                        }
                    }
                }");
                var system = ActorSystem.Create("atBatWriter", config); //akka.tcp://localhost:50000@atBatWriter/user

                var supervisor = system.ActorOf(AtBatSupervisor.Create(), "supervisor");

                Console.ReadLine();
            }
        }
    }
}