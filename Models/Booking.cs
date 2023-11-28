using LifeHospital.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace LifeHospital.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public DateTime fromDateTime { get; set; }
        public DateTime toDateTime { get; set; }

        public string Status { get; set; } = "pending";
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public LifeHospitalUser Patient { get; set; }
    }
}
