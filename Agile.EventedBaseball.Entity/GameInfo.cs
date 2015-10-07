using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.EventedBaseball.Entity
{
    public class GameInfo
    {
        public String Id { get; private set; }
        public String HomeTeam { get; private set; }
        public String VisitingTeam { get; private set; }

        public IDictionary<String, String> Info { get; private set; }

        public GameInfo(String id, String home, String away, IDictionary<String, String> info)
        {
            Id = id; Info = info;
            HomeTeam = home; VisitingTeam = away;
        }
    }
}
