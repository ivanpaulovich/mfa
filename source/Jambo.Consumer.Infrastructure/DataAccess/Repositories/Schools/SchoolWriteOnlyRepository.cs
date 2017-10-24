using Jambo.Domain.Model.Schools;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Jambo.Consumer.Infrastructure.DataAccess.Repositories.Schools
{
    public class SchoolWriteOnlyRepository : ISchoolWriteOnlyRepository
    {
        private readonly MongoContext _mongoContext;
        public SchoolWriteOnlyRepository(MongoContext mongoContext)
        {
            _mongoContext = mongoContext;
        }

        public async Task AddSchool(School School)
        {
            await _mongoContext.Schools.InsertOneAsync(School);
        }

        public async Task UpdateSchool(School School)
        {
            await _mongoContext.Schools.ReplaceOneAsync(e => e.Id == School.Id, School);
        }
    }
}
