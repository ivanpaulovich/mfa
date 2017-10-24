using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Jambo.Producer.Application.Commands.Children
{
    [DataContract]
    public class PickCommand : CommandBase, IRequest<Guid>
    {
        [DataMember]
        public Guid ChildId { get; private set; }

        public PickCommand()
        {

        }

        public PickCommand(Guid childId) : this()
        {
            ChildId = childId;
        }
    }
}
