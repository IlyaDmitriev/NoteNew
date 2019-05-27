using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotesCore.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NoteText = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    DeletingDate = table.Column<DateTime>(nullable: true),
                    DeleteAfterRead = table.Column<bool>(nullable: false),
                    AlreadyDeleted = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    HoursDeleting = table.Column<int>(nullable: true),
                    SecondsDeleting = table.Column<int>(nullable: true),
                    MinutesDeleting = table.Column<int>(nullable: true),
                    DaysDeleting = table.Column<int>(nullable: true),
                    GuidNote = table.Column<string>(nullable: true),
                    GuidNote1 = table.Column<string>(nullable: true)
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
