﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PayementSystem.Data;

#nullable disable

namespace PayementSystem.Migrations
{
    [DbContext(typeof(PayementSystemContext))]
    [Migration("20230120133020_jobTags")]
    partial class jobTags
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PayementSystem.Models.Job", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("PayementSystem.Models.JobTag", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("JobID")
                        .HasColumnType("int");

                    b.Property<int>("TagID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("JobID");

                    b.HasIndex("TagID");

                    b.ToTable("JobTag");
                });

            modelBuilder.Entity("PayementSystem.Models.Payment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RecipientID")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RecipientID");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("PayementSystem.Models.PaymentTag", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("PaymentID")
                        .HasColumnType("int");

                    b.Property<int>("TagID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PaymentID");

                    b.HasIndex("TagID");

                    b.ToTable("PaymentTag");
                });

            modelBuilder.Entity("PayementSystem.Models.Recipient", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("JobID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("JobID");

                    b.ToTable("Recipient");
                });

            modelBuilder.Entity("PayementSystem.Models.Tag", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("PayementSystem.Models.JobTag", b =>
                {
                    b.HasOne("PayementSystem.Models.Job", "Job")
                        .WithMany("JobTags")
                        .HasForeignKey("JobID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PayementSystem.Models.Tag", "Tag")
                        .WithMany("JobTags")
                        .HasForeignKey("TagID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("PayementSystem.Models.Payment", b =>
                {
                    b.HasOne("PayementSystem.Models.Recipient", "Recipient")
                        .WithMany("Payments")
                        .HasForeignKey("RecipientID");

                    b.Navigation("Recipient");
                });

            modelBuilder.Entity("PayementSystem.Models.PaymentTag", b =>
                {
                    b.HasOne("PayementSystem.Models.Payment", "Payment")
                        .WithMany("PaymentTags")
                        .HasForeignKey("PaymentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PayementSystem.Models.Tag", "Tag")
                        .WithMany("PaymentTags")
                        .HasForeignKey("TagID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Payment");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("PayementSystem.Models.Recipient", b =>
                {
                    b.HasOne("PayementSystem.Models.Job", "Job")
                        .WithMany("Recipients")
                        .HasForeignKey("JobID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");
                });

            modelBuilder.Entity("PayementSystem.Models.Job", b =>
                {
                    b.Navigation("JobTags");

                    b.Navigation("Recipients");
                });

            modelBuilder.Entity("PayementSystem.Models.Payment", b =>
                {
                    b.Navigation("PaymentTags");
                });

            modelBuilder.Entity("PayementSystem.Models.Recipient", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("PayementSystem.Models.Tag", b =>
                {
                    b.Navigation("JobTags");

                    b.Navigation("PaymentTags");
                });
#pragma warning restore 612, 618
        }
    }
}
