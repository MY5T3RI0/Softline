﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Softline_API.Domain;

namespace Softline_API.Migrations
{
    [DbContext(typeof(SoftlineContext))]
    [Migration("20240207202635_init migration")]
    partial class initmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Softline_API.Domain.Models.Goal", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Status_ID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("Status_ID");

                    b.ToTable("Goal");
                });

            modelBuilder.Entity("Softline_API.Domain.Models.Status", b =>
                {
                    b.Property<Guid>("Status_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Status_ID");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Softline_API.Domain.Models.Goal", b =>
                {
                    b.HasOne("Softline_API.Domain.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("Status_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
