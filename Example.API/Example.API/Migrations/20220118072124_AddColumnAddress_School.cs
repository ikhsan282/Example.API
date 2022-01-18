using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Example.API.Migrations
{
    public partial class AddColumnAddress_School : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Positions_PositionID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Schools_SchoolID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PositionID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SchoolID",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "UserImage",
                table: "Users",
                type: "nvarchar(350)",
                maxLength: 350,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(350)",
                oldMaxLength: 350);

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Schools",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PostImage",
                table: "Posts",
                type: "nvarchar(350)",
                maxLength: 350,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(350)",
                oldMaxLength: 350);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Schools");

            migrationBuilder.AlterColumn<string>(
                name: "UserImage",
                table: "Users",
                type: "nvarchar(350)",
                maxLength: 350,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(350)",
                oldMaxLength: 350,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PostImage",
                table: "Posts",
                type: "nvarchar(350)",
                maxLength: 350,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(350)",
                oldMaxLength: 350,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PositionID",
                table: "Users",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SchoolID",
                table: "Users",
                column: "SchoolID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Positions_PositionID",
                table: "Users",
                column: "PositionID",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Schools_SchoolID",
                table: "Users",
                column: "SchoolID",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
