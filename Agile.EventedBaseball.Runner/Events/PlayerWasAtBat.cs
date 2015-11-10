using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.EventedBaseball.Runner.Events
{
    public class PlayerWasAtBat : EventBase
    {
        public String PlayerId { get; set; }
        public String Count { get; set; }
        public String Info { get; set; }
        public Boolean WasAHit { get; set; }

        public PlayerWasAtBat(String id, String count, String info, Boolean wasAHit) : base(Guid.NewGuid())
        {
            PlayerId = id;
            Count = count;
            Info = info;
            WasAHit = wasAHit;
        }
    }
}
