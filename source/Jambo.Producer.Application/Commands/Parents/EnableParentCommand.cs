using MediatR;
using System.Runtime.Serialization;
using Jambo.Producer.Application.Commands;
using System;

namespace Jambo.Producer.Application.Commands.Parents
{
    [DataContract]
    public class EnableParentCommand : CommandBase, IRequest
    {
        [DataMember]
        public Guid ParentId { get; private set; }

        public EnableParentCommand()
        {

        }

        public EnableParentCommand(Guid parentId) : this()
        {
            ParentId = parentId;
        }
    }
}
