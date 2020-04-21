using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcMovie.Service.Infrastructure.Migrations
{
    public partial class RowVersionAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Movie",
                rowVersion: true,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Movie");
        }
    }
}
