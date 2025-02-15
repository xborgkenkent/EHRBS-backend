using Microsoft.EntityFrameworkCore;
using EHRBS_backend.Domain.Entities;

namespace EHRBS_backend.Persistence.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Users> Users { get; set; }
    public DbSet<Doctors> Doctors { get; set; }
    public DbSet<Tenants> Tenants { get; set; }
    public DbSet<Patients> Patients { get; set; }
    public DbSet<Messages> Messages { get; set; }
    public DbSet<Appointments> Appointments { get; set; }
    public DbSet<MedicalRecords> MedicalRecords { get; set; }
    public DbSet<Billings> Billings { get; set; }
    public DbSet<AuditLogs> AuditLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
