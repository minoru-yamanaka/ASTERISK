﻿// <auto-generated />
using System;
using Asterisk.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Asterisk.Infra.Data.Migrations
{
    [DbContext(typeof(AsteriskContext))]
    partial class AsteriskContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Asterisk.Domain.Entities.Alert", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AmountOfPeople")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR(80)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UrlImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Alerts", (string)null);
                });

            modelBuilder.Entity("Asterisk.Domain.Entities.Line", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("LineName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.Property<decimal>("MarginLeft")
                        .HasColumnType("DECIMAL");

                    b.Property<decimal>("MarginTop")
                        .HasColumnType("DECIMAL");

                    b.Property<decimal>("Width")
                        .HasColumnType("DECIMAL");

                    b.HasKey("Id");

                    b.HasIndex("LineName")
                        .IsUnique();

                    b.ToTable("Lines");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d1ed420e-674c-455d-9a52-16a46e752fd0"),
                            CreatedDate = new DateTime(2023, 10, 27, 0, 28, 16, 337, DateTimeKind.Local).AddTicks(5873),
                            LineName = "Line 1",
                            MarginLeft = 1m,
                            MarginTop = 550m,
                            Width = 450m
                        },
                        new
                        {
                            Id = new Guid("3ae9f485-d10f-41bf-b11c-6438d164af3e"),
                            CreatedDate = new DateTime(2023, 10, 27, 0, 28, 16, 337, DateTimeKind.Local).AddTicks(5926),
                            LineName = "Line 2",
                            MarginLeft = 1m,
                            MarginTop = 140m,
                            Width = 450m
                        });
                });

            modelBuilder.Entity("Asterisk.Domain.Entities.Temperature", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<decimal>("Degrees")
                        .HasColumnType("DECIMAL");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Temperatures", (string)null);
                });

            modelBuilder.Entity("Asterisk.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("VARCHAR(60)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("VARCHAR(60)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
