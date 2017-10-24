using MediatR;
using System.Runtime.Serialization;
using System;

namespace Jambo.Producer.Application.Commands.Parents
{
    [DataContract]
    public class CreateCommand : CommandBase, IRequest<Guid>
    {
        [DataMember]
        public Guid SchoolId { get; private set; }

        [DataMember]
        public string Identification { get; private set; }

        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public DateTime BirthDate { get; private set; }

        public CreateCommand()
        {

        }

        public CreateCommand(Guid schoolId, string identification, string name, DateTime birthDate) : this()
        {
            SchoolId = schoolId;
            Identification = identification;
            Name = name;
            BirthDate = birthDate;
        }
    }
}
