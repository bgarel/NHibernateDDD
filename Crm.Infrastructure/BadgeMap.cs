using Crm.Domain;
using FluentNHibernate.Mapping;

namespace Crm.Infrastructure
{
    public class BadgeMap : ClassMap<Badge>
    {
        public BadgeMap()
        {
            Id(x => x.Id);
            Map(x => x.Title).Not.Nullable();
            Map(x => x.Detail);
        }
    }
}
