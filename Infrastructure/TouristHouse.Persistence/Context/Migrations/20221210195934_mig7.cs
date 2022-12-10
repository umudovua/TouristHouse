﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TouristHouse.Persistence.Context.Migrations
{
    public partial class mig7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeeCount",
                table: "Announces",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeeCount",
                table: "Announces");
        }
    }
}
