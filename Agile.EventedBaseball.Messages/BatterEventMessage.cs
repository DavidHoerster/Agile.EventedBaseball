using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.EventedBaseball.Messages
{
    public class BatterEventMessage
    {
        public readonly String PlayerId;
        public readonly String Count;
        public readonly String BatterEvent;

        public BatterEventMessage(String playerId, String count, String batterEvent)
        {
            PlayerId = playerId; Count = count; BatterEvent = batterEvent;
        }
    }
}