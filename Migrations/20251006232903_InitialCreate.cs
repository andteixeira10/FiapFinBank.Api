using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiapFinBank.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "rm93032");

            migrationBuilder.CreateTable(
                name: "Clientes",
                schema: "rm93032",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomeCompleto = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cpf = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContasBancarias",
                schema: "rm93032",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NumeroConta = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Agencia = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TipoConta = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ClienteId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasBancarias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContasBancarias_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalSchema: "rm93032",
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transacoes",
                schema: "rm93032",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Tipo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Valor = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Data = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ContaBancariaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transacoes_ContasBancarias_ContaBancariaId",
                        column: x => x.ContaBancariaId,
                        principalSchema: "rm93032",
                        principalTable: "ContasBancarias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContasBancarias_ClienteId",
                schema: "rm93032",
                table: "ContasBancarias",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_ContaBancariaId",
                schema: "rm93032",
                table: "Transacoes",
                column: "ContaBancariaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transacoes",
                schema: "rm93032");

            migrationBuilder.DropTable(
                name: "ContasBancarias",
                schema: "rm93032");

            migrationBuilder.DropTable(
                name: "Clientes",
                schema: "rm93032");
        }
    }
}
