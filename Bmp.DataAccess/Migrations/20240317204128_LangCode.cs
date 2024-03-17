using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bmp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class LangCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LangCode",
                table: "AdvantageLanguages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LangCode",
                table: "AdvantageLanguages");
        }
    }
}
