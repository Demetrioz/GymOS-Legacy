using System;

namespace GymOS.DataModel.Models
{
    public class GymOSBase
    {
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Modified { get; set; }
        public bool IsDeleted { get; set; }
    }
}
