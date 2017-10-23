using MediatR;
using System;
using System.Runtime.Serialization;

namespace Jambo.Producer.Application.Commands.Schools
{
    [DataContract]
    public class EnableCommand : CommandBase, IRequest
    {
        [DataMember]
        public Guid SchoolId { get; private set; }

        public EnableCommand()
        {

        }

        public EnableCommand(Guid schoolId) : this()
        {
            SchoolId = schoolId;
        }
    }
}
