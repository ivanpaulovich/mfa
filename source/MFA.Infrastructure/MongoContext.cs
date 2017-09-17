using MFA.Domain.Model;
using MFA.Domain.Model.Schools;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

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

            BsonClassMap.RegisterClassMap<Parent>(cm =>
            {
                cm.MapField("url").SetElementName("url");
                cm.MapField("rating").SetElementName("rating");
                cm.MapField("enabled").SetElementName("enabled");
            });

            BsonClassMap.RegisterClassMap<Child>(cm =>
            {
                cm.MapField("title").SetElementName("title");
                cm.MapField("content").SetElementName("content");
                cm.MapField("blogId").SetElementName("blogId");
                cm.MapField("enabled").SetElementName("enabled");
                cm.MapField("published").SetElementName("published");
            });        }
    }
}
