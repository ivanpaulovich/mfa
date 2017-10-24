using MediatR;
using System;
using System.Runtime.Serialization;

namespace Jambo.Producer.Application.Commands.Parents
{
    [DataContract]
    public class EnableCommand : CommandBase, IRequest
    {
        [DataMember]
        public Guid ParentId { get; private set; }

        public EnableCommand()
        {

        }

        public EnableCommand(Guid parentId) : this()
        {
            ParentId = parentId;
        }
    }
}
