﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using radioKPI_D_infrastructure.Repositories;

#nullable disable

namespace radioKPI_D_infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220822202949_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("radioKPI_D_infrastructure.Entities.Episode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("PostProdProcessId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReleaseNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostProdProcessId")
                        .IsUnique()
                        .HasFilter("[PostProdProcessId] IS NOT NULL");

                    b.HasIndex("StatusId");

                    b.ToTable("Episodes");
                });

            modelBuilder.Entity("radioKPI_D_infrastructure.Entities.EpisodeStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("EpisodeStatus");
                });

            modelBuilder.Entity("radioKPI_D_infrastructure.Entities.GuestInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("GuestDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobTitlesOrSpecializations")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("PlacesOfWorkOrStudy")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("GuestInfo");
                });

            modelBuilder.Entity("radioKPI_D_infrastructure.Entities.PartialReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("ReportText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SessionId")
                        .HasColumnType("int");

                    b.Property<int?>("SessionReportId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.HasIndex("SessionReportId");

                    b.ToTable("PartialReports");
                });

            modelBuilder.Entity("radioKPI_D_infrastructure.Entities.PostProdProcess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("PostProdProcesses");
                });

            modelBuilder.Entity("radioKPI_D_infrastructure.Entities.ProcessStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ProcessStatuses");
                });

            modelBuilder.Entity("radioKPI_D_infrastructure.Entities.ProdProcess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("EpisodeId")
                        .HasColumnType("int");

                    b.Property<int>("GuestInfoId")
                        .HasColumnType("int");

                    b.Property<int?>("ProposalId")
                        .HasColumnType("int");

                    b.Property<int?>("SessionId")
                        .HasColumnType("int");

                    b.Property<int?>("SessionReportId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int?>("SufflereId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EpisodeId");

                    b.HasIndex("GuestInfoId")
                        .IsUnique();

                    b.HasIndex("ProposalId");

                    b.HasIndex("SessionId");

                    b.HasIndex("SessionReportId");

                    b.HasIndex("StatusId");

                    b.HasIndex("SufflereId");

                    b.ToTable("ProdProcesses");
                });

            modelBuilder.Entity("radioKPI_D_infrastructure.Entities.Proposal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GuestId")
                        .HasColumnType("int");

                    b.Property<string>("OrgNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GuestId")
                        .IsUnique();

                    b.ToTable("Proposals");
                });

            modelBuilder.Entity("radioKPI_D_infrastructure.Entities.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("PostProdProcessId")
                        .HasColumnType("int");

                    b.Property<int>("ProposalId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RecordingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SufflereId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PostProdProcessId");

                    b.HasIndex("ProposalId")
                        .IsUnique();

                    b.HasIndex("SufflereId")
                        .IsUnique();

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("radioKPI_D_infrastructure.Entities.SessionReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("ReportText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SessionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SessionId")
                        .IsUnique();

                    b.ToTable("SessionReports");
                });

            modelBuilder.Entity("radioKPI_D_infrastructure.Entities.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("GuestInfoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GuestInfoId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("radioKPI_D_infrastructure.Entities.Sufflere", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("DataJson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProposalId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProposalId")
                        .IsUnique();

                    b.ToTable("Suffleres");
                });

            modelBuilder.Entity("radioKPI_D_infrastructure.Entities.Episode", b =>
                {
                    b.HasOne("radioKPI_D_infrastructure.Entities.PostProdProcess", "PostProdProcess")
                        .WithOne("Episode")
                        .HasForeignKey("radioKPI_D_infrastructure.Entities.Episode", "PostProdProcessId");

                    b.HasOne("radioKPI_D_infrastructure.Entities.EpisodeStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PostProdProcess");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("radioKPI_D_infrastructure.Entities.PartialReport", b =>
                {
                    b.HasOne("radioKPI_D_infrastructure.Entities.Session", "Session")
                        .WithMany("PartialReports")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("radioKPI_D_infrastructure.Entities.SessionReport", null)
                        .WithMany("PartialReports")
                        .HasForeignKey("SessionReportId");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("radioKPI_D_infrastructure.Entities.PostProdProcess", b =>
                {
                    b.HasOne("radioKPI_D_infrastructure.Entities.ProcessStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("radioKPI_D_infrastructure.Entities.ProdProcess", b =>
                {
                    b.HasOne("radioKPI_D_infrastructure.Entities.Episode", null)
                        .WithMany("ProductionProcesses")
                        .HasForeignKey("EpisodeId");

                    b.HasOne("radioKPI_D_infrastructure.Entities.GuestInfo", "GuestInfo")
                        .WithOne("MyProperty")
                        .HasForeignKey("radioKPI_D_infrastructure.Entities.ProdProcess", "GuestInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("radioKPI_D_infrastructure.Entities.Proposal", "Proposal")
                        .WithMany()
                        .HasForeignKey("ProposalId");

                    b.HasOne("radioKPI_D_infrastructure.Entities.Session", "Session")
                        .WithMany()
                        .HasForeignKey("SessionId");

                    b.HasOne("radioKPI_D_infrastructure.Entities.SessionReport", "SessionReport")
                        .WithMany()
                        .HasForeignKey("SessionReportId");

                    b.HasOne("radioKPI_D_infrastructure.Entities.ProcessStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("radioKPI_D_infrastructure.Entities.Sufflere", "Sufflere")
                        .WithMany()
                        .HasForeignKey("SufflereId");

                    b.Navigation("GuestInfo");

                    b.Navigation("Proposal");

                    b.Navigation("Session");

                    b.Navigation("SessionReport");

                    b.Navigation("Status");

                    b.Navigation("Sufflere");
                });

            modelBuilder.Entity("radioKPI_D_infrastructure.Entities.Proposal", b =>
                {
                    b.HasOne("radioKPI_D_infrastructure.Entities.GuestInfo", "Guest")
                        .WithOne("Proposal")
                        .HasForeignKey("radioKPI_D_infrastructure.Entities.Proposal", "GuestId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Guest");
                });

            modelBuilder.Entity("radioKPI_D_infrastructure.Entities.Session", b =>
                {
                    b.HasOne("radioKPI_D_infrastructure.Entities.PostProdProcess", null)
                        .WithMany("Sessions")
                        .HasForeignKey("PostProdProcessId");

                    b.HasOne("radioKPI_D_infrastructure.Entities.Proposal", "Proposal")
                        .WithOne("Session")
                        .HasForeignKey("radioKPI_D_infrastructure.Entities.Session", "ProposalId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("radioKPI_D_infrastructure.Entities.Sufflere", "Sufflere")
                        .WithOne("Session")
                        .HasForeignKey("radioKPI_D_infrastructure.Entities.Session", "SufflereId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Proposal");

                    b.Navigation("Sufflere");
                });

            modelBuilder.Entity("radioKPI_D_infrastructure.Entities.SessionReport", b =>
                {
                    b.HasOne("radioKPI_D_infrastructure.Entities.Session", "Session")
                        .WithOne("Report")
                        .HasForeignKey("radioKPI_D_infrastructure.Entities.SessionReport", "SessionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Session");
                });

            modelBuilder.Entity("radioKPI_D_infrastructure.Entities.Subject", b =>
                {
                    b.HasOne("radioKPI_D_infrastructure.Entities.GuestInfo", null)
                        .WithMany("Subjects")
                        .HasForeignKey("GuestInfoId");
                });

            modelBuilder.Entity("radioKPI_D_infrastructure.Entities.Sufflere", b =>
                {
                    b.HasOne("radioKPI_D_infrastructure.Entities.Proposal", "Proposal")
                        .WithOne("Sufflere")
                        .HasForeignKey("radioKPI_D_infrastructure.Entities.Sufflere", "ProposalId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Proposal");
                });

            modelBuilder.Entity("radioKPI_D_infrastructure.Entities.Episode", b =>
                {
                    b.Navigation("ProductionProcesses");
                });

            modelBuilder.Entity("radioKPI_D_infrastructure.Entities.GuestInfo", b =>
                {
                    b.Navigation("MyProperty");

                    b.Navigation("Proposal");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("radioKPI_D_infrastructure.Entities.PostProdProcess", b =>
                {
                    b.Navigation("Episode")
                        .IsRequired();

                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("radioKPI_D_infrastructure.Entities.Proposal", b =>
                {
                    b.Navigation("Session");

                    b.Navigation("Sufflere");
                });

            modelBuilder.Entity("radioKPI_D_infrastructure.Entities.Session", b =>
                {
                    b.Navigation("PartialReports");

                    b.Navigation("Report");
                });

            modelBuilder.Entity("radioKPI_D_infrastructure.Entities.SessionReport", b =>
                {
                    b.Navigation("PartialReports");
                });

            modelBuilder.Entity("radioKPI_D_infrastructure.Entities.Sufflere", b =>
                {
                    b.Navigation("Session");
                });
#pragma warning restore 612, 618
        }
    }
}