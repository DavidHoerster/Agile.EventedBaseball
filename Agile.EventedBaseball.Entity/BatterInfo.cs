using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.EventedBaseball.Entity
{
    public class BatterInfo
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public Int32 PlateAppearances { get; set; }
        public Int32 AtBats { get; set; }
        public Int32 Hits { get; set; }
        public Int32 Doubles { get; set; }
        public Int32 Triples { get; set; }
        public Int32 HomeRuns { get; set; }
        public Int32 Walks { get; set; }
        public Double Average { get { return Hits / AtBats; } }
    }
}
