using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agile.EventedBaseball.Domain.Game.Parsers;
using Agile.EventedBaseball.Entity;
using Agile.EventedBaseball.Messages;
using Akka.Actor;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Agile.EventedBaseball.Runner.Actors
{
    public class BatterActor : ReceiveActor
    {
        public static Props Create(String playerId)
        {
            return Props.Create(() => new BatterActor(playerId));
        }

        private readonly String _playerId;
        private BatterInfo _batterInfo;

        public BatterActor(String playerId)
        {
            _playerId = playerId;
            _batterInfo = new BatterInfo();
            _batterInfo.Id = playerId;

            var url = new MongoUrl("mongodb://localhost:27020/BaseballRetro");
            var client = new MongoClient(url);
            var db = client.GetDatabase(url.DatabaseName);

            Receive<BatterEventMessage>(msg =>
            {
                BatterEventType hitType = BatterEventParser.BatterEventResult(msg.BatterEvent);
                switch (hitType)
                {
                    case BatterEventType.Double:
                        _batterInfo.Doubles++;
                        _batterInfo.Hits++;
                        _batterInfo.PlateAppearances++;
                        _batterInfo.AtBats++;
                        break;
                    case BatterEventType.Homer:
                        _batterInfo.HomeRuns++;
                        _batterInfo.Hits++;
                        _batterInfo.PlateAppearances++;
                        _batterInfo.AtBats++;
                        break;
                    case BatterEventType.Single:
                        _batterInfo.Hits++;
                        _batterInfo.PlateAppearances++;
                        _batterInfo.AtBats++;
                        break;
                    case BatterEventType.Triple:
                        _batterInfo.Hits++;
                        _batterInfo.Triples++;
                        _batterInfo.PlateAppearances++;
                        _batterInfo.AtBats++;
                        break;
                    case BatterEventType.Walk:
                        _batterInfo.Walks++;
                        _batterInfo.PlateAppearances++;
                        break;
                    case BatterEventType.NoPlay:
                        _batterInfo.PlateAppearances++;
                        break;
                    default:
                        _batterInfo.PlateAppearances++;
                        _batterInfo.AtBats++;
                        break;
                }

            });

            Receive<EndOfFeed>(msg =>
            {
                var coll = db.GetCollection<BatterInfo>("batterInfo");
                coll.ReplaceOneAsync(new BsonDocument("_id", _batterInfo.Id), _batterInfo, new UpdateOptions { IsUpsert = true });
            });
        }
    }
}
