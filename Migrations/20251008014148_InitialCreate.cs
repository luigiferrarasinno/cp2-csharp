using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "RM98047");

            migrationBuilder.CreateTable(
                name: "RM98047_97648_CLIENTE",
                schema: "RM98047",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    CPF = table.Column<string>(type: "NVARCHAR2(14)", maxLength: 14, nullable: false),
                    EMAIL = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    TELEFONE = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    ENDERECO = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    CIDADE = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    ESTADO = table.Column<string>(type: "NVARCHAR2(2)", maxLength: 2, nullable: true),
                    CEP = table.Column<string>(type: "NVARCHAR2(8)", maxLength: 8, nullable: true),
                    DATA_CADASTRO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RM98047_97648_CLIENTE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RM98047_97648_IMOVEL",
                schema: "RM98047",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TITULO = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DESCRICAO = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    TIPO_IMOVEL = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    FINALIDADE = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    VALOR_VENDA = table.Column<decimal>(type: "DECIMAL(12,2)", precision: 12, scale: 2, nullable: false),
                    VALOR_LOCACAO = table.Column<decimal>(type: "DECIMAL(10,2)", precision: 10, scale: 2, nullable: false),
                    ENDERECO = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    BAIRRO = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    CIDADE = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    ESTADO = table.Column<string>(type: "NVARCHAR2(2)", maxLength: 2, nullable: false),
                    CEP = table.Column<string>(type: "NVARCHAR2(8)", maxLength: 8, nullable: false),
                    QUARTOS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    BANHEIROS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    VAGAS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AREA_TOTAL = table.Column<decimal>(type: "DECIMAL(10,2)", precision: 10, scale: 2, nullable: false),
                    AREA_CONSTRUIDA = table.Column<decimal>(type: "DECIMAL(10,2)", precision: 10, scale: 2, nullable: false),
                    PROPRIETARIO = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    TELEFONE_PROPRIETARIO = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    STATUS = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    ATIVO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DATA_CADASTRO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RM98047_97648_IMOVEL", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RM98047_97648_PRODUTO",
                schema: "RM98047",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DESCRICAO = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    PRECO = table.Column<decimal>(type: "DECIMAL(10,2)", precision: 10, scale: 2, nullable: false),
                    QUANTIDADE = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CATEGORIA = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    CODIGO = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: true),
                    DATA_CADASTRO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ATIVO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RM98047_97648_PRODUTO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RM98047_97648_USUARIO",
                schema: "RM98047",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    EMAIL = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    SENHA = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    TIPO = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    ATIVO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DATA_CADASTRO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ULTIMO_ACESSO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RM98047_97648_USUARIO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RM98047_97648_CONTRATO",
                schema: "RM98047",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    IMOVEL_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CLIENTE_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TIPO_CONTRATO = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    NUMERO_CONTRATO = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    VALOR = table.Column<decimal>(type: "DECIMAL(12,2)", precision: 12, scale: 2, nullable: false),
                    DATA_INICIO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DATA_FIM = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    DURACAO_MESES = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    STATUS = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    OBSERVACOES = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    DATA_CADASTRO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RM98047_97648_CONTRATO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RM98047_97648_CONTRATO_RM98047_97648_CLIENTE_CLIENTE_ID",
                        column: x => x.CLIENTE_ID,
                        principalSchema: "RM98047",
                        principalTable: "RM98047_97648_CLIENTE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RM98047_97648_CONTRATO_RM98047_97648_IMOVEL_IMOVEL_ID",
                        column: x => x.IMOVEL_ID,
                        principalSchema: "RM98047",
                        principalTable: "RM98047_97648_IMOVEL",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RM98047_97648_VISITA",
                schema: "RM98047",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    IMOVEL_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CLIENTE_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DATA_VISITA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    HORA_INICIO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    HORA_FIM = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    STATUS = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    NOME_INTERESSADO = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    TELEFONE_INTERESSADO = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    EMAIL_INTERESSADO = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    OBSERVACOES = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    DATA_CADASTRO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RM98047_97648_VISITA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RM98047_97648_VISITA_RM98047_97648_CLIENTE_CLIENTE_ID",
                        column: x => x.CLIENTE_ID,
                        principalSchema: "RM98047",
                        principalTable: "RM98047_97648_CLIENTE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RM98047_97648_VISITA_RM98047_97648_IMOVEL_IMOVEL_ID",
                        column: x => x.IMOVEL_ID,
                        principalSchema: "RM98047",
                        principalTable: "RM98047_97648_IMOVEL",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RM98047_97648_CONTRATO_CLIENTE_ID",
                schema: "RM98047",
                table: "RM98047_97648_CONTRATO",
                column: "CLIENTE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RM98047_97648_CONTRATO_IMOVEL_ID",
                schema: "RM98047",
                table: "RM98047_97648_CONTRATO",
                column: "IMOVEL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RM98047_97648_VISITA_CLIENTE_ID",
                schema: "RM98047",
                table: "RM98047_97648_VISITA",
                column: "CLIENTE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RM98047_97648_VISITA_IMOVEL_ID",
                schema: "RM98047",
                table: "RM98047_97648_VISITA",
                column: "IMOVEL_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RM98047_97648_CONTRATO",
                schema: "RM98047");

            migrationBuilder.DropTable(
                name: "RM98047_97648_PRODUTO",
                schema: "RM98047");

            migrationBuilder.DropTable(
                name: "RM98047_97648_USUARIO",
                schema: "RM98047");

            migrationBuilder.DropTable(
                name: "RM98047_97648_VISITA",
                schema: "RM98047");

            migrationBuilder.DropTable(
                name: "RM98047_97648_CLIENTE",
                schema: "RM98047");

            migrationBuilder.DropTable(
                name: "RM98047_97648_IMOVEL",
                schema: "RM98047");
        }
    }
}
