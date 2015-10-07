using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.EventedBaseball.Entity.GameRecord
{
    public class VersionGameRecord : GameRecordBase
    {
        public VersionGameRecord(String recordValue) : base(GameRecordType.Version)
        {
            Version = Convert.ToInt32(recordValue);
        }

        public Int32 Version { get; private set; }
    }
}
