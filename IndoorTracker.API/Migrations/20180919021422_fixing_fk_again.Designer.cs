﻿// <auto-generated />
using System;
using IndoorTracker.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IndoorTracker.API.Migrations
{
    [DbContext(typeof(SensorDataContext))]
    [Migration("20180919021422_fixing_fk_again")]
    partial class fixing_fk_again
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("tracking")
                .HasAnnotation("ProductVersion", "2.2.0-preview2-35157")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Relational:Sequence:tracking.sensorDataseq", "'sensorDataseq', 'tracking', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IndoorTracker.Domain.Models.SensorData.Gps", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Altitude")
                        .IsRequired();

                    b.Property<string>("Latitude")
                        .IsRequired();

                    b.Property<string>("Longitude")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Gps");
                });

            modelBuilder.Entity("IndoorTracker.Domain.Models.SensorData.SensorData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "sensorDataseq")
                        .HasAnnotation("SqlServer:HiLoSequenceSchema", "tracking")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<DateTime>("Date");

                    b.Property<string>("Device")
                        .IsRequired();

                    b.Property<string>("Family")
                        .IsRequired();

                    b.Property<int?>("GPSId");

                    b.HasKey("Id");

                    b.HasIndex("GPSId");

                    b.ToTable("SensorDatas");
                });

            modelBuilder.Entity("IndoorTracker.Domain.Models.SensorData.Wifi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MacAddress")
                        .IsRequired();

                    b.Property<int>("RSSI");

                    b.Property<int?>("SensorDataId");

                    b.HasKey("Id");

                    b.HasIndex("SensorDataId");

                    b.ToTable("Wifis");
                });

            modelBuilder.Entity("IndoorTracker.Domain.Models.SensorData.SensorData", b =>
                {
                    b.HasOne("IndoorTracker.Domain.Models.SensorData.Gps", "GPS")
                        .WithMany()
                        .HasForeignKey("GPSId");
                });

            modelBuilder.Entity("IndoorTracker.Domain.Models.SensorData.Wifi", b =>
                {
                    b.HasOne("IndoorTracker.Domain.Models.SensorData.SensorData")
                        .WithMany("Wifis")
                        .HasForeignKey("SensorDataId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
