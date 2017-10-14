using MediatR;
using System;
using System.Runtime.Serialization;

namespace Jambo.Producer.Application.Commands.Children
{
    [DataContract]
    public class CheckOutChildCommand : CommandBase, IRequest<Guid>
    {
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
