using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuroMonitorTask.Domain.Types
{
    public enum ResultType
    {
        NotANumber = 0,
        NumberTooLarge = 1,
        NumberTooSmall = 2,
        ValidButNegativeNumber = 3,
        Valid = 4,
    }
}
