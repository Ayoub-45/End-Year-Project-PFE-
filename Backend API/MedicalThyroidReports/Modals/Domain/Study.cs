using System.ComponentModel.DataAnnotations;

namespace MedicalThyroidReports.Modals.Domain
{
    public class Study
    {
        [Required,Key]
        public int IdStudy { get; set; }
        [Required]
        public int IdRadiologist { get; set; }
        [Required]
        public int TypeOfStudy { get; set; }
        [Required]
        public DateTime DateStudy { get; set; } 

    }
}
