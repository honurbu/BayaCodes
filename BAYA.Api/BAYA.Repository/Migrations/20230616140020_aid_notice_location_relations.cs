using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAYA.Repository.Migrations
{
    /// <inheritdoc />
    public partial class aid_notice_location_relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "AidNotices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AidNotices_LocationId",
                table: "AidNotices",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AidNotices_Locations_LocationId",
                table: "AidNotices",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AidNotices_Locations_LocationId",
                table: "AidNotices");

            migrationBuilder.DropIndex(
                name: "IX_AidNotices_LocationId",
                table: "AidNotices");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "AidNotices");
        }
    }
}
