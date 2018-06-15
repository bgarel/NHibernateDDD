using System;
using Crm.Domain;
using Crm.Infrastructure;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

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
                    var daisy = new Student { FirstName = "Daisy", LastName = "Harrison" };
                    var jack = new Student { FirstName = "Jack", LastName = "Torrance" };
                    //var sue = new Student { FirstName = "Sue", LastName = "Walkters" };
                    //var bill = new Student { FirstName = "Bill", LastName = "Taft" };
                    //var joan = new Student { FirstName = "Joan", LastName = "Pope" };

                    // save both stores, this saves everything else via cascading
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
            return Fluently.Configure()
                .Database(
                    SQLiteConfiguration.Standard
                        .UsingFile("firstProject.db")
                )
                .Mappings(m =>
                    m.FluentMappings.AddFromAssemblyOf<StudentMap>())
                .BuildSessionFactory();
        }
    }
}
