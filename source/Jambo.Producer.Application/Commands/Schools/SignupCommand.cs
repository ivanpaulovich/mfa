using MediatR;
using System.Runtime.Serialization;
using Jambo.Domain.Model.Schools;

namespace Jambo.Producer.Application.Commands.Schools
{
    [DataContract]
    public class SignupCommand : CommandBase, IRequest<School>
    {
        [DataMember]
        public string ManagerName { get; private set; }

        [DataMember]
        public string SchoolName { get; private set; }

        public SignupCommand()
        {

        }

        public SignupCommand(
            string managerName, 
            string schoolName) : this()
        {
            ManagerName = managerName;
            SchoolName = schoolName;
        }
    }
}
