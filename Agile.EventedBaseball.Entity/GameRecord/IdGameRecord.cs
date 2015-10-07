using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.EventedBaseball.Entity.GameRecord
{
    public class IdGameRecord : GameRecordBase
    {
        public IdGameRecord(String recordValue) : base(GameRecordType.Id)
        {
            Id = recordValue;
            HomeTeam = recordValue.Substring(0, 3);
            Year = Convert.ToInt32(recordValue.Substring(3, 4));
            Month = Convert.ToInt32(recordValue.Substring(7, 2));
            Day = Convert.ToInt32(recordValue.Substring(9, 2));

            var gameNumberString = recordValue.Substring(11, 1);
            GameNumber tempGameNumber;
            GameNumber =
                GameNumber.TryParse<GameNumber>(gameNumberString, out tempGameNumber) ? 
                    tempGameNumber : GameNumber.SingleGame;
        }

        public String Id { get; private set; }
        public String HomeTeam { get; private set; }
        public Int32 Year { get; private set; }
        public Int32 Month { get; private set; }
        public Int32 Day { get; private set; }
        public GameNumber GameNumber { get; private set; }
    }
}
