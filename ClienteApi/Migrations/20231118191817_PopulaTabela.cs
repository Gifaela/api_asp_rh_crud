using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClienteApi.Migrations
{
    public partial class PopulaTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ponto",
                keyColumn: "PontoId",
                keyValue: 1,
                columns: new[] { "Entrada", "Saida" },
                values: new object[] { new DateTime(2023, 11, 18, 16, 18, 16, 758, DateTimeKind.Local).AddTicks(6157), new DateTime(2023, 11, 18, 16, 18, 16, 761, DateTimeKind.Local).AddTicks(348) });

            migrationBuilder.UpdateData(
                table: "Ponto",
                keyColumn: "PontoId",
                keyValue: 2,
                columns: new[] { "Entrada", "Saida" },
                values: new object[] { new DateTime(2023, 11, 18, 16, 18, 16, 761, DateTimeKind.Local).AddTicks(1599), new DateTime(2023, 11, 18, 16, 18, 16, 761, DateTimeKind.Local).AddTicks(1620) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ponto",
                keyColumn: "PontoId",
                keyValue: 1,
                columns: new[] { "Entrada", "Saida" },
                values: new object[] { new DateTime(2023, 11, 18, 16, 17, 41, 592, DateTimeKind.Local).AddTicks(6617), new DateTime(2023, 11, 18, 16, 17, 41, 595, DateTimeKind.Local).AddTicks(6428) });

            migrationBuilder.UpdateData(
                table: "Ponto",
                keyColumn: "PontoId",
                keyValue: 2,
                columns: new[] { "Entrada", "Saida" },
                values: new object[] { new DateTime(2023, 11, 18, 16, 17, 41, 595, DateTimeKind.Local).AddTicks(7227), new DateTime(2023, 11, 18, 16, 17, 41, 595, DateTimeKind.Local).AddTicks(7237) });
        }
    }
}
