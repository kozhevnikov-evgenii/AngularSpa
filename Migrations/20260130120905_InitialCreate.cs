using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AngularSPA.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    ActivityId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a1000000-0000-0000-0000-000000000001"), "Продуктовая" },
                    { new Guid("a1000000-0000-0000-0000-000000000002"), "Транспортная" },
                    { new Guid("a1000000-0000-0000-0000-000000000003"), "Благотворительная" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "ActivityId", "Name" },
                values: new object[,]
                {
                    { new Guid("c1000000-0000-0000-0000-000000000001"), new Guid("a1000000-0000-0000-0000-000000000001"), "ООО Восток" },
                    { new Guid("c1000000-0000-0000-0000-000000000002"), new Guid("a1000000-0000-0000-0000-000000000002"), "ЗАО Север" },
                    { new Guid("c1000000-0000-0000-0000-000000000003"), new Guid("a1000000-0000-0000-0000-000000000001"), "ООО Продукты плюс" },
                    { new Guid("c1000000-0000-0000-0000-000000000004"), new Guid("a1000000-0000-0000-0000-000000000002"), "ТрансЛогистик" },
                    { new Guid("c1000000-0000-0000-0000-000000000005"), new Guid("a1000000-0000-0000-0000-000000000003"), "Фонд Помощи" },
                    { new Guid("c1000000-0000-0000-0000-000000000006"), new Guid("a1000000-0000-0000-0000-000000000001"), "ООО Свежий хлеб" },
                    { new Guid("c1000000-0000-0000-0000-000000000007"), new Guid("a1000000-0000-0000-0000-000000000002"), "Автоперевозки" },
                    { new Guid("c1000000-0000-0000-0000-000000000008"), new Guid("a1000000-0000-0000-0000-000000000003"), "Добрые руки" },
                    { new Guid("c1000000-0000-0000-0000-000000000009"), new Guid("a1000000-0000-0000-0000-000000000001"), "ООО Молоко" },
                    { new Guid("c1000000-0000-0000-0000-00000000000a"), new Guid("a1000000-0000-0000-0000-000000000002"), "Быстрая доставка" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ActivityId",
                table: "Companies",
                column: "ActivityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Activities");
        }
    }
}
