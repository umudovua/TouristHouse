using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TouristHouse.Persistence.Context.Migrations
{
    public partial class addhome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "Announces");

            migrationBuilder.DropColumn(
                name: "BedCont",
                table: "Announces");

            migrationBuilder.DropColumn(
                name: "FloorCount",
                table: "Announces");

            migrationBuilder.RenameColumn(
                name: "RoomCount",
                table: "Announces",
                newName: "Category");

            migrationBuilder.CreateTable(
                name: "Homes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AnnounceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FloorCount = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false),
                    RoomCount = table.Column<int>(type: "int", nullable: false),
                    BedCont = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Homes_Announces_AnnounceId",
                        column: x => x.AnnounceId,
                        principalTable: "Announces",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Homes_AnnounceId",
                table: "Homes",
                column: "AnnounceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Homes");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Announces",
                newName: "RoomCount");

            migrationBuilder.AddColumn<double>(
                name: "Area",
                table: "Announces",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "BedCont",
                table: "Announces",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FloorCount",
                table: "Announces",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
