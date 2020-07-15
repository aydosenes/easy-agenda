using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyAgenda.Migrations
{
    public partial class v0001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyAgendas",
                columns: table => new
                {
                    DailyAgendaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyAgendas", x => x.DailyAgendaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyAgendas");
        }
    }
}
