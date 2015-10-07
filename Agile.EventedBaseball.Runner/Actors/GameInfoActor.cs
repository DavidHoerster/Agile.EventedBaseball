using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agile.EventedBaseball.Entity;
using Agile.EventedBaseball.Runner.Messages;
using Akka.Actor;
using MongoDB.Driver;

namespace Agile.EventedBaseball.Runner.Actors
{
    public class GameInfoActor : ReceiveActor
    {
        public static Props Create(String gameId)
        {
            return Props.Create(() => new GameInfoActor(gameId));
        }


        private readonly String _gameId;
        private IDictionary<String, String> _dict;
        private String _home, _visitor;

        public GameInfoActor(String gameId)
        {
            _gameId = gameId;
            _dict = new Dictionary<String, String>();

            var url = new MongoUrl("mongodb://localhost:27020/BaseballRetro");
            var client = new MongoClient(url);
            var db = client.GetDatabase(url.DatabaseName);


            Receive<GameInfoMessage>(msg =>
            {
                _dict.Add(msg.Key, msg.Value);

                if (msg.Key.Equals("visteam", StringComparison.OrdinalIgnoreCase))
                {
                    _visitor = msg.Value;
                }
                if (msg.Key.Equals("hometeam", StringComparison.OrdinalIgnoreCase))
                {
                    _home = msg.Value;
                }
            });

            Receive<GameInfoSaveMessage>(msg =>
            {
                var coll = db.GetCollection<GameInfo>("gameInfo");
                coll.InsertOneAsync(new GameInfo(_gameId, _home, _visitor, _dict)).Wait();
            });
        }
    }
}
