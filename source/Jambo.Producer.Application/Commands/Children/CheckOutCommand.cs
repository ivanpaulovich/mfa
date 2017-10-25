using MediatR;
using System;
using System.Runtime.Serialization;

namespace Jambo.Producer.Application.Commands.Children
{
    [DataContract]
    public class CheckOutCommand : CommandBase, IRequest
    {
        [DataMember]
        public Guid SchoolId { get; private set; }

        [DataMember]
        public Guid ChildId { get; private set; }

        public CheckOutCommand()
        {

        }

        public CheckOutCommand(Guid childId) : this()
        {
            ChildId = childId;
        }
    }
}
