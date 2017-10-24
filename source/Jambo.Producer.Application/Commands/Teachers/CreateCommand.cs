using MediatR;
using System.Runtime.Serialization;
using System;

namespace Jambo.Producer.Application.Commands.Teachers
{
    [DataContract]
    public class AddTeacherCommand : CommandBase, IRequest<Guid>
    {
        [DataMember]
        public Guid SchoolId { get; private set; }

        [DataMember]
        public string Name { get; private set; }

        public AddTeacherCommand()
        {

        }

        public AddTeacherCommand(Guid schoolId, string name) : this()
        {
            SchoolId = schoolId;
            Name = name;
        }
    }
}
