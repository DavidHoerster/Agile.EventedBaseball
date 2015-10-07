using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.EventedBaseball.Entity.GameRecord
{
    public enum GameRecordType
    {
        Id = 0,
        Version = 1,
        Info = 2,
        Start = 3,
        Play = 4,
        Comment = 5,
        Sub = 6,
        Data = 7,
    }
}
