﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Task_20_10.Data;

namespace Task_20_10.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Task_20_10.Models.Participant", b =>
                {
                    b.Property<Guid>("ParticipantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Payed")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("RaceId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT");

                    b.HasKey("ParticipantId");

                    b.HasIndex("RaceId");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("Task_20_10.Models.Race", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("Task_20_10.Models.Result", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ParticipantId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ParticipantId")
                        .IsUnique();

                    b.ToTable("Results");
                });

            modelBuilder.Entity("Task_20_10.Models.Participant", b =>
                {
                    b.HasOne("Task_20_10.Models.Race", null)
                        .WithMany("Participants")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Task_20_10.Models.Result", b =>
                {
                    b.HasOne("Task_20_10.Models.Participant", null)
                        .WithOne("Result")
                        .HasForeignKey("Task_20_10.Models.Result", "ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Task_20_10.Models.Participant", b =>
                {
                    b.Navigation("Result");
                });

            modelBuilder.Entity("Task_20_10.Models.Race", b =>
                {
                    b.Navigation("Participants");
                });
#pragma warning restore 612, 618
        }
    }
}