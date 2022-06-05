using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginSample.Data.Migrations
{
    public partial class UserPropertyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VerificationCode",
                schema: "Profile",
                table: "Users",
                newName: "RefreshToken");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RefreshToken",
                schema: "Profile",
                table: "Users",
                newName: "VerificationCode");
        }
    }
}
