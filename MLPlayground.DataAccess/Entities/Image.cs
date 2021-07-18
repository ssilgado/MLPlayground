using System;

namespace MLPlayground.DataAccess.Entities
{
    public partial class Image
    {
        public int ImageKey { get; set; }
        public byte[] ImageData { get; set; }
        public DateTime RowCreateTs { get; set; }
        public DateTime RowMaintenanceTs { get; set; }

        public virtual ImageRecord ImageRecord { get; set; }
    }    
}