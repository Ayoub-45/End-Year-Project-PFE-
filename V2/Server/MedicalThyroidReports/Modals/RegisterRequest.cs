using System.ComponentModel.DataAnnotations;

namespace MedicalThyroidReports.Modals
{
    // File: RegisterRequest.cs
    public class RegisterRequest
    {
        [Key]
        public int Id { get; set;}
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

}
