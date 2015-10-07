using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agile.EventedBaseball.Domain.Game.Parsers;
using Agile.EventedBaseball.Entity.GameRecord;
using Agile.EventedBaseball.Runner.Actors;
using Agile.EventedBaseball.Runner.Messages;
using Akka.Actor;

namespace Agile.EventedBaseball.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("baseball");
            var actorCoordinator = system.ActorOf<GameCoordinator>("gameCoordinator");


            var files = Directory.GetFiles(@"C:\DATA\RetroSheet", "2014*.EV*");

            foreach (var file in files)
            {
                Console.WriteLine("Processing {0}", file);
                using (var stream = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    var reader = new StreamReader(stream);
                    var gameId = "";
                    while (!reader.EndOfStream)
                    {
                        var item = reader.ReadLine();
                        var record = GameRecordParser.Parse(item);

                        if (record is IdGameRecord)
                        {
                            gameId = ((IdGameRecord)record).Id;
                        }

                        var msg = new GameRecordMessage(gameId, record);

                        actorCoordinator.Tell(msg);
                    }

                    actorCoordinator.Tell(new EndOfFeed());
                }
                Console.WriteLine("Completed {0}", file);
            }

            Console.ReadLine();
        }
    }
}