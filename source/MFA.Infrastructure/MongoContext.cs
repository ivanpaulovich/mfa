using MFA.Domain.Model;
using MFA.Domain.Model.Schools;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace MFA.Infrastructure
{
    public class MongoContext
    {
        private readonly MongoClient mongoClient;
        private readonly IMongoDatabase database;

        public MongoContext(string connectionString, string databaseName)
        {
            this.mongoClient = new MongoClient(connectionString);
            this.database = mongoClient.GetDatabase(databaseName);
            Map();
        }

        public void DatabaseReset(string databaseName)
        {
            mongoClient.DropDatabase(databaseName);
        }

        public IMongoCollection<Parent> Parents
        {
            get
            {
                return database.GetCollection<Parent>("Parents");
            }
        }

        public IMongoCollection<Child> Children
        {
            get
            {
                return database.GetCollection<Child>("Children");
            }
        }

        public IMongoCollection<School> Schools
        {
            get
            {
                return database.GetCollection<School>("Schools");
            }
        }

        private void Map()
        {
            BsonClassMap.RegisterClassMap<Entity>(cm =>
            {
                cm.MapIdProperty(c => c.Id);
            });

            BsonClassMap.RegisterClassMap<AggregateRoot>(cm =>
            {
                cm.MapProperty(c => c.Version).SetElementName("_version");
            });

            BsonClassMap.RegisterClassMap<School>(cm =>
            {
                cm.MapField("name").SetElementName("name");
            });

            BsonClassMap.RegisterClassMap<Parent>(cm =>
            {
                cm.MapField("name").SetElementName("name");
            });

            BsonClassMap.RegisterClassMap<Child>(cm =>
            {
                cm.MapField("name").SetElementName("name");
            });
        }
    }
}
