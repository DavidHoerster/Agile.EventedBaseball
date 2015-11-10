using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.EventedBaseball.ActorPlayerRetriever.Messages
{
    public class FindPlayerAndCount
    {
        public readonly String PlayerId;
        public readonly String Count;

        public FindPlayerAndCount(String playerId, String count)
        {
            PlayerId = playerId; Count = count;
        }
    }
}
