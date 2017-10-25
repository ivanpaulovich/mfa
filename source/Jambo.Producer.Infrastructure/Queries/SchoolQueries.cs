using Jambo.Domain.Exceptions;
using Jambo.Producer.Application.Queries;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace Jambo.Producer.Infrastructure.Queries
{
    public class SchoolQueries : ISchoolQueries
    {
        private readonly IMongoDatabase database;
        public IMongoCollection<ExpandoObject> Schools
        {
            get
            {
                return database.GetCollection<ExpandoObject>("Schools");
            }
        }

        public SchoolQueries(string connectionString, string databaseName)
        {
            MongoClient mongoClient = new MongoClient(connectionString);
            this.database = mongoClient.GetDatabase(databaseName);
        }

        public async Task<IEnumerable<ExpandoObject>> GetSchoolsAsync()
        {
            var result = await Schools
                .Find(e => true)
                .ToListAsync();

            return result;
        }

        public async Task<ExpandoObject> GetSchoolAsync(Guid id)
        {
            var result = await Schools
                .Find(Builders<ExpandoObject>.Filter.Eq("_id", id))
                .SingleAsync();

            return result;
        }

        public async Task<ExpandoObject> GetTeacherAsync(Guid schoolId, Guid id)
        {
            dynamic result = await Schools
                .Find(Builders<ExpandoObject>.Filter.Eq("teachers._id", id))
                .SingleAsync();

            dynamic teachers = result.teachers;

            foreach (var item in teachers)
            {
                if (item._id == id)
                    return item;
            }

            throw new JamboException("Objeto não existe");
        }

        public async Task<ExpandoObject> GetChildAsync(Guid schoolId, Guid id)
        {
            dynamic result = await Schools
                .Find(Builders<ExpandoObject>.Filter.Eq("children._id", id))
                .SingleAsync();

            dynamic children = result.children;

            foreach (var item in children)
            {
                if (item._id == id)
                    return item;
            }

            throw new JamboException("Objeto não existe");
        }

        public async Task<ExpandoObject> GetParentAsync(Guid schoolId, Guid id)
        {
            dynamic result = await Schools
                .Find(Builders<ExpandoObject>.Filter.Eq("parents._id", id))
                .SingleAsync();

            dynamic parents = result.parents;

            foreach (var item in parents)
            {
                if (item._id == id)
                    return item;
            }

            throw new JamboException("Objeto não existe");
        }
    }
}
