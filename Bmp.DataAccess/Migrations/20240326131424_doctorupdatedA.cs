using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bmp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class doctorupdatedA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LangCode",
                table: "DoctorLanguages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LangCode",
                table: "DoctorLanguages");
        }
    }
}
