using Kalbe.Models;
using Microsoft.EntityFrameworkCore;

namespace Kalbe
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<m_study>(entity =>
            {
                entity.ToTable("m_study");

                // Define the foreign key relationship to Molecule and configure cascade delete
                entity.HasOne(s => s.Molecule)
                    .WithMany(m => m.Studies)
                    .HasForeignKey(s => s.MoleculesId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Define the foreign key relationship to StudyStatus and configure cascade delete
                entity.HasOne(s => s.StudyStatus)
                    .WithMany(ss => ss.Studies)
                    .HasForeignKey(s => s.StudyStatusId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        public DbSet<m_study> m_study { get; set; }
        public DbSet<m_study_status> m_study_status { get; set; }
        public DbSet<m_molecules> m_molecules { get; set; } 
    }
}
