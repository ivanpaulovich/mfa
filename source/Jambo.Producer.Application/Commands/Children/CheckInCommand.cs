using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Jambo.Producer.Application.Commands.Children
{
    [DataContract]
    public class CheckInCommand : CommandBase, IRequest<Guid>
    {
        [DataMember]
        public Guid ChildId { get; private set; }

        public CheckInCommand()
        {

        }

        public CheckInCommand(Guid childId) : this()
        {
            ChildId = childId;
        }
    }
}
