using System;

#nullable disable

namespace MLPlayground.DataAccess.Entities
{
    public partial class ProcessStatus
    {
        public int ProcessStatusKey { get; set; }
        public Guid ProcessGuid { get; set; }
        public int StatusKey { get; set; }
        public DateTime RowCreateTs { get; set; }
        public DateTime RowMaintenanceTs { get; set; }

        public virtual RefStatus StatusKeyNavigation { get; set; }
    }
}
