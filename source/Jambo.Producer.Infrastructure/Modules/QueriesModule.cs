using Autofac;
using Jambo.Domain.Model.Schools;
using Jambo.Producer.Application.Queries;
using Jambo.Producer.Infrastructure;
using Jambo.Producer.Infrastructure.DataAccess;
using Jambo.Producer.Infrastructure.DataAccess.Repositories;
using Jambo.Producer.Infrastructure.DataAccess.Repositories.Schools;
using Jambo.Producer.Infrastructure.Queries;

namespace Jambo.Producer.Infrastructure.Modules
{
    public class QueriesModule : Module
    {
        public readonly string connectionString;
        public readonly string databaseName;

        public QueriesModule(string connectionString, string databaseName)
        {
            this.connectionString = connectionString;
            this.databaseName = databaseName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SchoolQueries>()
                .As<ISchoolQueries>()
                .WithParameter("connectionString", connectionString)
                .WithParameter("databaseName", databaseName)
                .SingleInstance();
        }
    }
}
