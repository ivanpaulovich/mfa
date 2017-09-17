using MFA.Domain.Model.Schools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MFA.Infrastructure.Repositories.Schools
{
    class SchoolReadOnlyRepository : ISchoolReadOnlyRepository
    {
        private readonly MongoContext _mongoContext;

        public SchoolReadOnlyRepository(MongoContext mongoContext)
        {
            _mongoContext = mongoContext;
        }

        public async Task<IEnumerable<School>> GetAllSchools()
        {
            return await _mongoContext.Schools.Find(e => true).ToListAsync();
        }

        public async Task<School> GetSchool(Guid id)
        {
            return await _mongoContext.Schools.Find(e => e.Id == id).SingleAsync();
        }
    }
}
