using MediatR;
using System.Runtime.Serialization;
using Jambo.Producer.Application.Commands;
using System;

namespace Jambo.Producer.Application.Commands.Schools
{
    [DataContract]
    public class CreateSchoolCommand : CommandBase, IRequest<Guid>
    {
        [DataMember]
        public string Title { get; private set; }

        public CreateSchoolCommand()
        {

        }

        public CreateSchoolCommand(string title) : this()
        {
            Title = title;
        }
    }
}
