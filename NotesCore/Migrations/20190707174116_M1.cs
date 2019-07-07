using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotesCore.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(type: "nvarchar", maxLength: 1000, nullable: true),
                    Author = table.Column<string>(type: "nvarchar", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DeletingDate = table.Column<DateTime>(nullable: true),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");
        }
    }
}
