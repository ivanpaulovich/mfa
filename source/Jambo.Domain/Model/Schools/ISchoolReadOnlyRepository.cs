using Jambo.Domain.Model.Schools;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jambo.Domain.Model.Schools
{
    public interface ISchoolReadOnlyRepository
    {
        Task<IEnumerable<School>> GetAllSchools();
        Task<School> GetSchool(Guid id);
        Task<Parent> GetParent(Guid schoolId, Guid userId);
        Task<Child> GetChild(Guid schoolId, Guid childId);
        Task<Teacher> GetTeacher(Guid schoolId, Guid teacherId);
    }
}
