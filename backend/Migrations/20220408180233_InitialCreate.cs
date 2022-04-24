using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(60)", maxLength: 60, nullable: false),
                    LastName = table.Column<string>(type: "NVARCHAR(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    Phone = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Auths",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR(32)", maxLength: 32, nullable: false),
                    Status = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auth", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Auth",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auth_UserId",
                table: "Auths",
                column: "UserId",
                unique: true);
                
        var commandText = @"
        INSERT INTO Users (Name, LastName, Email, Phone, BirthDate)
        VALUES
        ('Admin', 'Admin', 'admin@mail.com', '27999009999', '1996-04-01');

        INSERT INTO Auths (UserId, Password, Status)
        VALUES
        (@@IDENTITY, 'E10ADC3949BA59ABBE56E057F20F883E', 1);";

      // Password = E10ADC3949BA59ABBE56E057F20F883E == 123456 encrypted.

      migrationBuilder.Sql(commandText);
    }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auths");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
