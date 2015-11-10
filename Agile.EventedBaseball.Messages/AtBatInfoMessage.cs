using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.EventedBaseball.Messages
{
    public class AtBatInfoMessage
    {
        public readonly String PlayerId;
        public readonly String Count;
        public readonly Boolean IsHit;
        public readonly String HitInfo;

        public AtBatInfoMessage(String id, String count, Boolean isHit, String info)
        {
            PlayerId = id;
            Count = count;
            IsHit = isHit;
            HitInfo = info;
        }
    }
}
