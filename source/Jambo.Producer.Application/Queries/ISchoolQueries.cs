using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

namespace Jambo.Producer.Application.Queries
{
    public interface ISchoolQueries
    {
        Task<string> GetChildAsync(Guid schoolId, Guid id);
        Task<string> GetParentAsync(Guid schoolId, Guid id);
        Task<string> GetSchoolAsync(Guid id);
        Task<string> GetTeacherAsync(Guid schoolId, Guid id);
        Task<string> GetSchoolsAsync();
    }
}
