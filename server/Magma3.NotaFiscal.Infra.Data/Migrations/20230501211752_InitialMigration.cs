using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Magma3.NotaFiscal.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_cliente",
                columns: table => new
                {
                    cod_cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_cliente = table.Column<string>(type: "varchar(150)", nullable: false),
                    uid_cliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cliente", x => x.cod_cliente)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "tb_produto",
                columns: table => new
                {
                    cod_produto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    des_produto = table.Column<string>(type: "varchar(150)", nullable: false),
                    preco_produto = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    uid_produto = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_produto", x => x.cod_produto)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "tb_contato",
                columns: table => new
                {
                    cod_contato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    celular_numero = table.Column<string>(type: "varchar(20)", nullable: false),
                    fk_cod_cliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_contato", x => x.cod_contato)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_tb_contato_tb_cliente_fk_cod_cliente",
                        column: x => x.fk_cod_cliente,
                        principalTable: "tb_cliente",
                        principalColumn: "cod_cliente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_endereco",
                columns: table => new
                {
                    cod_endereco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cep = table.Column<string>(type: "varchar(20)", nullable: false),
                    uf = table.Column<string>(type: "char(2)", nullable: false),
                    cidade = table.Column<string>(type: "varchar(70)", nullable: false),
                    bairro = table.Column<string>(type: "varchar(70)", nullable: false),
                    logradouro = table.Column<string>(type: "varchar(200)", nullable: false),
                    endereco_numero = table.Column<string>(type: "varchar(10)", nullable: false),
                    fk_cod_cliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_endereco", x => x.cod_endereco)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_tb_endereco_tb_cliente_fk_cod_cliente",
                        column: x => x.fk_cod_cliente,
                        principalTable: "tb_cliente",
                        principalColumn: "cod_cliente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_nota_fiscal",
                columns: table => new
                {
                    cod_nota_fiscal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero_nota_fiscal = table.Column<string>(type: "varchar(200)", nullable: false),
                    chave_acesso_nota_fiscal = table.Column<string>(type: "varchar(200)", nullable: false),
                    data_emissao_nota_fiscal = table.Column<DateTime>(type: "datetime", nullable: false),
                    fk_cod_cliente = table.Column<int>(type: "int", nullable: false),
                    uid_nota_fiscal = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_nota_fiscal", x => x.cod_nota_fiscal)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_tb_nota_fiscal_tb_cliente_fk_cod_cliente",
                        column: x => x.fk_cod_cliente,
                        principalTable: "tb_cliente",
                        principalColumn: "cod_cliente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_nota_fiscal_produto",
                columns: table => new
                {
                    cod_nota_fiscal_produto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data_compra_produto = table.Column<DateTime>(type: "datetime", nullable: false),
                    preco_produto = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    fk_nota_fiscal = table.Column<int>(type: "int", nullable: false),
                    fk_produto = table.Column<int>(type: "int", nullable: false),
                    uid_nota_fiscal_produto = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_nota_fiscal_produto", x => x.cod_nota_fiscal_produto)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_tb_nota_fiscal_produto_tb_nota_fiscal_fk_nota_fiscal",
                        column: x => x.fk_nota_fiscal,
                        principalTable: "tb_nota_fiscal",
                        principalColumn: "cod_nota_fiscal",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_nota_fiscal_produto_tb_produto_fk_produto",
                        column: x => x.fk_produto,
                        principalTable: "tb_produto",
                        principalColumn: "cod_produto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "tb_cliente",
                columns: new[] { "cod_cliente", "nome_cliente", "uid_cliente" },
                values: new object[,]
                {
                    { 1, "Cliente 1", new Guid("c5b456a8-e507-46bf-b73a-cf83f3016555") },
                    { 2, "Cliente 2", new Guid("3c11c144-0fb3-4e12-94a5-beda4bc588a4") },
                    { 3, "Cliente 3", new Guid("b10b55f3-3f60-4b14-856a-77ad6236bfad") }
                });

            migrationBuilder.InsertData(
                table: "tb_produto",
                columns: new[] { "cod_produto", "des_produto", "preco_produto", "uid_produto" },
                values: new object[,]
                {
                    { 1, "Produto Teste 1", 99.99m, new Guid("3df3c297-a4bc-475c-95d6-c1bbc0392d18") },
                    { 2, "Produto Teste 2", 55.99m, new Guid("ded68003-42ee-4c78-9e3c-00363f1fa90a") },
                    { 3, "Produto Teste 3", 88.00m, new Guid("e3018670-fdd5-4682-9d81-45d6126932c3") }
                });

            migrationBuilder.InsertData(
                table: "tb_contato",
                columns: new[] { "cod_contato", "celular_numero", "fk_cod_cliente" },
                values: new object[,]
                {
                    { 1, "51998915689", 1 },
                    { 2, "51995674356", 2 },
                    { 3, "51876785678", 3 }
                });

            migrationBuilder.InsertData(
                table: "tb_endereco",
                columns: new[] { "cod_endereco", "bairro", "cep", "cidade", "fk_cod_cliente", "logradouro", "endereco_numero", "uf" },
                values: new object[,]
                {
                    { 1, "Centro Histórico", "900200004", "PORTO ALEGRE", 1, "Rua dos Andradas", "771", "RS" },
                    { 2, "Centro Histórico", "900200004", "PORTO ALEGRE", 2, "Rua dos Andradas", "234", "RS" },
                    { 3, "Centro Histórico", "900200004", "PORTO ALEGRE", 3, "Rua dos Andradas", "534", "RS" }
                });

            migrationBuilder.InsertData(
                table: "tb_nota_fiscal",
                columns: new[] { "cod_nota_fiscal", "chave_acesso_nota_fiscal", "fk_cod_cliente", "data_emissao_nota_fiscal", "numero_nota_fiscal", "uid_nota_fiscal" },
                values: new object[,]
                {
                    { 1, "84815641816", 1, new DateTime(2023, 5, 1, 18, 17, 52, 569, DateTimeKind.Local).AddTicks(7278), "12346578415", new Guid("6ab1f13a-efcf-4ee6-9bbe-28bcd89c7714") },
                    { 2, "32433241816", 2, new DateTime(2023, 5, 1, 18, 17, 52, 569, DateTimeKind.Local).AddTicks(7291), "12346578415", new Guid("320b47ac-512d-4fe4-9203-7f4850df76ad") },
                    { 3, "67545634636", 3, new DateTime(2023, 5, 1, 18, 17, 52, 569, DateTimeKind.Local).AddTicks(7293), "12341231231", new Guid("f216a845-91e4-4371-9ae5-78d441c4d793") }
                });

            migrationBuilder.InsertData(
                table: "tb_nota_fiscal_produto",
                columns: new[] { "cod_nota_fiscal_produto", "data_compra_produto", "fk_nota_fiscal", "fk_produto", "preco_produto", "uid_nota_fiscal_produto" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 1, 18, 17, 52, 569, DateTimeKind.Local).AddTicks(9569), 1, 1, 99.99m, new Guid("dc874688-6b8e-4406-801d-d069c56be22a") },
                    { 2, new DateTime(2023, 5, 1, 18, 17, 52, 569, DateTimeKind.Local).AddTicks(9617), 2, 2, 55.99m, new Guid("ea24fc65-d979-48a2-9cdf-00035e0265dd") },
                    { 3, new DateTime(2023, 5, 1, 18, 17, 52, 569, DateTimeKind.Local).AddTicks(9619), 3, 3, 88.00m, new Guid("21257742-fa03-47c7-97d8-c8622e3d6e39") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_contato_fk_cod_cliente",
                table: "tb_contato",
                column: "fk_cod_cliente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_endereco_fk_cod_cliente",
                table: "tb_endereco",
                column: "fk_cod_cliente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_nota_fiscal_fk_cod_cliente",
                table: "tb_nota_fiscal",
                column: "fk_cod_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_tb_nota_fiscal_produto_fk_nota_fiscal",
                table: "tb_nota_fiscal_produto",
                column: "fk_nota_fiscal");

            migrationBuilder.CreateIndex(
                name: "IX_tb_nota_fiscal_produto_fk_produto",
                table: "tb_nota_fiscal_produto",
                column: "fk_produto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_contato");

            migrationBuilder.DropTable(
                name: "tb_endereco");

            migrationBuilder.DropTable(
                name: "tb_nota_fiscal_produto");

            migrationBuilder.DropTable(
                name: "tb_nota_fiscal");

            migrationBuilder.DropTable(
                name: "tb_produto");

            migrationBuilder.DropTable(
                name: "tb_cliente");
        }
    }
}
