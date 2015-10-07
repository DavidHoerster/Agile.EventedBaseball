using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.EventedBaseball.Entity.GameRecord
{
    public class DataGameRecord : GameRecordBase
    {
        public DataGameRecord(String record) : base(GameRecordType.Data)
        {
            var recordSegments = record.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (recordSegments.Length != 4)
            {
                throw new ArgumentException("invalid record passed");
            }

            DataType = recordSegments[1];
            PlayerId = recordSegments[2];
            EarnedRuns = Convert.ToInt32(recordSegments[3]);
        }

        public String DataType { get; private set; }
        public String PlayerId { get; private set; }
        public Int32 EarnedRuns { get; private set; }
    }
}
