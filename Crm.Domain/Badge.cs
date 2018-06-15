using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Domain
{
    public class Badge
    {
        public virtual Guid Id { get; set; }

        public virtual string Title { get; set; }

        public virtual string Detail { get; set; }
    }
}
