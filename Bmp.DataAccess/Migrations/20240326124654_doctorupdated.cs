using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bmp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class doctorupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorName",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "DoctorSurname",
                table: "Doctors");

            migrationBuilder.AddColumn<string>(
                name: "DoctorName",
                table: "DoctorLanguages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DoctorSurname",
                table: "DoctorLanguages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorName",
                table: "DoctorLanguages");

            migrationBuilder.DropColumn(
                name: "DoctorSurname",
                table: "DoctorLanguages");

            migrationBuilder.AddColumn<string>(
                name: "DoctorName",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DoctorSurname",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
