using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using radioKPI_D_infrastructure.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace radioKPI_D_infrastructure.Repositories
{
    
    public class ApplicationDbContext : DbContext
    {
        private readonly string _connectionString = "Server=levinge;Database=radioKPI;Trusted_Connection=True;";
        public static readonly LoggerFactory _myLoggerFactory = new LoggerFactory(new[] { new DebugLoggerProvider() });

        #region Data Tables
        public virtual DbSet<GuestInfo> GuestInfo { get; set; }
        public virtual DbSet<Proposal> Proposals { get; set; }
        public virtual DbSet<Sufflere> Suffleres { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<PartialReport> PartialReports { get; set; }
        public virtual DbSet<SessionReport> SessionReports { get; set; }
        public virtual DbSet<Recording> Recordings { get; set; }
        public virtual DbSet<Episode> Episodes { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<EpisodeStatus> EpisodeStatuses { get; set; }
        #endregion

        #region Association Tables
        public virtual DbSet<GuestSubject> GuestSubjects { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            optionsBuilder.UseLoggerFactory(_myLoggerFactory);

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<GuestSubjects>().HasKey(_ => new { _.FirstId, _.SecondId }); - these need to be configured for all association tables

            #region Non-Conventional FK Name Config
            modelBuilder.Entity<Episode>()
                .HasOne(_ => _.EpisodeStatus)
                .WithMany(_ => _.Episodes)
                .HasForeignKey(_ => _.StatusId);
            #endregion

            #region Association Tables Configurations
            modelBuilder.Entity<GuestSubject>().HasKey(_ => new { _.SubjectId, _.GuestId });
            #endregion

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
            modelBuilder.Entity<SessionReport>()
                .HasOne(_ => _.Session)
                .WithOne(_ => _.Report)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Recording>()
                .HasOne(_ => _.Sufflere)
                .WithOne(_ => _.Recording)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Recording>()
                .HasOne(_ => _.Session)
                .WithMany(_ => _.Recordings)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Database-generated Fields
            modelBuilder.Entity<GuestInfo>().Property(_ => _.CreatedOn).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Proposal>().Property(_ => _.CreatedOn).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Sufflere>().Property(_ => _.CreatedOn).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Session>().Property(_ => _.CreatedOn).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<PartialReport>().Property(_ => _.CreatedOn).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<SessionReport>().Property(_ => _.CreatedOn).HasDefaultValueSql("getdate()");
            #endregion
            
            #region Const Tables Seeded Data
            modelBuilder.Entity<Subject>().HasData(
                new Subject { Id = 1, Description = "STEM" },
                new Subject { Id = 2, Description = "Military" },
                new Subject { Id = 3, Description = "Politics" },
                new Subject { Id = 4, Description = "Activism" },
                new Subject { Id = 5, Description = "Education" },
                new Subject { Id = 6, Description = "VisualArts" },
                new Subject { Id = 7, Description = "Music" },
                new Subject { Id = 8, Description = "Entertainment" }
                );
            modelBuilder.Entity<EpisodeStatus>().HasData(
                new EpisodeStatus { Id = 1, Description = "Planned" },
                new EpisodeStatus { Id = 2, Description = "InScripting" },
                new EpisodeStatus { Id = 3, Description = "InProduction" },
                new EpisodeStatus { Id = 4, Description = "InPost" },
                new EpisodeStatus { Id = 5, Description = "PreRelease" },
                new EpisodeStatus { Id = 6, Description = "Released" }
                );
            #endregion

            #region Temporary Test Seeded Data
            modelBuilder.Entity<GuestInfo>().HasData(
                new GuestInfo { Id = 1, PlacesOfWorkOrStudy = "KPI", JobTitlesOrSpecializations = "Engineer", GuestDetails = "Junior year student at System Analysis Institute at KPI." },
                new GuestInfo { Id = 2, PlacesOfWorkOrStudy = "AFU", JobTitlesOrSpecializations = "Captain", GuestDetails = "Officer of the Armed Forces of Ukraine." },
                new GuestInfo { Id = 3, PlacesOfWorkOrStudy = "Phronesis", JobTitlesOrSpecializations = "Drummer", GuestDetails = "Jazz drummer at Phronesis." }
                );
            modelBuilder.Entity<Proposal>().HasData(
                new Proposal { Id = 1, Description = "Engineering at KPI, robotics, AI", OrgNotes = "Free on weekends after 13:00", GuestId = 1 },
                new Proposal { Id = 2, Description = "Jazz music, art of improvisation, performer's community.", OrgNotes = "Only available on Saturday Sep.10 from 15:30 to 17:00", GuestId = 3 }
                );
            modelBuilder.Entity<Session>().HasData(
                new Session { Id = 1, RecordingDate = new DateTime(2022, 9, 10, 13, 0, 0) }
                );
            modelBuilder.Entity<Sufflere>().HasData(
                new Sufflere { Id = 1, DataJson = "JSON string with sufflere data for podcast with AI and robotics engineering student form KPI.", ProposalId = 1 },
                new Sufflere { Id = 2, DataJson = "JSON string with sufflere data for podcast with Phronesis drummer.", ProposalId = 2 }
                );
            modelBuilder.Entity<Episode>().HasData(
                new Episode { Id = 1, Description = "AI pod", StatusId = 4 },
                new Episode { Id = 2, Description = "Music pod", StatusId = 4 },
                new Episode { Id = 3, Description = "Something with BIKES", StatusId = 1 }
                );
            modelBuilder.Entity<Recording>().HasData(
                new Recording { Id = 1, EpisodeId = 1, SessionId = 1, SufflereId = 1, TechNotes = "AI pod" },
                new Recording { Id = 2, EpisodeId = 2, SessionId = 1, SufflereId = 2, TechNotes = "Music pod" }
                );
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
