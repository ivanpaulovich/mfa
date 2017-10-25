using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Jambo.Producer.Application.Commands.Children
{
    [DataContract]
    public class LeaveInCommand : CommandBase, IRequest
    {
        [DataMember]
        public Guid SchooId { get; private set; }

        [DataMember]
        public Guid ChildId { get; private set; }

        public LeaveInCommand()
        {

        }

        public LeaveInCommand(Guid childId) : this()
        {
            ChildId = childId;
        }
    }
}
