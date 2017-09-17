using Autofac;
using MFA.Producer.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

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

            builder.RegisterType<BlogReadOnlyRepository>()
                .As<IBlogReadOnlyRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PostReadOnlyRepository>()
                .As<IPostReadOnlyRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
