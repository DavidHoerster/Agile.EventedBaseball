using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.EventedBaseball.Entity.GameRecord
{
    public class CommentGameRecord : GameRecordBase
    {
        public CommentGameRecord(String comment) : base(GameRecordType.Comment)
        {
            Comment = comment.Trim('"');
        }

        public String Comment { get; private set; }
    }
}
