using System;
using System.Collections.Generic;
using System.Text;

namespace MFA.Domain.Exceptions
{
    public class MFAException : Exception
    {
        public MFAException()
        { }

        public MFAException(string message)
            : base(message)
        { }

        public MFAException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
