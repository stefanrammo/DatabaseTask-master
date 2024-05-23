using DatabaseTask.Core.Domain;
using Microsoft.EntityFrameworkCore;


namespace DatabaseTask.Data
{
    public class DatabaseTaskDbContext : DbContext
    {
        public DatabaseTaskDbContext(DbContextOptions<DatabaseTaskDbContext> options)
            : base(options) { }

        public DbSet<AccessPermission> AccessPermissions { get; set; } = null!;
        public DbSet<BranchOffice> BranchOffices { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<EmployeeChild> EmployeeChildren { get; set; } = null!;
        public DbSet<Firm> Firms { get; set; } = null!;
        public DbSet<HealthInspection> HealthInspections { get; set; } = null!;
        public DbSet<Hint> Hints { get; set; } = null!;
        public DbSet<Holiday> Holidays { get; set; } = null!;
        public DbSet<JobTitle> JobTitles { get; set; } = null!;
        public DbSet<Property> Properties { get; set; } = null!;
        public DbSet<Renting> Rentings { get; set; } = null!;
        public DbSet<Request> Requests { get; set; } = null!;
        public DbSet<SickLeave> SickLeaves { get; set; } = null!;
        public DbSet<WorkingHistory> WorkingHistories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.AccessPermissions)
                .WithOne(ap => ap.Employee)
                .HasForeignKey(ap => ap.Employee);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.JobTitles)
                .WithOne(jt => jt.Employee)
                .HasForeignKey(jt => jt.Employee);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.WorkingHistories)
                .WithOne(wh => wh.Employee)
                .HasForeignKey(wh => wh.Employee);

            modelBuilder.Entity<EmployeeChild>()
                .HasOne(ec => ec.Employee)
                .WithMany(e => e.EmployeeChildren)
                .HasForeignKey(ec => ec.Employee);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.SickLeaves)
                .WithOne(sl => sl.Employee)
                .HasForeignKey(sl => sl.Employee);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Holidays)
                .WithOne(h => h.Employee)
                .HasForeignKey(h => h.Employee);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.HealthInspections)
                .WithOne(hi => hi.Employee)
                .HasForeignKey(hi => hi.Employee);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Rentings)
                .WithOne(r => r.Employee)
                .HasForeignKey(r => r.Employee);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Requests)
                .WithOne(req => req.Employee)
                .HasForeignKey(req => req.Employee);

            modelBuilder.Entity<Renting>()
                .HasOne(r => r.Property)
                .WithMany(o => o.Rentings)
                .HasForeignKey(r => r.Property);

            modelBuilder.Entity<WorkingHistory>()
                .HasOne(wh => wh.JobTitle) 
                .WithMany(jt => jt.WorkingHistories) 
                .HasForeignKey(wh => wh.JobTitleId);
        

            modelBuilder.Entity<AccessPermission>()
                .HasOne(ap => ap.JobTitle)
                .WithMany()
                .HasForeignKey(ap => ap.JobTitle);

            modelBuilder.Entity<Hint>()
                .HasOne(h => h.Firm)
                .WithMany(f => f.Hints)
                .HasForeignKey(h => h.Firm);

            modelBuilder.Entity<Firm>()
                .HasOne(f => f.BranchOffice)
                .WithMany(bo => bo.Firms)
                .HasForeignKey(f => f.BranchOffice);

            modelBuilder.Entity<BranchOffice>()
                .HasMany(bo => bo.Employees)
                .WithOne(e => e.BranchOffice)
                .HasForeignKey(e => e.BranchOffice);
        }
    }
}