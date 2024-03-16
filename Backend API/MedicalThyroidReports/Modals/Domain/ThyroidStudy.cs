using System.ComponentModel.DataAnnotations;

namespace MedicalThyroidReports.Modals.Domain
{
    public class ThyroidStudy:Study
    {
        [Required]
        public string size { get; set; }
        [Required]
        public string Vascularization { get; set; }
        [Required]
        public string Echogenicity { get; set; }
        [Required]
        public string LymphNodeUltra { get; set; }
        public string ThyroglossalTrackStudy { get; set; }
        [Required]
        public string Recommendation { get; set; }
        //Navigation  property
        [Required]
        public ICollection<Nodule> Nodules { get; set; }    
    }
}
