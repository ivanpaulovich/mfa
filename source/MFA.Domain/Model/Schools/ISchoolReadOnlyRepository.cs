using MFA.Domain.Model.Schools;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MFA.Domain.Model.Schools
{
    public interface ISchoolReadOnlyRepository
    {
        Task<IEnumerable<School>> GetAllSchools();
        Task<School> GetSchool(Guid id);
    }
}
