using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Jambo.Producer.Application.Commands;

namespace Jambo.Producer.Application.Commands.Schools
{
    [DataContract]
    public class DisableSchoolCommand : CommandBase, IRequest
    {
        [DataMember]
        public Guid SchoolId { get; private set; }

        public DisableSchoolCommand()
        {

        }

        public DisableSchoolCommand(Guid schoolId) : this()
        {
            SchoolId = schoolId;
        }
    }
}
