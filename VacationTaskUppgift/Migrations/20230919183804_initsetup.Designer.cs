﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VacationTaskUppgift.Data;

#nullable disable

namespace VacationTaskUppgift.Migrations
{
    [DbContext(typeof(VacationDbContext))]
    [Migration("20230919183804_initsetup")]
    partial class initsetup
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VacationTaskUppgift.Models.CurrentRequestsModel", b =>
                {
                    b.Property<int>("CurrentVacId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CurrentVacId"));

                    b.Property<int>("FK_RequestVacationId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRejected")
                        .HasColumnType("bit");

                    b.HasKey("CurrentVacId");

                    b.ToTable("CurrentRequests");
                });

            modelBuilder.Entity("VacationTaskUppgift.Models.PersonelModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("FK_RequestVacationId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Personels");
                });

            modelBuilder.Entity("VacationTaskUppgift.Models.RequestVacationModel", b =>
                {
                    b.Property<int>("RequestVacId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequestVacId"));

                    b.Property<int?>("CurrentRequestsModelCurrentVacId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("FK_Personel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FK_VacationType")
                        .HasColumnType("int");

                    b.Property<string>("PersonelsId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RequestVacId");

                    b.HasIndex("CurrentRequestsModelCurrentVacId");

                    b.HasIndex("FK_VacationType");

                    b.HasIndex("PersonelsId");

                    b.ToTable("RequestVacations");
                });

            modelBuilder.Entity("VacationTaskUppgift.Models.VacationStatusModel", b =>
                {
                    b.Property<int>("VacationStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VacationStatusId"));

                    b.Property<DateTime>("CurrentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FK_CurrentRequestId")
                        .HasColumnType("int");

                    b.Property<string>("FK_Personel")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("VacationStatusId");

                    b.HasIndex("FK_CurrentRequestId");

                    b.HasIndex("FK_Personel");

                    b.ToTable("VacationStatuses");
                });

            modelBuilder.Entity("VacationTaskUppgift.Models.VacationTypeModel", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TypeId"));

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("maxTime")
                        .HasColumnType("int");

                    b.HasKey("TypeId");

                    b.ToTable("VacationTypes");
                });

            modelBuilder.Entity("VacationTaskUppgift.Models.RequestVacationModel", b =>
                {
                    b.HasOne("VacationTaskUppgift.Models.CurrentRequestsModel", null)
                        .WithMany("RequestVacations")
                        .HasForeignKey("CurrentRequestsModelCurrentVacId");

                    b.HasOne("VacationTaskUppgift.Models.VacationTypeModel", "VacationType")
                        .WithMany()
                        .HasForeignKey("FK_VacationType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VacationTaskUppgift.Models.PersonelModel", "Personels")
                        .WithMany("RequestVacations")
                        .HasForeignKey("PersonelsId");

                    b.Navigation("Personels");

                    b.Navigation("VacationType");
                });

            modelBuilder.Entity("VacationTaskUppgift.Models.VacationStatusModel", b =>
                {
                    b.HasOne("VacationTaskUppgift.Models.CurrentRequestsModel", "CurrentRequest")
                        .WithMany()
                        .HasForeignKey("FK_CurrentRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VacationTaskUppgift.Models.PersonelModel", "Personel")
                        .WithMany()
                        .HasForeignKey("FK_Personel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrentRequest");

                    b.Navigation("Personel");
                });

            modelBuilder.Entity("VacationTaskUppgift.Models.CurrentRequestsModel", b =>
                {
                    b.Navigation("RequestVacations");
                });

            modelBuilder.Entity("VacationTaskUppgift.Models.PersonelModel", b =>
                {
                    b.Navigation("RequestVacations");
                });
#pragma warning restore 612, 618
        }
    }
}