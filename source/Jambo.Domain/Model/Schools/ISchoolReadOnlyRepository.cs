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
        Task<School> GetSchoolByChildId(Guid childId);
        Task<Parent> GetParentById(Guid userId);
        Task<Child> GetChildById(Guid childId);
        Task<School> GetSchoolByTeacherId(Guid userId);
        Task<Teacher> GetTeacherById(Guid userId);
    }
}
