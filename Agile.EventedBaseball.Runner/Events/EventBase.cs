using System;

namespace Agile.EventedBaseball.Runner.Events
{
    public abstract class EventBase
    {
        public Guid Id { get; set; }

        public EventBase(Guid id) { Id = id; }
    }
}