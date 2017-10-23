using MediatR;
using System;
using System.Runtime.Serialization;

namespace Jambo.Producer.Application.Commands.Teachers
{
    [DataContract]
    public class DisableTeacherCommand : CommandBase, IRequest
    {
        [DataMember]
        public Guid TeacherId { get; private set; }

        public DisableTeacherCommand()
        {

        }

        public DisableTeacherCommand(Guid teacherId) : this()
        {
            TeacherId = teacherId;
        }
    }
}
