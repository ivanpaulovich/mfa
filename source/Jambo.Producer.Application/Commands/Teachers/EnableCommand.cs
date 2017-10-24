using MediatR;
using System.Runtime.Serialization;
using System;

namespace Jambo.Producer.Application.Commands.Teachers
{
    [DataContract]
    public class EnableCommand : CommandBase, IRequest
    {
        [DataMember]
        public Guid TeacherId { get; private set; }

        public EnableCommand()
        {

        }

        public EnableCommand(Guid teacherId) : this()
        {
            TeacherId = teacherId;
        }
    }
}
