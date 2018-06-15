using System;
using System.Collections.Generic;
using System.Linq;

namespace Crm.Domain
{
    public class Student
    {
        public virtual Guid Id { get; set; }

        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }

        public virtual Address Address { get; set; }

        private readonly IList<Guid> _badgeIds = new List<Guid>();
        public virtual IReadOnlyList<Guid> BadgeIds => _badgeIds.ToList();

        public virtual void AddBadge(Badge badge)
        {
            _badgeIds.Add(badge.Id);
        }
    }
}
