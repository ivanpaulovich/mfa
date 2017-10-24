using Jambo.Producer.Application.Queries;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jambo.Producer.Infrastructure.Queries
{
    public class SchoolQueries : ISchoolQueries
    {
        private readonly IMongoDatabase database;
        public IMongoCollection<BsonDocument> Schools
        {
            get
            {
                return database.GetCollection<BsonDocument>("Schools");
            }
        }

        public SchoolQueries(string connectionString, string databaseName)
        {
            MongoClient mongoClient = new MongoClient(connectionString);
            this.database = mongoClient.GetDatabase(databaseName);
        }

        public async Task<string> GetSchoolsAsync()
        {
            IEnumerable<BsonDocument> result = await Schools
                .Find(e => true)
                .ToListAsync();

            var jsonWriterSettings = new JsonWriterSettings {
                OutputMode = JsonOutputMode.Shell,
                Indent = true
            };

            return result.ToJson(jsonWriterSettings);
        }

        public async Task<string> GetSchoolAsync(Guid id)
        {
            BsonDocument result = await Schools
                .Find(Builders<BsonDocument>
                .Filter.Eq("_id", id))
                .Project(Builders<BsonDocument>.Projection
                    .Include("name")
                    .Include("manager"))
                .SingleAsync();

            var jsonWriterSettings = new JsonWriterSettings
            {
                OutputMode = JsonOutputMode.Shell,
                Indent = true
            };

            return result.ToJson(jsonWriterSettings);
        }

        public async Task<string> GetTeacherAsync(Guid schoolId, Guid id)
        {
            BsonDocument result = await Schools
                .Find(Builders<BsonDocument>
                .Filter.Eq("teachers._id", id))
                .Project(Builders<BsonDocument>.Projection.Exclude("_id")
                    .Include("teachers._id")
                    .Include("teachers.name"))
                .SingleAsync();

            var jsonWriterSettings = new JsonWriterSettings
            {
                OutputMode = JsonOutputMode.Shell,
                Indent = true
            };

            return result.ToJson(jsonWriterSettings);
        }

        public async Task<string> GetChildAsync(Guid schoolId, Guid id)
        {
            BsonDocument result = await Schools
                .Find(Builders<BsonDocument>
                .Filter.Eq("children._id", id))
                .Project(Builders<BsonDocument>.Projection.Exclude("_id")
                    .Include("children._id")
                    .Include("children.name")
                    .Include("children.birthDate"))
                .SingleAsync();

            var jsonWriterSettings = new JsonWriterSettings
            {
                OutputMode = JsonOutputMode.Shell,
                Indent = true
            };

            return result.ToJson(jsonWriterSettings);
        }

        public async Task<string> GetParentAsync(Guid schoolId, Guid id)
        {
            BsonDocument result = await Schools
                .Find(Builders<BsonDocument>.Filter.Eq("parents._id", id))
                .Project(Builders<BsonDocument>.Projection.Exclude("_id")
                    .Include("parents._id")
                    .Include("parents.name")
                    .Include("parents.identification")
                    .Include("parents.birthDate"))
                .SingleAsync();

            var jsonWriterSettings = new JsonWriterSettings
            {
                OutputMode = JsonOutputMode.Shell,
                Indent = true
            };

            return result.ToJson(jsonWriterSettings);
        }
    }
}
