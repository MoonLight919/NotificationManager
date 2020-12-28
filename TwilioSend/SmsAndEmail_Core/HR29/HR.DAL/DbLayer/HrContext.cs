using Microsoft.EntityFrameworkCore;

namespace DataFromHrDb.DbLayer
{

    public partial class HrContext : DbContext
    {
        
        public HrContext(DbContextOptions<HrContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmpPromotion> EmpPromotions { get; set; }
        public virtual DbSet<JobTitle> JobTitles { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.INN)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.EmpPromotions);

            modelBuilder.Entity<EmpPromotion>()
                .Property(e => e.Salary);

            modelBuilder.Entity<JobTitle>()
                .Property(e => e.NameJobTitle)
                .IsUnicode(false);

            modelBuilder.Entity<JobTitle>()
                .HasMany(e => e.EmpPromotions);
        }
    }
}
