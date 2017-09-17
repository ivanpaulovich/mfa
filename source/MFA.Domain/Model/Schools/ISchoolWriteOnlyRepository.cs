using System.Threading.Tasks;

namespace MFA.Domain.Model.Schools
{
    public interface ISchoolWriteOnlyRepository
    {
        Task AddSchool(School school);
        Task UpdateSchool(School school);
    }
}
