using System;
using Crm.Domain;
using Crm.Infrastructure;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Crm.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var badge1 = new Badge
                    {
                        Title = "A1",
                        Detail = "Detail 1"
                    };

                    var badge2 = new Badge
                    {
                        Title = "A2",
                        Detail = "Detail 2"
                    };

                    session.SaveOrUpdate(badge1);
                    session.SaveOrUpdate(badge2);

                    var address = new Address("rue test", "Lyon", "France");
                    var daisy = new Student { FirstName = "Daisy", LastName = "Harrison", Address = address};
                    var jack = new Student { FirstName = "Jack", LastName = "Torrance", Address = address};

                    daisy.AddBadge(badge1);
                    daisy.AddBadge(badge2);

                    jack.AddBadge(badge2);

                    session.SaveOrUpdate(daisy);
                    session.SaveOrUpdate(jack);

                    transaction.Commit();
                }

                // retreive all stores and display them
                using (session.BeginTransaction())
                {
                    var students = session.CreateCriteria(typeof(Student))
                      .List<Student>();

                    foreach (var student in students)
                    {
                        Console.WriteLine(student.FirstName + " " + student.LastName);
                    }
                }
                Console.ReadKey();
            }
        }

        private static ISessionFactory CreateSessionFactory()
        {
            var configuration = Fluently.Configure()
                .Database(
                    SQLiteConfiguration.Standard
                        .UsingFile("firstProject.db")
                )
                .Mappings(m =>
                    m.FluentMappings.AddFromAssemblyOf<StudentMap>())
                .BuildConfiguration();

            // Create tables
            var exporter = new SchemaExport(configuration);
            exporter.Execute(true, true, false);

            return configuration.BuildSessionFactory();
        }
    }
}
