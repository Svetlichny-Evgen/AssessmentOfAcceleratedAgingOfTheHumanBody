﻿// <auto-generated />
using System;
using AssessmentOfAcceleratedAgingOfTheHumanBody1.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AssessmentOfAcceleratedAgingOfTheHumanBody1.DAL.Data.Migrations
{
    [DbContext(typeof(EntityDataBase))]
    [Migration("20240526094013_InitDB")]
    partial class InitDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AssessmentOfAcceleratedAgingOfTheHumanBody1.Models.User.AccountModel", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("AssessmentOfAcceleratedAgingOfTheHumanBody1.Models.User.ResultsModel", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccauntIdId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AmountOfAlcoholDrunkPerDay")
                        .HasColumnType("int");

                    b.Property<string>("BloodPressure")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("BodyMassIndex")
                        .HasColumnType("float");

                    b.Property<bool>("CircadianRhythms")
                        .HasColumnType("bit");

                    b.Property<int>("HeartRate")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfCigarettesSmokedPerDay")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfHoursSitting")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfMeals")
                        .HasColumnType("int");

                    b.Property<string>("ResultOfDiagnostic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResultsOfThePTSDQuestionnaire")
                        .HasColumnType("int");

                    b.Property<int>("ResultsOfTheQualityOfLifeQuestionnaire")
                        .HasColumnType("int");

                    b.Property<int>("SleepTime")
                        .HasColumnType("int");

                    b.Property<double>("WaistCircumference")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AccauntIdId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("AssessmentOfAcceleratedAgingOfTheHumanBody1.Models.User.ResultsModel", b =>
                {
                    b.HasOne("AssessmentOfAcceleratedAgingOfTheHumanBody1.Models.User.AccountModel", "AccauntId")
                        .WithMany()
                        .HasForeignKey("AccauntIdId");

                    b.Navigation("AccauntId");
                });
#pragma warning restore 612, 618
        }
    }
}
