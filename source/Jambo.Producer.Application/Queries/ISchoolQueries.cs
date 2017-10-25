using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

namespace Jambo.Producer.Application.Queries
{
    public interface ISchoolQueries
    {
        Task<ExpandoObject> GetChildAsync(Guid schoolId, Guid id);
        Task<ExpandoObject> GetParentAsync(Guid schoolId, Guid id);
        Task<ExpandoObject> GetSchoolAsync(Guid id);
        Task<ExpandoObject> GetTeacherAsync(Guid schoolId, Guid id);
        Task<IEnumerable<ExpandoObject>> GetSchoolsAsync();
    }
}
