namespace MedicalThyroidReportsAPI.Modals
{
    public class Study
    {
        public int Id { get; set; } 
        public int IdRadiologist { get; set; }
        public string TypeOfStudy { get; set; }
        public DateTime DateStudy { get; set; } 
        public Patient patient { get; set; }    

    }
}
