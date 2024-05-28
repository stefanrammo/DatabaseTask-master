using DatabaseTask.Core.Domain;
using Microsoft.EntityFrameworkCore;


namespace DatabaseTask.Data
{
    public class DatabaseTaskDbContext : DbContext
    {
        public DatabaseTaskDbContext(DbContextOptions<DatabaseTaskDbContext> options)
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<AccessPermission> AccessPermissions { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<WorkingHistory> WorkingHistories { get; set; }
        public DbSet<EmployeeChild> EmployeeChildren { get; set; }
        public DbSet<SickLeave> SickLeaves { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<HealthInspection> HealthInspections { get; set; }
        public DbSet<Renting> Rentings { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<BranchOffice> BranchOffices { get; set; }
        public DbSet<Firm> Firms { get; set; }
        public DbSet<Hint> Hints { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.JobTitle)
                .WithMany(jt => jt.Employees)
                .HasForeignKey(e => e.JobTitleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.AccessPermissions)
                .WithOne(ap => ap.Employee)
                .HasForeignKey(ap => ap.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.WorkingHistories)
                .WithOne(wh => wh.Employee)
                .HasForeignKey(wh => wh.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.EmployeeChildren)
                .WithOne(ec => ec.Employee)
                .HasForeignKey(ec => ec.EmployeeId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.SickLeaves)
                .WithOne(sl => sl.Employee)
                .HasForeignKey(sl => sl.EmployeeId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Holidays)
                .WithOne(h => h.Employee)
                .HasForeignKey(h => h.EmployeeId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.HealthInspections)
                .WithOne(hi => hi.Employee)
                .HasForeignKey(hi => hi.EmployeeId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Rentings)
                .WithOne(r => r.Employee)
                .HasForeignKey(r => r.EmployeeId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Requests)
                .WithOne(rq => rq.Employee)
                .HasForeignKey(rq => rq.EmployeeId);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.BranchOffice)
                .WithMany(bo => bo.Employees)
                .HasForeignKey(e => e.BranchOfficeId);

            modelBuilder.Entity<AccessPermission>()
                .HasMany(ap => ap.JobTitles)
                .WithOne(jt => jt.AccessPermission)
                .HasForeignKey(jt => jt.AccessPermissionId);

            modelBuilder.Entity<JobTitle>()
                .HasMany(jt => jt.WorkingHistories)
                .WithOne(wh => wh.JobTitle)
                .HasForeignKey(wh => wh.JobTitleId);

            modelBuilder.Entity<Property>()
                .HasMany(p => p.Rentings)
                .WithOne(r => r.Property)
                .HasForeignKey(r => r.PropertyId);

            modelBuilder.Entity<BranchOffice>()
                .HasOne(bo => bo.Firm)
                .WithMany(f => f.BranchOffices)
                .HasForeignKey(bo => bo.FirmId);

            modelBuilder.Entity<Firm>()
                .HasMany(f => f.BranchOffices)
                .WithOne(bo => bo.Firm)
                .HasForeignKey(bo => bo.FirmId);

            modelBuilder.Entity<Firm>()
                .HasMany(f => f.Hints)
                .WithOne(h => h.Firm)
                .HasForeignKey(h => h.FirmId);

            modelBuilder.Entity<Hint>()
                .HasOne(h => h.Firm)
                .WithMany(f => f.Hints)
                .HasForeignKey(h => h.FirmId);
        }
    }
}