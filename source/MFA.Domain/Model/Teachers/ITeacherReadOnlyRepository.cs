using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MFA.Domain.Model.Teachers
{
    interface ITeacherReadOnlyRepository
    {
        Task<IEnumerable<Teacher>> GetAllTeachers();
        Task<Teacher> GetTeacher(Guid id);
    }
}
