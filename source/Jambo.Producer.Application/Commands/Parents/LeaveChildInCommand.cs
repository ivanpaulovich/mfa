using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Jambo.Producer.Application.Commands.Parents
{
    [DataContract]
    public class LeaveChildInCommand : CommandBase, IRequest<Guid>
    {
        [DataMember]
        public Guid SchoolId { get; private set; }

        [DataMember]
        public Guid ChildId { get; private set; }

        public LeaveChildInCommand()
        {

        }

        public LeaveChildInCommand(Guid childId) : this()
        {
            ChildId = childId;
        }
    }
}
