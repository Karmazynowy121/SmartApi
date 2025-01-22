﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartTask.Db;

#nullable disable

namespace SmartTask.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250118155951_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SmartTask.Models.EquipmentPlacementContract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EquipmentQuantity")
                        .HasColumnType("int");

                    b.Property<int>("ProcessEquipmentTypeId")
                        .HasColumnType("int");

                    b.Property<int>("ProductionFacilityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProcessEquipmentTypeId");

                    b.HasIndex("ProductionFacilityId");

                    b.ToTable("EquipmentPlacementContracts");
                });

            modelBuilder.Entity("SmartTask.Models.ProcessEquipmentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Area")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProcessEquipmentTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Area = 50,
                            Code = "PE001",
                            Name = "Type A"
                        },
                        new
                        {
                            Id = 2,
                            Area = 100,
                            Code = "PE002",
                            Name = "Type B"
                        });
                });

            modelBuilder.Entity("SmartTask.Models.ProductionFacility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StandardArea")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProductionFacilities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "PF001",
                            Name = "Facility A",
                            StandardArea = 1000
                        },
                        new
                        {
                            Id = 2,
                            Code = "PF002",
                            Name = "Facility B",
                            StandardArea = 1500
                        });
                });

            modelBuilder.Entity("SmartTask.Models.EquipmentPlacementContract", b =>
                {
                    b.HasOne("SmartTask.Models.ProcessEquipmentType", "ProcessEquipmentType")
                        .WithMany("Contracts")
                        .HasForeignKey("ProcessEquipmentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartTask.Models.ProductionFacility", "ProductionFacility")
                        .WithMany("Contracts")
                        .HasForeignKey("ProductionFacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProcessEquipmentType");

                    b.Navigation("ProductionFacility");
                });

            modelBuilder.Entity("SmartTask.Models.ProcessEquipmentType", b =>
                {
                    b.Navigation("Contracts");
                });

            modelBuilder.Entity("SmartTask.Models.ProductionFacility", b =>
                {
                    b.Navigation("Contracts");
                });
#pragma warning restore 612, 618
        }
    }
}
