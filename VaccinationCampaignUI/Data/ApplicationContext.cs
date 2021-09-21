using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            optionsBuilder.UseSqlServer(@"Server = COMPUTER; Database = VaccineDB; Trusted_Connection = True;");
        }

        public DbSet<Address> Addresses { get; set; }
        
        public DbSet<Patient> Patients { get; set; }
        public DbSet<MedicalInstitution> Institution { get; set; }
        public DbSet<Appeal> Appeals { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        

    }
}
