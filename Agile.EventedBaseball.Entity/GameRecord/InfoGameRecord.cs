using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.EventedBaseball.Entity.GameRecord
{
    public class InfoGameRecord : GameRecordBase
    {
        public InfoGameRecord(String key, String value) : base(GameRecordType.Info)
        {
            Key = key;
            Value = value;
        }

        public String Key { get; private set; }
        public String Value { get; private set; }
    }
}
