using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bmp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Models_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advantages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advantages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IconUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HospitalBranchs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoverPhoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalBranchs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Introductions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Introductions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Maps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MapUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MailAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShortInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdvantageLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdvantageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvantageLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvantageLanguages_Advantages_AdvantageId",
                        column: x => x.AdvantageId,
                        principalTable: "Advantages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentFeatures_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LangCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentLanguages_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    HospitalBranchId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_HospitalBranchs_HospitalBranchId",
                        column: x => x.HospitalBranchId,
                        principalTable: "HospitalBranchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HospitalBranchFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HospitalBranchId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalBranchFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalBranchFeatures_HospitalBranchs_HospitalBranchId",
                        column: x => x.HospitalBranchId,
                        principalTable: "HospitalBranchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HospitalBranchLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LangCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HospitalBranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalBranchLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalBranchLanguages_HospitalBranchs_HospitalBranchId",
                        column: x => x.HospitalBranchId,
                        principalTable: "HospitalBranchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HospitalBranchPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HospitalBranchId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalBranchPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalBranchPhotos_HospitalBranchs_HospitalBranchId",
                        column: x => x.HospitalBranchId,
                        principalTable: "HospitalBranchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IntroductionLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LangCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntroductionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntroductionLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IntroductionLanguages_Introductions_IntroductionId",
                        column: x => x.IntroductionId,
                        principalTable: "Introductions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShortInfoLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LangCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortInfoLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShortInfoLanguages_ShortInfos_ShortInfoId",
                        column: x => x.ShortInfoId,
                        principalTable: "ShortInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentFeatureLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentFeatureText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LangCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentFeatureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentFeatureLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentFeatureLanguages_DepartmentFeatures_DepartmentFeatureId",
                        column: x => x.DepartmentFeatureId,
                        principalTable: "DepartmentFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorEducations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorEducations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorEducations_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Specialty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorLanguages_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorWorkExperiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorWorkExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorWorkExperiences_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HospitalBranchFeatureLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LangCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HospitalBranchFeatureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalBranchFeatureLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalBranchFeatureLanguages_HospitalBranchFeatures_HospitalBranchFeatureId",
                        column: x => x.HospitalBranchFeatureId,
                        principalTable: "HospitalBranchFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorEducationLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EducationText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LangCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorEducationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorEducationLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorEducationLanguages_DoctorEducations_DoctorEducationId",
                        column: x => x.DoctorEducationId,
                        principalTable: "DoctorEducations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorWorkExperienceLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkExperienceText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LangCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorWorkExperienceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorWorkExperienceLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorWorkExperienceLanguages_DoctorWorkExperiences_DoctorWorkExperienceId",
                        column: x => x.DoctorWorkExperienceId,
                        principalTable: "DoctorWorkExperiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvantageLanguages_AdvantageId",
                table: "AdvantageLanguages",
                column: "AdvantageId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentFeatureLanguages_DepartmentFeatureId",
                table: "DepartmentFeatureLanguages",
                column: "DepartmentFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentFeatures_DepartmentId",
                table: "DepartmentFeatures",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentLanguages_DepartmentId",
                table: "DepartmentLanguages",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorEducationLanguages_DoctorEducationId",
                table: "DoctorEducationLanguages",
                column: "DoctorEducationId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorEducations_DoctorId",
                table: "DoctorEducations",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorLanguages_DoctorId",
                table: "DoctorLanguages",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DepartmentId",
                table: "Doctors",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_HospitalBranchId",
                table: "Doctors",
                column: "HospitalBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorWorkExperienceLanguages_DoctorWorkExperienceId",
                table: "DoctorWorkExperienceLanguages",
                column: "DoctorWorkExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorWorkExperiences_DoctorId",
                table: "DoctorWorkExperiences",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalBranchFeatureLanguages_HospitalBranchFeatureId",
                table: "HospitalBranchFeatureLanguages",
                column: "HospitalBranchFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalBranchFeatures_HospitalBranchId",
                table: "HospitalBranchFeatures",
                column: "HospitalBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalBranchLanguages_HospitalBranchId",
                table: "HospitalBranchLanguages",
                column: "HospitalBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalBranchPhotos_HospitalBranchId",
                table: "HospitalBranchPhotos",
                column: "HospitalBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_IntroductionLanguages_IntroductionId",
                table: "IntroductionLanguages",
                column: "IntroductionId");

            migrationBuilder.CreateIndex(
                name: "IX_ShortInfoLanguages_ShortInfoId",
                table: "ShortInfoLanguages",
                column: "ShortInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvantageLanguages");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "DepartmentFeatureLanguages");

            migrationBuilder.DropTable(
                name: "DepartmentLanguages");

            migrationBuilder.DropTable(
                name: "DoctorEducationLanguages");

            migrationBuilder.DropTable(
                name: "DoctorLanguages");

            migrationBuilder.DropTable(
                name: "DoctorWorkExperienceLanguages");

            migrationBuilder.DropTable(
                name: "HospitalBranchFeatureLanguages");

            migrationBuilder.DropTable(
                name: "HospitalBranchLanguages");

            migrationBuilder.DropTable(
                name: "HospitalBranchPhotos");

            migrationBuilder.DropTable(
                name: "IntroductionLanguages");

            migrationBuilder.DropTable(
                name: "Maps");

            migrationBuilder.DropTable(
                name: "ShortInfoLanguages");

            migrationBuilder.DropTable(
                name: "Advantages");

            migrationBuilder.DropTable(
                name: "DepartmentFeatures");

            migrationBuilder.DropTable(
                name: "DoctorEducations");

            migrationBuilder.DropTable(
                name: "DoctorWorkExperiences");

            migrationBuilder.DropTable(
                name: "HospitalBranchFeatures");

            migrationBuilder.DropTable(
                name: "Introductions");

            migrationBuilder.DropTable(
                name: "ShortInfos");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "HospitalBranchs");
        }
    }
}
