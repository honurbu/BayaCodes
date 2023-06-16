using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAYA.Repository.Migrations
{
    /// <inheritdoc />
    public partial class db_edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AidNotices_Locations_LocationId",
                table: "AidNotices");

            migrationBuilder.DropForeignKey(
                name: "FK_Counties_Locations_LocationId",
                table: "Counties");

            migrationBuilder.DropForeignKey(
                name: "FK_Debrises_Locations_LocationId",
                table: "Debrises");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Debrises_LocationId",
                table: "Debrises");

            migrationBuilder.DropIndex(
                name: "IX_Counties_LocationId",
                table: "Counties");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Debrises");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Counties");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "AidNotices",
                newName: "CountyId");

            migrationBuilder.RenameIndex(
                name: "IX_AidNotices_LocationId",
                table: "AidNotices",
                newName: "IX_AidNotices_CountyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AidNotices_Counties_CountyId",
                table: "AidNotices",
                column: "CountyId",
                principalTable: "Counties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AidNotices_Counties_CountyId",
                table: "AidNotices");

            migrationBuilder.RenameColumn(
                name: "CountyId",
                table: "AidNotices",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_AidNotices_CountyId",
                table: "AidNotices",
                newName: "IX_AidNotices_LocationId");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Debrises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Counties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Debrises_LocationId",
                table: "Debrises",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Counties_LocationId",
                table: "Counties",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AidNotices_Locations_LocationId",
                table: "AidNotices",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Counties_Locations_LocationId",
                table: "Counties",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Debrises_Locations_LocationId",
                table: "Debrises",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
