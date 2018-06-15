using Crm.Domain;
using FluentNHibernate.Mapping;

namespace Crm.Infrastructure
{
    public class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstName).Not.Nullable();
            Map(x => x.LastName).Not.Nullable();
            Component(x => x.Address, a =>
            {
                a.Map(x => x.Street).Length(100);
                a.Map(x => x.City).Length(100);
                a.Map(x => x.Country).Length(100);
            });
            HasMany(x => x.BadgeIds)
                .Access.CamelCaseField(Prefix.Underscore)
                .KeyColumn("StudentId")
                .Table("StudentBadge")
                .Element("BadgeId");
        }
    }
}
