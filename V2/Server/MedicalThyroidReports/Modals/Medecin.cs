using System.ComponentModel.DataAnnotations;

namespace MedicalThyroidReports.Modals
{
    public class Medecin
    {
        [Key] 
        public int Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public int IdSpecialite { get; set; }
        public string Grade { get; set; }
    }
}
