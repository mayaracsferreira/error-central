using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErrorCentral.Infra.Data.Migrations
{
    public partial class EventLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventLog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Collected = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Log = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Environment = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLog", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventLog");
        }
    }
}
