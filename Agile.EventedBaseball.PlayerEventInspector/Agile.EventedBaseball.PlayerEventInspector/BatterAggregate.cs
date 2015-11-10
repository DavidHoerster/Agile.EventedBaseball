using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agile.EventedBaseball.PlayerEventInspector.Events;

namespace Agile.EventedBaseball.PlayerEventInspector
{
    public class BatterAggregate : AggregateRoot
    {
        public BatterAggregate() { }

        public String PlayerId { get; private set; }
        public Int32 AtBats { get; private set; }
        public Int32 Hits { get; private set; }
        public Int32 Doubles { get; private set; }
        public Int32 Triples { get; private set; }
        public Int32 HomeRuns { get; private set; }
        public Int32 Walks { get; private set; }

        public Double Average
        {
            get
            {
                if (AtBats == 0)
                {
                    return 0;
                }
                return ((Double)Hits / (Double)AtBats);
            }
        }



        private void Apply(PlayerWasAtBat e)
        {
            Id = e.Id;
            PlayerId = e.PlayerId;
            AtBats++;
            if (e.WasAHit)
            {
                Hits++;
                switch (e.Info.ToLower())
                {
                    case "double":
                        Doubles++;
                        break;
                    case "triple":
                        Triples++;
                        break;
                    case "homerun":
                        HomeRuns++;
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
