using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MFA.Auth.Application.Commands
{
    [DataContract]
    public class LoginCommand : IRequest
    {
        [DataMember]
        public string Username { get; private set; }

        [DataMember]
        public string Password { get; private set; }

        public LoginCommand()
        {

        }
    }
}
