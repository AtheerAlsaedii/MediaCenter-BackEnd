using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class edit15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Videos",
                newName: "VideoUrl");

            migrationBuilder.RenameColumn(
                name: "VideosId",
                table: "Videos",
                newName: "VideoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VideoUrl",
                table: "Videos",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "VideoId",
                table: "Videos",
                newName: "VideosId");
        }
    }
}
