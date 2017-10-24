using MediatR;
using System.Runtime.Serialization;
using System;

namespace Jambo.Producer.Application.Commands.Children
{
    [DataContract]
    public class CreateCommand : CommandBase, IRequest<Guid>
    {
        [DataMember]
        public Guid ParentId { get; private set; }

        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public DateTime BirthDate { get; private set; }

        public CreateCommand()
        {

        }

        public CreateCommand(Guid parentId, string name, DateTime birthDate) : this()
        {
            ParentId = parentId;
            Name = name;
            BirthDate = birthDate;
        }
    }
}
