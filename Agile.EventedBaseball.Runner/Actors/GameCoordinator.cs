using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agile.EventedBaseball.Entity.GameRecord;
using Agile.EventedBaseball.Messages;
using Akka.Actor;
using MongoDB.Driver;

namespace Agile.EventedBaseball.Runner.Actors
{
    public class GameCoordinator : ReceiveActor
    {

        public GameCoordinator()
        {
            var url = new MongoUrl("mongodb://localhost:27020/BaseballRetro");
            var client = new MongoClient(url);
            var db = client.GetDatabase(url.DatabaseName);
            var count = 1;

            var eventSupervisor = Context.ActorSelection("akka.tcp://atBatWriter@localhost:50000/user/supervisor");
            var playerSupervisor = Context.ActorOf(PlayerSupervisor.Create(eventSupervisor), "playerSupervisor");

            Receive<GameRecordMessage>(g =>
            {
                Console.WriteLine("writing record {0}", count.ToString());

                if (g.GameRecord is IdGameRecord)
                {
                    var idActor = Context.ActorOf(GameInfoActor.Create(g.GameId), "gameInfo-" + g.GameId);
                }

                if (g.GameRecord is InfoGameRecord)
                {
                    var info = ((InfoGameRecord)g.GameRecord);

                    var gameActor = Context.Child("gameInfo-" + g.GameId);

                    if (info.Key.Equals("save", StringComparison.OrdinalIgnoreCase))
                    {
                        gameActor.Tell(new GameInfoSaveMessage(g.GameId));
                    }
                    else
                    {
                        gameActor.Tell(new GameInfoMessage(g.GameId, info.Key, info.Value));
                    }
                }

                if (g.GameRecord is PlayGameRecord)
                {
                    var game = g.GameRecord as PlayGameRecord;
                    playerSupervisor.Tell(new BatterEventMessage(game.PlayerId, game.Count, game.Play));
                }

                count++;
                
            });

            Receive<EndOfFeed>(msg =>
            {
                playerSupervisor.Tell(msg);
            });
        }
    }
}