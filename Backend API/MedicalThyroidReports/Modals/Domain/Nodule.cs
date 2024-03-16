using System.ComponentModel.DataAnnotations;

namespace MedicalThyroidReports.Modals.Domain
{
    public class Nodule
    {
        [Required,Key]
        public int IdNodule { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string shape { get; set; }
        [Required]
        public string Composition { get; set; }
        [Required]
        public string Echogenecity { get; set; }
        [Required]
        public string Evolution { get; set; }
        [Required]
        public string ScoreTIRADS { get; set; }


    }
}
