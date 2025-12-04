using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
   public class HospitalContext : DbContext
   {
           public HospitalContext(DbContextOptions<HospitalContext> options) : base(options) { }
           public HospitalContext() { }
           
           public DbSet<Patient> Patients { get; set; }
           public DbSet<Visitation> Visitations { get; set; }
           public DbSet<Diagnose> Diagnoses { get; set; }
           public DbSet<Medicament> Medicaments { get; set; }
           public DbSet<PatientMedicament> PatientMedicaments { get; set; }
           public DbSet<Doctor> Doctors { get; set; }
   
           protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           {
               if (!optionsBuilder.IsConfigured)
               {
                   optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=HospitalDb;Trusted_Connection=True;TrustServerCertificate=True;");
               }
           }
           
           protected override void OnModelCreating(ModelBuilder modelBuilder)
           {
               //для пацієнта
               modelBuilder.Entity<Patient>(entity =>
               {
                   entity.HasKey(x => x.PatientId);
                   
                   entity.Property(x => x.FirstName)
                       .IsRequired()
                       .HasMaxLength(50)
                       .IsUnicode(true);
                   
                   entity.Property(x => x.LastName)
                       .IsRequired()
                       .HasMaxLength(50)
                       .IsUnicode(true);
                   
                   entity.Property(x=> x.Address)
                       .HasMaxLength(250)
                       .IsUnicode(true);
                   
                   entity.Property(x => x.Email)
                       .HasMaxLength(80)
                       .IsUnicode(false);
   
                   entity.HasMany(x => x.Visitations)
                       .WithOne(v => v.Patient)
                       .HasForeignKey(v => v.PatientId);
   
                   entity.HasMany(x => x.Diagnoses)
                       .WithOne(d => d.Patient)
                       .HasForeignKey(d => d.PatientId);
               });
               
               //для відвідувань
               modelBuilder.Entity<Visitation>(entity =>
               {
                   entity.HasKey(x => x.VisitationId);
   
                   entity.Property(x => x.Comments)
                       .IsRequired()
                       .HasMaxLength(250)
                       .IsUnicode(true);
                   
                   // зв'язок з лікарем task2
                   entity.HasOne(x => x.Doctor)
                       .WithMany(x => x.Visitations)
                       .HasForeignKey(x => x.DoctorId);
               });
               
               //діагнози
               modelBuilder.Entity<Diagnose>(entity =>
               {
                   entity.HasKey(x => x.DiagnoseId);
   
                   entity.Property(x => x.Name)
                       .IsRequired()
                       .HasMaxLength(50)
                       .IsUnicode(true);
   
                   entity.Property(x => x.Comments)
                       .HasMaxLength(250)
                       .IsUnicode(true);
               });
   
               //медикаменти
               modelBuilder.Entity<Medicament>(entity =>
               {
                   entity.HasKey(x => x.MedicamentId);
   
                   entity.Property(x => x.Name)
                       .IsRequired()
                       .HasMaxLength(50)
                       .IsUnicode(true);
               });
   
               //медикаменти для пацієнта
               modelBuilder.Entity<PatientMedicament>(entity =>
               {
                   entity.HasKey(pm => new { pm.PatientId, pm.MedicamentId });
   
                   entity.HasOne(pm => pm.Patient)
                       .WithMany(p => p.Prescriptions)
                       .HasForeignKey(pm => pm.PatientId);
   
                   entity.HasOne(pm => pm.Medicament)
                       .WithMany(m => m.Prescriptions)
                       .HasForeignKey(pm => pm.MedicamentId);
               });
               
               //для лікарів
               modelBuilder.Entity<Doctor>(entity =>
               {
                   entity.HasKey(d => d.DoctorId);

                   entity.Property(d => d.Name)
                       .HasMaxLength(100)
                       .IsUnicode(true);

                   entity.Property(d => d.Specialty)
                       .HasMaxLength(100)
                       .IsUnicode(true);
               });
   
           }
   } 
}


