using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiapFinBank.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialSqlServer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLIENTES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMECOMPLETO = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CONTASBANCARIAS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NUMEROCONTA = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AGENCIA = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TIPOCONTA = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CLIENTEID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTASBANCARIAS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CONTASBANCARIAS_CLIENTES_CLIENTEID",
                        column: x => x.CLIENTEID,
                        principalTable: "CLIENTES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TRANSACOES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TIPO = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    VALOR = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DATA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CONTABANCARIAID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRANSACOES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TRANSACOES_CONTASBANCARIAS_CONTABANCARIAID",
                        column: x => x.CONTABANCARIAID,
                        principalTable: "CONTASBANCARIAS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CONTASBANCARIAS_CLIENTEID",
                table: "CONTASBANCARIAS",
                column: "CLIENTEID");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSACOES_CONTABANCARIAID",
                table: "TRANSACOES",
                column: "CONTABANCARIAID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TRANSACOES");

            migrationBuilder.DropTable(
                name: "CONTASBANCARIAS");

            migrationBuilder.DropTable(
                name: "CLIENTES");
        }
    }
}
