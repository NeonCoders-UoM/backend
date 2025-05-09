using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VPassport.Models
{
    public class Document
    {
        [Key]
        public int Document_ID { get; set; }

        [Required]
        public string Document_type { get; set; }

        [Required]
        public string File_path { get; set; }

        public int Vehicle_ID { get; set; }

        [ForeignKey("Vehicle_ID")]
        public CustomerVehicle Vehicle { get; set; }
    }
}
