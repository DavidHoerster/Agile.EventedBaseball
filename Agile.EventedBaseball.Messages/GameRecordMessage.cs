using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agile.EventedBaseball.Entity.GameRecord;

namespace Agile.EventedBaseball.Messages
{
    public class GameRecordMessage
    {
        public readonly String GameId;
        public readonly GameRecordBase GameRecord;

        public GameRecordMessage(String id, GameRecordBase record) { GameId = id; GameRecord = record; }
    }
}
