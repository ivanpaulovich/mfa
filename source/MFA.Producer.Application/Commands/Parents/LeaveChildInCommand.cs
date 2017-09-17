using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MFA.Producer.Application.Commands.Parents
{
    class LeaveChildInCommand : CommandBase, IRequest<Guid>
    {
        [DataMember]
        public string Url { get; private set; }

        public LeaveChildInCommand()
        {

        }

        public LeaveChildInCommand(string url) : this()
        {
            Url = url;
        }
    }
}
