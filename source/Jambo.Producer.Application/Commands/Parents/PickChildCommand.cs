using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Jambo.Producer.Application.Commands.Parents
{
    [DataContract]
    public class PickChildCommand : CommandBase, IRequest<Guid>
    {
        [DataMember]
        public Guid SchoolId { get; private set; }

        [DataMember]
        public Guid ChildId { get; private set; }

        public PickChildCommand()
        {

        }

        public PickChildCommand(Guid childId) : this()
        {
            ChildId = childId;
        }
    }
}
