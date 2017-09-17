using System;
using System.Collections.Generic;
using System.Text;

namespace MFA.Domain.Exceptions
{
    public class DomainException : MFAException
    {
        public string BusinessMessage { get; set; }

        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
    }
}
