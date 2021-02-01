﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonalFinanceManagement.Infrastructure.Database;

namespace PersonalFinanceManagement.Migrations
{
    [DbContext(typeof(PersonalFinanceManagementContext))]
    [Migration("20210130161640_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("PersonalFinanceManagement.Domain.Model.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("PersonalFinanceManagement.Domain.Model.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Cost")
                        .HasColumnType("real");

                    b.Property<DateTime>("OccurredAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PeriodId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProducerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PeriodId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("PersonalFinanceManagement.Domain.Model.ReportingPeriod", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Period");
                });

            modelBuilder.Entity("PersonalFinanceManagement.Domain.Model.Expense", b =>
                {
                    b.HasOne("PersonalFinanceManagement.Domain.Model.ReportingPeriod", null)
                        .WithMany("Expenses")
                        .HasForeignKey("PeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PersonalFinanceManagement.Domain.Model.ReportingPeriod", b =>
                {
                    b.OwnsOne("PersonalFinanceManagement.Domain.Model.TimePeriod", "TimePeriod", b1 =>
                        {
                            b1.Property<Guid>("ReportingPeriodId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("EndPoint")
                                .HasColumnType("datetime2")
                                .HasColumnName("EndPoint");

                            b1.Property<DateTime>("StartingPoint")
                                .HasColumnType("datetime2")
                                .HasColumnName("StartingPoint");

                            b1.HasKey("ReportingPeriodId");

                            b1.ToTable("Period");

                            b1.WithOwner()
                                .HasForeignKey("ReportingPeriodId");
                        });

                    b.Navigation("TimePeriod");
                });

            modelBuilder.Entity("PersonalFinanceManagement.Domain.Model.ReportingPeriod", b =>
                {
                    b.Navigation("Expenses");
                });
#pragma warning restore 612, 618
        }
    }
}
