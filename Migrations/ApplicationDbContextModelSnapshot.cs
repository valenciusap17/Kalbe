﻿// <auto-generated />
using System;
using Kalbe;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Kalbe.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Kalbe.Models.m_molecules", b =>
                {
                    b.Property<Guid>("IdMolecules")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("MolDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MoleculesName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdMolecules");

                    b.ToTable("m_molecules");
                });

            modelBuilder.Entity("Kalbe.Models.m_study", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("MoleculesId")
                        .HasColumnType("uuid");

                    b.Property<string>("ProtocolCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProtocolTitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("State")
                        .HasColumnType("integer");

                    b.Property<string>("StudyId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StudyStatusId")
                        .HasColumnType("integer");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("VersionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MoleculesId");

                    b.HasIndex("StudyStatusId");

                    b.ToTable("m_study", (string)null);
                });

            modelBuilder.Entity("Kalbe.Models.m_study_status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("m_study_status");
                });

            modelBuilder.Entity("Kalbe.Models.m_study", b =>
                {
                    b.HasOne("Kalbe.Models.m_molecules", "Molecule")
                        .WithMany("Studies")
                        .HasForeignKey("MoleculesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kalbe.Models.m_study_status", "StudyStatus")
                        .WithMany("Studies")
                        .HasForeignKey("StudyStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Molecule");

                    b.Navigation("StudyStatus");
                });

            modelBuilder.Entity("Kalbe.Models.m_molecules", b =>
                {
                    b.Navigation("Studies");
                });

            modelBuilder.Entity("Kalbe.Models.m_study_status", b =>
                {
                    b.Navigation("Studies");
                });
#pragma warning restore 612, 618
        }
    }
}
