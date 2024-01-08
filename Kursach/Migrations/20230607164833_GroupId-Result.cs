using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kursach.Migrations
{
    /// <inheritdoc />
    public partial class GroupIdResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Results",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Results_GroupId",
                table: "Results",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Groups_GroupId",
                table: "Results",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Groups_GroupId",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Results_GroupId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Results");
        }
    }
}
