using System.ComponentModel.DataAnnotations;

namespace LifeHospital.Models
{
    public class Consultation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int EmployeeID { get; set; }
        [Required]
        public int PatientID { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
