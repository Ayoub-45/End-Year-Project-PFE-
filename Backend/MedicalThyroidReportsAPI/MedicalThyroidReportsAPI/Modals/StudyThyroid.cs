namespace MedicalThyroidReportsAPI.Modals
{
    public class StudyThyroid:Study
    {
        public int IdStudyThyroid { get; set; }
        public string volume { get; set; }
        public string Vascularization { get; set; } 
        public string Echogenicity { get; set; }
        public string LymphNodeUltra { get; set; }
        public string ThyroglossalTracStudy { get; set; }
        public string Recommendation { get; set; }
        public ICollection<Nodule> Nodules { get; set; }
    }
}
