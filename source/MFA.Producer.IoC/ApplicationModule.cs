using Autofac;
using MFA.Domain.Model.Schools;
using MFA.Infrastructure;
using MFA.Infrastructure.Repositories.Schools;
using MFA.Producer.Application.Queries;

namespace MFA.Producer.IoC
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
            builder.Register(c => new SchoolQueries(connectionString, database))
                .As<ISchoolQueries>();

            builder.Register(c => new MongoContext(connectionString, database))
                .As<MongoContext>().SingleInstance();

            builder.RegisterType<SchoolReadOnlyRepository>()
                .As<ISchoolReadOnlyRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
