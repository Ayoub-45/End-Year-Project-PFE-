using System.ComponentModel.DataAnnotations;

namespace MedicalThyroidReports.Modals
{
    public class Patient
    {

            [Key]
            public int Id { get; set; }

            [MaxLength(45)]
            public string Code { get; set; }

            [MaxLength(45)]
            public string Nom { get; set; }

            [MaxLength(45)]
            public string Prenom { get; set; }

            [MaxLength(45)]
            public string Sexe { get; set; }

            [MaxLength(45)]
            public string Adresse { get; set; }

            [MaxLength(45)]
            public string Profession { get; set; }

            [MaxLength(45)]
            public string Gs { get; set; }

            public byte Rh { get; set; }

            [MaxLength(45)]
            public string Race { get; set; }

            public float Poids { get; set; }

            public float Taille { get; set; }

            [MaxLength(45)]
            public string StatutMatrimonial { get; set; }
            public DateTime Date_Naissance { get; set; }
    }
    }
