using System.ComponentModel.DataAnnotations;

namespace MedicalThyroidReports.Modals.Domain
{
    public class Patient
    {
        [Required,Key]
        public int IdPatient { get; set; }
        [Required]
        public int CodePatient { get; set; }
        [Required]
        public string PatientFirstName { get; set; }    
        public string? PatientMidName { get; set; }
        [Required]
        public string PatientLastName { get; set;}
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string AddressPatient { get; set; }
        [Required]
        public string CityPatient { get; set; }
        [Required]
        public string CountryPatient { get; set; }
        [Required]
        public string PhonePatient { get; set; }
        [Required]
        public string SexPatient { get; set; }
        //Navigation property
        public ICollection<Study> studies { get; set; }
    }
}
