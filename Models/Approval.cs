using LifeHospital.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace LifeHospital.Models
{
    public class Approval
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Decision { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;

        public int BookingId { get; set; }
        public Booking Booking { get; set; }
        public LifeHospitalUser Nurse { get; set; }
    }
}
