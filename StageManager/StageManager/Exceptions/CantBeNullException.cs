using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageManager.Exceptions
{
    class CantBeNullException : Exception
    {
        public CantBeNullException(String message)
            : base(message)
        { }
    }
}
