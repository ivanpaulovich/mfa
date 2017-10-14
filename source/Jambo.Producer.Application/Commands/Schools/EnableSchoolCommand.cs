using MediatR;
using System;
using System.Runtime.Serialization;

namespace Jambo.Producer.Application.Commands.Schools
{
    [DataContract]
    public class EnableSchoolCommand : CommandBase, IRequest
    {
        [DataMember]
        public Guid SchoolId { get; private set; }

        public EnableSchoolCommand()
        {

        }

        public EnableSchoolCommand(Guid schoolId) : this()
        {
            SchoolId = schoolId;
        }
    }
}
