using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace MFA.Producer.Application.Queries
{
    public interface ISchoolQueries
    {
        Task<ExpandoObject> GetSchoolAsync(Guid id);

        Task<IEnumerable<ExpandoObject>> GetSchoolsAsync();
    }
}
