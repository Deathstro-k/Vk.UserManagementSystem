using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vk.UserManagementSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserStates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserStateId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserGroups_UserGroupId",
                        column: x => x.UserGroupId,
                        principalTable: "UserGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_UserStates_UserStateId",
                        column: x => x.UserStateId,
                        principalTable: "UserStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "Id", "Code", "Description" },
                values: new object[,]
                {
                    { new Guid("33bf8f3a-f961-4e9e-8fd5-befa239a394f"), 200, null },
                    { new Guid("41fef8c4-75d3-48ab-8fd2-57d151ee3006"), 100, "Only one" }
                });

            migrationBuilder.InsertData(
                table: "UserStates",
                columns: new[] { "Id", "Code", "Description" },
                values: new object[,]
                {
                    { new Guid("210ce758-c493-43b6-86b2-4ce2c28a62e0"), 400, "Deleted account" },
                    { new Guid("78b31513-bd2b-41f5-b3b6-69bc029976e8"), 300, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserGroupId",
                table: "Users",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserStateId",
                table: "Users",
                column: "UserStateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.DropTable(
                name: "UserStates");
        }
    }
}
