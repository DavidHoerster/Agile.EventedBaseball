using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.EventedBaseball.Messages
{
    public class GameInfoMessage
    {
        public readonly String GameId;
        public readonly String Key;
        public readonly String Value;

        public GameInfoMessage(String id, String key, String val)
        {
            GameId = id; Key = key; Value = val;
        }
    }
}
