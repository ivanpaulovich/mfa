using Jambo.Domain.Model;
using Jambo.Domain.Model.Schools;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Jambo.Consumer.Infrastructure.DataAccess
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
                cm.MapField("manager").SetElementName("manager");
                cm.MapField("teachers").SetElementName("teachers");
                cm.MapField("parents").SetElementName("parents");
                cm.MapField("children").SetElementName("children");
            });

            BsonClassMap.RegisterClassMap<Teacher>(cm =>
            {
                cm.MapField("name").SetElementName("name");
            });

            BsonClassMap.RegisterClassMap<Parent>(cm =>
            {
                cm.MapField("name").SetElementName("name");
                cm.MapField("identification").SetElementName("identification");
                cm.MapField("birthDate").SetElementName("birthDate");
                cm.MapField("children").SetElementName("children");
            });

            BsonClassMap.RegisterClassMap<Child>(cm =>
            {
                cm.MapField("name").SetElementName("name");
            });
        }
    }
}
