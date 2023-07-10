using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Allergies_Details>()
                .HasOne(a => a.Allergies)
                .WithMany(i => i.Allergies_Details)
                .HasForeignKey(a => a.AllergiesID);

            modelBuilder.Entity<NCD_Details>()
                .HasOne(a => a.NCD)
                .WithMany(i => i.NCD_Details)
                .HasForeignKey(a => a.NCDID);
        }

        public DbSet<Allergies> Allergies { get; set; }
        public DbSet<Allergies_Details> AllergiesDetails { get; set;}
        public DbSet<DiseaseInformation> DiseaseInformation { get; set;}
        public DbSet<NCD> NCD { get; set;}  
        public DbSet<NCD_Details> NCD_Details { get;set;}
        public DbSet<PatientInformation> PatientInformation { get; set;}
    }
}
