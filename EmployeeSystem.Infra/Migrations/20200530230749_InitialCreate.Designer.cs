﻿// <auto-generated />
using System;
using EmployeeSystem.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeSystem.Infra.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200530230749_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeeSystem.Domain.Entities.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("GenderId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("EmployeeSystem.Domain.Entities.EmployeeSkill", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("EmployeeId")
                        .HasColumnType("bigint");

                    b.Property<long?>("SkillId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("SkillId");

                    b.ToTable("EmployeeSkill");
                });

            modelBuilder.Entity("EmployeeSystem.Domain.Entities.Gender", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gender");
                });

            modelBuilder.Entity("EmployeeSystem.Domain.Entities.Skill", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("EmployeeSystem.Domain.Entities.Employee", b =>
                {
                    b.HasOne("EmployeeSystem.Domain.Entities.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId");
                });

            modelBuilder.Entity("EmployeeSystem.Domain.Entities.EmployeeSkill", b =>
                {
                    b.HasOne("EmployeeSystem.Domain.Entities.Employee", "Employee")
                        .WithMany("EmployeeSkillList")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("EmployeeSystem.Domain.Entities.Skill", "Skill")
                        .WithMany("EmployeeSkillList")
                        .HasForeignKey("SkillId");
                });
#pragma warning restore 612, 618
        }
    }
}
