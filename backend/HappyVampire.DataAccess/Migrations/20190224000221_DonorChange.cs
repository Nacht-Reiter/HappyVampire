using Microsoft.EntityFrameworkCore.Migrations;

namespace HappyVampire.DataAccess.Migrations
{
    public partial class DonorChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "Donors",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Rating",
                table: "Donors",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
