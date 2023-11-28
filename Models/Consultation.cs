using LifeHospital.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace LifeHospital.Models
{
    public class Consultation
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Status { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public Diagnosis Diagnosis { get; set; }
        public LifeHospitalUser Patient { get; set; }

        public LifeHospitalUser Doctor { get; set; }
    }
}
