using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MFA.Producer.Application.Commands.Teachers
{
    [DataContract]
    public class CheckOutChildCommand : CommandBase, IRequest<Guid>
    {
        [DataMember]
        public Guid SchoolId { get; private set; }

        [DataMember]
        public Guid ChildId { get; private set; }

        public CheckOutChildCommand()
        {

        }

        public CheckOutChildCommand(Guid childId) : this()
        {
            ChildId = childId;
        }
    }
}
