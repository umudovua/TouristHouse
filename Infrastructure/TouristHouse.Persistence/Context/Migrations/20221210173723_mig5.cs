using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TouristHouse.Persistence.Context.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Homes_Announces_AnnounceId",
                table: "Homes");

            migrationBuilder.DropIndex(
                name: "IX_Homes_AnnounceId",
                table: "Homes");

            migrationBuilder.AlterColumn<string>(
                name: "AnnounceId",
                table: "Homes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeId",
                table: "Announces",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Announces_HomeId",
                table: "Announces",
                column: "HomeId",
                unique: true,
                filter: "[HomeId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Announces_Homes_HomeId",
                table: "Announces",
                column: "HomeId",
                principalTable: "Homes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announces_Homes_HomeId",
                table: "Announces");

            migrationBuilder.DropIndex(
                name: "IX_Announces_HomeId",
                table: "Announces");

            migrationBuilder.DropColumn(
                name: "HomeId",
                table: "Announces");

            migrationBuilder.AlterColumn<string>(
                name: "AnnounceId",
                table: "Homes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Homes_AnnounceId",
                table: "Homes",
                column: "AnnounceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Homes_Announces_AnnounceId",
                table: "Homes",
                column: "AnnounceId",
                principalTable: "Announces",
                principalColumn: "Id");
        }
    }
}
