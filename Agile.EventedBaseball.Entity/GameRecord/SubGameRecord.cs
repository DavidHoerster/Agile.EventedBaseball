using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.EventedBaseball.Entity.GameRecord
{
    public class SubGameRecord : StartGameRecord
    {
        public SubGameRecord(String record) : base(record)
        {
            base.GameRecordType = GameRecordType.Sub;
        }
    }
}
