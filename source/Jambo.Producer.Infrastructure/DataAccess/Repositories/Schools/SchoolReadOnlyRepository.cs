using Jambo.Domain.Model.Schools;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jambo.Producer.Infrastructure.DataAccess.Repositories.Schools
{
    public class SchoolReadOnlyRepository : ISchoolReadOnlyRepository
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

        public Task<Child> GetChildById(Guid childId)
        {
            throw new NotImplementedException();
        }

        public Task<Parent> GetParentById(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<School> GetSchool(Guid id)
        {
            return await _mongoContext.Schools.Find(e => e.Id == id).SingleAsync();
        }

        public Task<School> GetSchoolByChildId(Guid childId)
        {
            throw new NotImplementedException();
        }

        public Task<School> GetSchoolByTeacherId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<Teacher> GetTeacherById(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
