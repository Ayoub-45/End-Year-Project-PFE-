namespace MedicalThyroidReportsAPI.Modals
{
    public class Patient
    {
        public int IdPatient { get; set; }  
        public int CodePatient { get; set; } 
        public string FirstNamePatient { get; set; }    
        public string? MiddleNamePatient {  get; set; }
        public string LastNamePatient { get; set; }
        public DateTime DateOfBirth { get; set; }   
        public string PhonePatient { get; set; }    
        public string AddressPatient {  get; set; } 
        public string CityPatient { get; set; } 
        public string CountryPatient { get; set; }
        public string SexPatient { get; set; }  
        //navigation
        public List<Study> Studies { get; set; } = new List<Study>();    

    }
}
