namespace MedicalThyroidReportsAPI.Modals
{
    public class StudyThyroid:Study
    {
        public int IdStudyThyroid { get; set; }
        public string Volume { get; set; }
        public string Vascularization { get; set; } 
        public string Echogenicity { get; set; }
        public string LymphNodeUltra { get; set; }
        public string ThyroglossalTractStudy { get; set; }
        public string Recommendation { get; set; }
        public List<Nodule> Nodules { get; set; }
    }
}
