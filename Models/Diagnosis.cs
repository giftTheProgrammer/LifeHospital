using System.ComponentModel.DataAnnotations;

namespace LifeHospital.Models
{
    public class Diagnosis
    {
        [Key]
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string diagnosis { get; set; }
        public string Description { get; set; }
        public DateTime DateOfDiagnosis { get; set; }

        public string recommendedTreatment { get; set; }
        public string Prescription { get; set; }
        public string EmployeeID { get; set;}
    }
}
