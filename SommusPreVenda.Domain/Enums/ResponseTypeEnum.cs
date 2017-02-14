using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SommusPreVenda.Domain.Enums
{
    public enum ResponseTypeEnum
    {
        None = 0,  // Null
        Success = 1,  // True
        Warning = 2,  // False
        Error = 3,  // Exception
    }
}
