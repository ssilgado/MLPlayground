using System;

namespace MLPlayground.DataAccess.Entities
{
    public partial class ImageRecord
    {
        public int ImageRecordKey { get; set; }
        public int ImageKey { get; set; }
        public string ImageCategory { get; set; }
        public DateTime RowCreateTs { get; set; }
        public DateTime RowMaintenanceTs { get; set; }

        public virtual Image Image { get; set; }
    }
}