using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.EventedBaseball.Entity
{
    public enum BatterEventType
    {
        Out = 0,
        Single = 1,
        Double = 2,
        Triple = 3,
        Homer = 4,
        Walk = 5,
        NoPlay = 6,
    }
}