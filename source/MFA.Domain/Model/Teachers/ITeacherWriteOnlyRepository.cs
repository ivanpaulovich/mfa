using System.Threading.Tasks;

namespace MFA.Domain.Model.Teachers
{
    public interface ITeacherWriteOnlyRepository
    {
        Task AddTeacher(Teacher teacher);
        Task UpdateTeacher(Teacher teacher);
    }
}
