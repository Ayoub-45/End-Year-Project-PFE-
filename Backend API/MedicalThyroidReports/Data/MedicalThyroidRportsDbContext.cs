using MedicalThyroidReports.Modals.Domain;
using Microsoft.EntityFrameworkCore;

namespace MedicalThyroidReports.Data
{
    public class MedicalThyroidRportsDbContext:DbContext
    {
        public MedicalThyroidRportsDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
                    
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Study> Studys { get; set; }
        public DbSet<Nodule> Nodules { get; set; }
        public DbSet<ThyroidStudy> ThyroidStudies { get; set; }
       
    }

}
