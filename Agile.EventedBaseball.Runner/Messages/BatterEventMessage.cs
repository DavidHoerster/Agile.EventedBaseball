using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.EventedBaseball.Runner.Messages
{
    public class BatterEventMessage
    {
        public readonly String PlayerId;
        public readonly String Count;
        public readonly String BatterEvent;

        public BatterEventMessage(String id, String count, String batterEvent)
        {
            PlayerId = id; Count = count; BatterEvent = batterEvent;
        }
    }
}