using MediatR;
using System.Runtime.Serialization;
using System;
using Jambo.Domain.Model.Schools;

namespace Jambo.Producer.Application.Commands.Children
{
    [DataContract]
    public class AddChildCommand : CommandBase, IRequest<Child>
    {
        [DataMember]
        public Guid SchoolId { get; private set; }

        [DataMember]
        public Guid ParentId { get; private set; }

        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public DateTime BirthDate { get; private set; }

        public AddChildCommand()
        {

        }

        public AddChildCommand(Guid parentId, string name, DateTime birthDate) : this()
        {
            ParentId = parentId;
            Name = name;
            BirthDate = birthDate;
        }
    }
}
