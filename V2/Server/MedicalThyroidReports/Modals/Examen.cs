using System.ComponentModel.DataAnnotations;

namespace MedicalThyroidReports.Modals
{
    public class Examen
    {
        [Key]
        public long Id { get; set; }
        public long IdPatient { get; set; }
        public long IdPathologie { get; set; }
        public long IdMedecin { get; set; }
        public string Date_Examen { get; set; }
    }
}
