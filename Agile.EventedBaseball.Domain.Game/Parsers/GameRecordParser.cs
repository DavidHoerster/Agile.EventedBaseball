using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agile.EventedBaseball.Entity.GameRecord;

namespace Agile.EventedBaseball.Domain.Game.Parsers
{
    public class GameRecordParser
    {
        public static GameRecordBase Parse(String record)
        {
            var recordSegments = record.Split(',');
            if (recordSegments.Length < 2)
            {
                throw new ArgumentException("Invalid game record");
            }

            GameRecordBase gameRecord = null;
            switch (recordSegments[0])
            {
                case "id":
                    gameRecord = new IdGameRecord(recordSegments[1].Trim());
                    break;
                case "version":
                    gameRecord = new VersionGameRecord(recordSegments[1].Trim());
                    break;
                case "info":
                    gameRecord = new InfoGameRecord(recordSegments[1].Trim(), recordSegments[2].Trim());
                    break;
                case "start":
                    gameRecord = new StartGameRecord(record);
                    break;
                case "sub":
                    gameRecord = new SubGameRecord(record);
                    break;
                case "com":
                    gameRecord = new CommentGameRecord(recordSegments[1]);
                    break;
                case "data":
                    gameRecord = new DataGameRecord(record);
                    break;
                case "play":
                    gameRecord = new PlayGameRecord(record);
                    break;
                default:
                    break;
            }

            return gameRecord;
        }

    }
}
