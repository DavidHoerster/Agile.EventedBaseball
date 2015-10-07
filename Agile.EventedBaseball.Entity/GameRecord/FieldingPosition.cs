using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.EventedBaseball.Entity.GameRecord
{
    public enum FieldingPosition
    {
        None = 0,
        Pitcher = 1,
        Catcher = 2,
        FirstBase = 3,
        SecondBase = 4,
        ThirdBase = 5,
        Shortstop = 6,
        LeftField = 7,
        CenterField = 8,
        RightField = 9,
        DesignatedHitter = 10,
        PinchHitter = 11,
        PinchRunner = 12,
    }
}
