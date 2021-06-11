using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymOS.DataModel.Models
{
    [Table("GymOSLog")]
    public class GymOSLog : GymOSBase
    {
        [Key]
        public int GymOSLogId { get; set; }
        public LogLevel LogLevel { get; set; }
        public string Message { get; set; }
        public string Data { get; set; }
    }
}
