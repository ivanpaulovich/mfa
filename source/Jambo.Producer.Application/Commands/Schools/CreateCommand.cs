using MediatR;
using System.Runtime.Serialization;
using Jambo.Producer.Application.Commands;
using System;

namespace Jambo.Producer.Application.Commands.Schools
{
    [DataContract]
    public class CreateCommand : CommandBase, IRequest<Guid>
    {
        [DataMember]
        public string Title { get; private set; }

        public CreateCommand()
        {

        }

        public CreateCommand(string title) : this()
        {
            Title = title;
        }
    }
}
