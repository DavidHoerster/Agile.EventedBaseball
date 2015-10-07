using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.EventedBaseball.Entity.GameRecord
{
    public abstract class GameRecordBase
    {
        public GameRecordBase(GameRecordType type)
        {
            GameRecordType = type;
        }
        public GameRecordType GameRecordType { get; protected set; }
    }
}
