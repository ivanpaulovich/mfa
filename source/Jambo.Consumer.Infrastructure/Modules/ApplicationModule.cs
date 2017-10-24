using Autofac;
using Jambo.Consumer.Infrastructure.DataAccess;
using Jambo.Consumer.Infrastructure.DataAccess.Repositories.Schools;
using Jambo.Domain.Model.Schools;

namespace Jambo.Consumer.Infrastructure.Modules
{
    public class ApplicationModule : Module
    {
        public readonly string connectionString;
        public readonly string database;

        public ApplicationModule(string connectionString, string database)
        {
            this.connectionString = connectionString;
            this.database = database;
        }

        protected override void Load(ContainerBuilder builder)
        {
            MongoContext mongoContext = new MongoContext(connectionString, database);
            mongoContext.DatabaseReset(database);

            builder.Register(c => mongoContext)
                .As<MongoContext>().SingleInstance();

            builder.RegisterType<SchoolReadOnlyRepository>()
                .As<ISchoolReadOnlyRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<SchoolWriteOnlyRepository>()
                .As<ISchoolWriteOnlyRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
