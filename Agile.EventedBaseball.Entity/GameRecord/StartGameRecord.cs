using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.EventedBaseball.Entity.GameRecord
{
    public class StartGameRecord : GameRecordBase
    {
        public StartGameRecord(String record) : base(GameRecordType.Start)
        {
            var recordSegments = record.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (recordSegments.Length != 6)
            {
                throw new ArgumentException("invalid record passed");
            }
            PlayerId = recordSegments[1];
            PlayerName = recordSegments[2].Trim('"');
            IsHomeTeam = recordSegments[3].Equals("1", StringComparison.OrdinalIgnoreCase);
            BattingOrder = Convert.ToInt32(recordSegments[4]);

            FieldingPosition tempFieldPos;
            FieldingPosition = FieldingPosition.TryParse<FieldingPosition>(recordSegments[5], out tempFieldPos) ? 
                                tempFieldPos : FieldingPosition.None;
        }

        public String PlayerId { get; private set; }
        public String PlayerName { get; private set; }
        public Boolean IsHomeTeam { get; private set; }
        public Int32 BattingOrder { get; private set; }
        public FieldingPosition FieldingPosition { get; private set; }
    }
}
