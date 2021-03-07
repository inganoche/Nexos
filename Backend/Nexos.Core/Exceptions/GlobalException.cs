using System;
using System.Collections.Generic;
using System.Text;

namespace Nexos.Core.Exceptions
{
    public class GlobalException: Exception
    {
        public GlobalException()
        {

        }

        public GlobalException( string message):base(message)
        {

        }
    }
}
