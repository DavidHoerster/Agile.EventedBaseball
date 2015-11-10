using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.EventedBaseball.ActorPlayerRetriever.Actors
{
    public class PopulatePlayerStats
    {
        public readonly String PlayerId;
        public readonly String Count;
        public readonly String Info;
        public readonly Boolean WasAHit;

        public PopulatePlayerStats(String playerId, String count, String info, Boolean wasAHit)
        {
            PlayerId = playerId; Count = count; Info = info;
            WasAHit = wasAHit;
        }
    }
}
