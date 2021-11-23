using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VaccinationCampaignUI.Models;

namespace VaccinationCampaignUI.Data
{
    public partial class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
    : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = COMPUTER; Database = VaccineCompanyKurs; Trusted_Connection = True;");
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Appeal> Appeals { get; set; }
        public virtual DbSet<Disease> Diseases { get; set; }
        public virtual DbSet<MedicalInstitution> Institution { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Vaccination> Vaccinations { get; set; }
        public virtual DbSet<Vaccine> Vaccines { get; set; }
        public object Models { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(x => x.UserId);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
