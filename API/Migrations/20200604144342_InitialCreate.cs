using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(nullable: false),
                    Author = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "Date", "Text" },
                values: new object[] { 1, "Native", new DateTime(2020, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Шел Грек через реку" });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "Date", "Text" },
                values: new object[] { 2, "Джек Воробей", new DateTime(1890, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Бери всё и ничего не отдавай" });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "Date", "Text" },
                values: new object[] { 3, "Достоевский", new DateTime(1890, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Надо любить жизнь больше, чем смысл жизни." });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "Date", "Text" },
                values: new object[] { 4, "Шерлок Холмс", new DateTime(1800, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Элементарно, Ватсон" });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "Date", "Text" },
                values: new object[] { 5, "Сократ", new DateTime(1100, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Неосмысленная жизнь не стоит того, чтобы жить." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotes");
        }
    }
}
