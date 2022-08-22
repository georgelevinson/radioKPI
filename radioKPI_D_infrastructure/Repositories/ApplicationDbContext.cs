using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using radioKPI_D_infrastructure.Entities;

namespace radioKPI_D_infrastructure.Repositories
{
    
    public class ApplicationDbContext : DbContext
    {
        private string _connectionString = "Server=levinge;Database=radioKPI;Trusted_Connection=True;";
        
        #region DbSets

        public virtual DbSet<GuestInfo> GuestInfo { get; set; }
        public virtual DbSet<Proposal> Proposals { get; set; }
        public virtual DbSet<Sufflere> Suffleres { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<PartialReport> PartialReports { get; set; }
        public virtual DbSet<SessionReport> SessionReports { get; set; }
        public virtual DbSet<ProdProcess> ProdProcesses { get; set; }
        public virtual DbSet<PostProdProcess> PostProdProcesses { get; set; }
        public virtual DbSet<Episode> Episodes { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<ProcessStatus> ProcessStatuses { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<GuestSubjects>().HasKey(_ => new { _.FirstId, _.SecondId }); - these need to be configured for all association tables

            #region DeleteBehavior
            modelBuilder.Entity<Proposal>()
                .HasOne(_ => _.Guest)
                .WithOne(_ => _.Proposal)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Sufflere>()
                .HasOne(_ => _.Proposal)
                .WithOne(_ => _.Sufflere)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Session>()
                .HasOne(_ => _.Proposal)
                .WithOne(_ => _.Session)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Session>()
                .HasOne(_ => _.Sufflere)
                .WithOne(_ => _.Session)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<SessionReport>()
                .HasOne(_ => _.Session)
                .WithOne(_ => _.Report)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Database-generated fields
            modelBuilder.Entity<GuestInfo>().Property(_ => _.CreatedOn).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Proposal>().Property(_ => _.CreatedOn).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Sufflere>().Property(_ => _.CreatedOn).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Session>().Property(_ => _.CreatedOn).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<PartialReport>().Property(_ => _.CreatedOn).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<SessionReport>().Property(_ => _.CreatedOn).HasDefaultValueSql("getdate()");
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
