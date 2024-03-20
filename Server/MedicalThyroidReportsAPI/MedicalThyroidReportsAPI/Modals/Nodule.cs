namespace MedicalThyroidReportsAPI.Modals
{
    public class Nodule
    {
        public int IdNodule {  get; set; }  
        public string Size { get; set; }    
        public string Location { get; set; }    
        public string Shape { get; set; }   
        public string Margin { get; set; }  
        public string Echogenicity { get; set; }    
        public string Composition { get; set; }
        public string Clasifications { get; set; }   
        public string ExtraThyroidExtension { get; set; }   
        public string Catogrphy { get; set; }  
        public string Evolution { get; set; }
        public int ScoreTirads { get; set; }
        public StudyThyroid StudyThyroid { get; set; }

    }
}
