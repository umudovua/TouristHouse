using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TouristHouse.Persistence.Context.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BedCont",
                table: "Homes",
                newName: "BedCount");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AnnounceTags",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BedCount",
                table: "Homes",
                newName: "BedCont");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AnnounceTags",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
