using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicFindApi.Migrations
{
    public partial class added_link_Lyrics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "tbl_SongsApi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Lyrics",
                table: "tbl_SongsApi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "tbl_SongsApi");

            migrationBuilder.DropColumn(
                name: "Lyrics",
                table: "tbl_SongsApi");
        }
    }
}
