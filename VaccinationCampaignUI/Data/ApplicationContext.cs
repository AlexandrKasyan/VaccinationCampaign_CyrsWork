using Microsoft.EntityFrameworkCore;
using VaccinationCampaignUI.Models;

namespace VaccinationCampaignUI.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        { 
        }

        public ApplicationContext(DbContextOptions options)
            : base(options)
        { 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = COMPUTER; Database = VaccineCompanyKurs; Trusted_Connection = True;");
        }

        public DbSet<Vaccination> Vaccinations { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<MedicalInstitution> Institution { get; set; }
        public DbSet<Appeal> Appeals { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }


    }
}
