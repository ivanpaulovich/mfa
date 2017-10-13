using Jambo.Domain.Model.Schools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Jambo.Producer.Infrastructure.DataAccess.Repositories.Schools
{
    public class SchoolWriteOnlyRepository : ISchoolWriteOnlyRepository
    {
        private readonly MongoContext mongoContext;
        public SchoolWriteOnlyRepository(MongoContext mongoContext)
        {
            this.mongoContext = mongoContext;
        }

        public async Task AddSchool(School school)
        {
            await mongoContext.Schools.InsertOneAsync(school);
        }

        public async Task UpdateSchool(School school)
        {
            await mongoContext.Schools.ReplaceOneAsync(e => e.Id == school.Id, school);
        }
    }
}
