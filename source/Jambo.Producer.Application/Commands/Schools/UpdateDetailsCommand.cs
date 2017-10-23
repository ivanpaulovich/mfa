using MediatR;
using System;
using System.Runtime.Serialization;

namespace Jambo.Producer.Application.Commands.Schools
{
    [DataContract]
    public class UpdateSchoolDetailsCommand : CommandBase, IRequest
    {
        [DataMember]
        public Guid SchoolId { get; private set; }

        [DataMember]
        public string Title { get; private set; }

        public UpdateSchoolDetailsCommand()
        {

        }

        public UpdateSchoolDetailsCommand(Guid schoolId, string title) : this()
        {
            SchoolId = schoolId;
            Title = title;
        }
    }
}