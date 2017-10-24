using System.Threading.Tasks;

namespace Jambo.Domain.Model.Schools
{
    public interface ISchoolWriteOnlyRepository
    {
        Task AddSchool(School school);
        Task UpdateSchool(School school);
    }
}
