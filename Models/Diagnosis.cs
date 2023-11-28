using LifeHospital.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace LifeHospital.Models
{
    public class Diagnosis
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string diagnosis { get; set; }
        public string? Description { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [Required]
        public string? recommendedTreatment { get; set; }
        [Required]
        public string Prescription { get; set; } = "No medicine prescribed";
        [Required]
        public virtual LifeHospitalUser Employee { get; set; }
        public virtual LifeHospitalUser Patient { get; set; }
    }
}
