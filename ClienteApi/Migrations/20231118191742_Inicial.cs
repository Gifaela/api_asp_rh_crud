using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClienteApi.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MyCpf = table.Column<double>(type: "float", nullable: false),
                    Myemail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mybirthdate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Myferias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MyPhone = table.Column<int>(type: "int", nullable: false),
                    MySalario = table.Column<double>(type: "float", nullable: false),
                    MyCargo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Ponto",
                columns: table => new
                {
                    PontoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Entrada = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Saida = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ponto", x => x.PontoId);
                });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "Id", "MyCargo", "MyCpf", "MyName", "MyPhone", "MySalario", "Mybirthdate", "Myemail", "Myferias" },
                values: new object[,]
                {
                    { 1, "Pleno", 0.0, "Rodrigo", 119765, 5000.0, "00000", "rodrigo_toledo@outlook.com", "teste" },
                    { 2, "Pleno", 0.0, "Rodrigo", 119765, 5000.0, "00000", "rodrigo_toledo@outlook.com", "teste" }
                });

            migrationBuilder.InsertData(
                table: "Login",
                columns: new[] { "Email", "Password" },
                values: new object[,]
                {
                    { "rodrigo_toledo@outlook.com", "1234" },
                    { "giulia@outlook.com", "4321" }
                });

            migrationBuilder.InsertData(
                table: "Ponto",
                columns: new[] { "PontoId", "Email", "Entrada", "Saida" },
                values: new object[,]
                {
                    { 1, "rodrigo_toledo@outlook.com", new DateTime(2023, 11, 18, 16, 17, 41, 592, DateTimeKind.Local).AddTicks(6617), new DateTime(2023, 11, 18, 16, 17, 41, 595, DateTimeKind.Local).AddTicks(6428) },
                    { 2, "giulia@outlook.com", new DateTime(2023, 11, 18, 16, 17, 41, 595, DateTimeKind.Local).AddTicks(7227), new DateTime(2023, 11, 18, 16, 17, 41, 595, DateTimeKind.Local).AddTicks(7237) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "Ponto");
        }
    }
}
