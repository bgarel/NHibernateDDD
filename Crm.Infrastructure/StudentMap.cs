using Crm.Domain;
using FluentNHibernate.Mapping;

namespace Crm.Infrastructure
{
    public class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
        }
    }
}
