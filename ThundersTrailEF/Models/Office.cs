using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThundersTrailEF.Models
{

    [Table("Offices")]
    public class Office
    {

        [Key]
        public int OfficeId { get; set; }
        public string OfficeName { get; set; }
    }
}
