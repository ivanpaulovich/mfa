using MediatR;
using System.Runtime.Serialization;
using Jambo.Producer.Application.Commands;
using System;

namespace Jambo.Producer.Application.Commands.Parents
{
    [DataContract]
    public class DisableParentCommand : CommandBase, IRequest
    {
        [DataMember]
        public Guid ParentId { get; private set; }

        public DisableParentCommand()
        {

        }

        public DisableParentCommand(Guid parentId) : this()
        {
            ParentId = parentId;
        }
    }
}
