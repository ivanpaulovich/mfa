using MediatR;
using System;
using System.Runtime.Serialization;

namespace Jambo.Producer.Application.Commands.Parents
{
    [DataContract]
    public class UpdateParentPersonalDetailsCommand : CommandBase, IRequest
    {
        [DataMember]
        public Guid ParentId { get; private set; }

        [DataMember]
        public string Identification { get; private set; }

        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public DateTime BirthDate { get; private set; }

        public UpdateParentPersonalDetailsCommand()
        {

        }

        public UpdateParentPersonalDetailsCommand(
            Guid parentId, 
            string identification, 
            string name, 
            DateTime birthDate) : this()
        {
            ParentId = parentId;
            Identification = identification;
            Name = name;
            BirthDate = birthDate;
        }
    }
}