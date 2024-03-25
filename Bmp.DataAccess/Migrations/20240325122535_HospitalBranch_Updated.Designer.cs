﻿// <auto-generated />
using System;
using Bmp.DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bmp.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240325122535_HospitalBranch_Updated")]
    partial class HospitalBranch_Updated
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bmp.Core.Entity.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Bmp.Core.Entity.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Bmp.Core.Entity.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.About", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Abouts");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.AboutLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AboutId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LangCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AboutId");

                    b.ToTable("AboutLanguages");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.Advantage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Advantages");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.AdvantageLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdvantageId")
                        .HasColumnType("int");

                    b.Property<string>("LangCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdvantageId");

                    b.ToTable("AdvantageLanguages");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IconUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.DepartmentFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("DepartmentFeatures");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.DepartmentFeatureLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentFeatureId")
                        .HasColumnType("int");

                    b.Property<string>("DepartmentFeatureText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LangCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentFeatureId");

                    b.ToTable("DepartmentFeatureLanguages");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.DepartmentLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LangCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("DepartmentLanguages");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("DoctorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoctorSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HospitalBranchId")
                        .HasColumnType("int");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("HospitalBranchId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.DoctorEducation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("DoctorEducations");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.DoctorEducationLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DoctorEducationId")
                        .HasColumnType("int");

                    b.Property<string>("EducationText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LangCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorEducationId");

                    b.ToTable("DoctorEducationLanguages");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.DoctorLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("Specialty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("DoctorLanguages");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.DoctorWorkExperience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("DoctorWorkExperiences");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.DoctorWorkExperienceLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DoctorWorkExperienceId")
                        .HasColumnType("int");

                    b.Property<string>("LangCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkExperienceText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorWorkExperienceId");

                    b.ToTable("DoctorWorkExperienceLanguages");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.HospitalBranch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverPhoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MailAdress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MapUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("HospitalBranchs");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.HospitalBranchFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Count")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("HospitalBranchId")
                        .HasColumnType("int");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("HospitalBranchId");

                    b.ToTable("HospitalBranchFeatures");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.HospitalBranchFeatureLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HospitalBranchFeatureId")
                        .HasColumnType("int");

                    b.Property<string>("LangCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HospitalBranchFeatureId");

                    b.ToTable("HospitalBranchFeatureLanguages");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.HospitalBranchLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BranchName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HospitalBranchId")
                        .HasColumnType("int");

                    b.Property<string>("LangCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HospitalBranchId");

                    b.ToTable("HospitalBranchLanguages");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.HospitalBranchPhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("HospitalBranchId")
                        .HasColumnType("int");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("HospitalBranchId");

                    b.ToTable("HospitalBranchPhotos");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.Introduction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Introductions");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.IntroductionLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IntroductionId")
                        .HasColumnType("int");

                    b.Property<string>("LangCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IntroductionId");

                    b.ToTable("IntroductionLanguages");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.ShortInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Count")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ShortInfos");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.ShortInfoLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LangCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShortInfoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShortInfoId");

                    b.ToTable("ShortInfoLanguages");
                });

            modelBuilder.Entity("Bmp.Core.Entity.Models.UserRole", b =>
                {
                    b.HasOne("Bmp.Core.Entity.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bmp.Core.Entity.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.AboutLanguage", b =>
                {
                    b.HasOne("Bmp.Entities.Concrete.About", "About")
                        .WithMany("AboutLanguages")
                        .HasForeignKey("AboutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("About");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.AdvantageLanguage", b =>
                {
                    b.HasOne("Bmp.Entities.Concrete.Advantage", "Advantage")
                        .WithMany("AdvantageLanguages")
                        .HasForeignKey("AdvantageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Advantage");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.DepartmentFeature", b =>
                {
                    b.HasOne("Bmp.Entities.Concrete.Department", "Department")
                        .WithMany("DepartmentFeatures")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.DepartmentFeatureLanguage", b =>
                {
                    b.HasOne("Bmp.Entities.Concrete.DepartmentFeature", "DepartmentFeature")
                        .WithMany("DepartmentFeatureLanguages")
                        .HasForeignKey("DepartmentFeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DepartmentFeature");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.DepartmentLanguage", b =>
                {
                    b.HasOne("Bmp.Entities.Concrete.Department", "Department")
                        .WithMany("DepartmentLanguages")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.Doctor", b =>
                {
                    b.HasOne("Bmp.Entities.Concrete.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bmp.Entities.Concrete.HospitalBranch", "HospitalBranch")
                        .WithMany()
                        .HasForeignKey("HospitalBranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("HospitalBranch");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.DoctorEducation", b =>
                {
                    b.HasOne("Bmp.Entities.Concrete.Doctor", "Doctor")
                        .WithMany("DoctorEducations")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.DoctorEducationLanguage", b =>
                {
                    b.HasOne("Bmp.Entities.Concrete.DoctorEducation", "DoctorEducation")
                        .WithMany("DoctorEducationLanguages")
                        .HasForeignKey("DoctorEducationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DoctorEducation");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.DoctorLanguage", b =>
                {
                    b.HasOne("Bmp.Entities.Concrete.Doctor", "Doctor")
                        .WithMany("DoctorLanguages")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.DoctorWorkExperience", b =>
                {
                    b.HasOne("Bmp.Entities.Concrete.Doctor", "Doctor")
                        .WithMany("DoctorWorkExperiences")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.DoctorWorkExperienceLanguage", b =>
                {
                    b.HasOne("Bmp.Entities.Concrete.DoctorWorkExperience", "DoctorWorkExperience")
                        .WithMany("DoctorWorkExperienceLanguages")
                        .HasForeignKey("DoctorWorkExperienceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DoctorWorkExperience");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.HospitalBranchFeature", b =>
                {
                    b.HasOne("Bmp.Entities.Concrete.HospitalBranch", "HospitalBranch")
                        .WithMany("HospitalBranchFeatures")
                        .HasForeignKey("HospitalBranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HospitalBranch");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.HospitalBranchFeatureLanguage", b =>
                {
                    b.HasOne("Bmp.Entities.Concrete.HospitalBranchFeature", "HospitalBranchFeature")
                        .WithMany("HospitalBranchFeatureLanguages")
                        .HasForeignKey("HospitalBranchFeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HospitalBranchFeature");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.HospitalBranchLanguage", b =>
                {
                    b.HasOne("Bmp.Entities.Concrete.HospitalBranch", "HospitalBranch")
                        .WithMany("HospitalBranchLanguages")
                        .HasForeignKey("HospitalBranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HospitalBranch");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.HospitalBranchPhoto", b =>
                {
                    b.HasOne("Bmp.Entities.Concrete.HospitalBranch", "HospitalBranch")
                        .WithMany("HospitalBranchPhotos")
                        .HasForeignKey("HospitalBranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HospitalBranch");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.IntroductionLanguage", b =>
                {
                    b.HasOne("Bmp.Entities.Concrete.Introduction", "Introduction")
                        .WithMany("IntroductionLanguages")
                        .HasForeignKey("IntroductionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Introduction");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.ShortInfoLanguage", b =>
                {
                    b.HasOne("Bmp.Entities.Concrete.ShortInfo", "ShortInfo")
                        .WithMany("ShortInfoLanguages")
                        .HasForeignKey("ShortInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShortInfo");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.About", b =>
                {
                    b.Navigation("AboutLanguages");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.Advantage", b =>
                {
                    b.Navigation("AdvantageLanguages");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.Department", b =>
                {
                    b.Navigation("DepartmentFeatures");

                    b.Navigation("DepartmentLanguages");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.DepartmentFeature", b =>
                {
                    b.Navigation("DepartmentFeatureLanguages");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.Doctor", b =>
                {
                    b.Navigation("DoctorEducations");

                    b.Navigation("DoctorLanguages");

                    b.Navigation("DoctorWorkExperiences");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.DoctorEducation", b =>
                {
                    b.Navigation("DoctorEducationLanguages");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.DoctorWorkExperience", b =>
                {
                    b.Navigation("DoctorWorkExperienceLanguages");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.HospitalBranch", b =>
                {
                    b.Navigation("HospitalBranchFeatures");

                    b.Navigation("HospitalBranchLanguages");

                    b.Navigation("HospitalBranchPhotos");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.HospitalBranchFeature", b =>
                {
                    b.Navigation("HospitalBranchFeatureLanguages");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.Introduction", b =>
                {
                    b.Navigation("IntroductionLanguages");
                });

            modelBuilder.Entity("Bmp.Entities.Concrete.ShortInfo", b =>
                {
                    b.Navigation("ShortInfoLanguages");
                });
#pragma warning restore 612, 618
        }
    }
}
