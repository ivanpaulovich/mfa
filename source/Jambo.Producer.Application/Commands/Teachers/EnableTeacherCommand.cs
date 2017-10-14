using MediatR;
using System.Runtime.Serialization;
using System;

namespace Jambo.Producer.Application.Commands.Teachers
{
    [DataContract]
    public class EnableTeacherCommand : CommandBase, IRequest
    {
        [DataMember]
        public Guid TeacherId { get; private set; }

        public EnableTeacherCommand()
        {

        }

        public EnableTeacherCommand(Guid teacherId) : this()
        {
            TeacherId = teacherId;
        }
    }
}
