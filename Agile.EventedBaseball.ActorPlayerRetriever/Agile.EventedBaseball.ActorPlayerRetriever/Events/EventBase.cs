using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.EventedBaseball.ActorPlayerRetriever.Events
{
    public abstract class EventBase
    {
        public EventBase(Guid id) { Id = id; }
        public Guid Id { get; set; }
    }
}
