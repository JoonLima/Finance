using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance.Api.Migrations
{
    /// <inheritdoc />
    public partial class CriarEntidadeAPagar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "a_pagar",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uuid", nullable: false),
                    IdNaturezaLancamento = table.Column<Guid>(type: "uuid", nullable: false),
                    descricao = table.Column<string>(type: "VARCHAR", nullable: false),
                    valor_original = table.Column<double>(type: "double precision", nullable: false),
                    valor_pago = table.Column<double>(type: "double precision", nullable: false),
                    observacao = table.Column<string>(type: "VARCHAR", nullable: true),
                    data_cadastro = table.Column<DateTime>(type: "timestamp", nullable: false),
                    data_vencimento = table.Column<DateTime>(type: "timestamp", nullable: true),
                    data_pagamento = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_a_pagar", x => x.id);
                    table.ForeignKey(
                        name: "FK_a_pagar_natureza_lancamento_IdNaturezaLancamento",
                        column: x => x.IdNaturezaLancamento,
                        principalTable: "natureza_lancamento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_a_pagar_usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_a_pagar_IdNaturezaLancamento",
                table: "a_pagar",
                column: "IdNaturezaLancamento");

            migrationBuilder.CreateIndex(
                name: "IX_a_pagar_IdUsuario",
                table: "a_pagar",
                column: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "a_pagar");
        }
    }
}
