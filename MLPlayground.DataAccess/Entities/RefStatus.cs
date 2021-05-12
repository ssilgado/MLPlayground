using System;
using System.Collections.Generic;

#nullable disable

namespace MLPlayground.DataAccess.Entities
{
    public partial class RefStatus
    {
        public RefStatus()
        {
            ProcessStatuses = new HashSet<ProcessStatus>();
        }

        public int StatusKey { get; set; }
        public string StatusName { get; set; }
        public DateTime RowCreateTs { get; set; }
        public DateTime RowMaintenanceTs { get; set; }

        public virtual ICollection<ProcessStatus> ProcessStatuses { get; set; }
    }
}
