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
                    NotaFiscalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    { 1, "Cliente 1", new Guid("9d65d518-69d0-4a06-8148-e1ff338630ed") },
                    { 2, "Cliente 2", new Guid("6c8159c0-4c2f-42d9-9189-085b768147c8") },
                    { 3, "Cliente 3", new Guid("9b93876e-cb65-438d-8447-a7102cd87080") }
                });

            migrationBuilder.InsertData(
                table: "tb_produto",
                columns: new[] { "cod_produto", "des_produto", "preco_produto", "uid_produto" },
                values: new object[,]
                {
                    { 1, "Produto Teste 1", 99.99m, new Guid("79d8f754-f44d-48a8-a03b-bf7d2272b350") },
                    { 2, "Produto Teste 2", 55.99m, new Guid("2d0dfa0b-a4e4-4616-b729-5735f657a7a9") },
                    { 3, "Produto Teste 3", 88.00m, new Guid("3ac22123-a00d-4949-bdde-48e0e3cf7122") }
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
                columns: new[] { "cod_nota_fiscal", "chave_acesso_nota_fiscal", "fk_cod_cliente", "data_emissao_nota_fiscal", "NotaFiscalStatus", "numero_nota_fiscal", "uid_nota_fiscal" },
                values: new object[,]
                {
                    { 1, "84815641816", 1, new DateTime(2023, 5, 1, 18, 45, 45, 41, DateTimeKind.Local).AddTicks(7368), "ATIVA", "12346578415", new Guid("8a67c798-1034-47dd-8b2a-974db24c7233") },
                    { 2, "32433241816", 2, new DateTime(2023, 5, 1, 18, 45, 45, 41, DateTimeKind.Local).AddTicks(7393), "ATIVA", "12346578415", new Guid("999fc73b-6e02-432a-941d-e2d8234ed487") },
                    { 3, "67545634636", 3, new DateTime(2023, 5, 1, 18, 45, 45, 41, DateTimeKind.Local).AddTicks(7395), "ATIVA", "12341231231", new Guid("fcc1fb68-6ab3-49ac-8331-62cfa2b98393") }
                });

            migrationBuilder.InsertData(
                table: "tb_nota_fiscal_produto",
                columns: new[] { "cod_nota_fiscal_produto", "data_compra_produto", "fk_nota_fiscal", "fk_produto", "preco_produto", "uid_nota_fiscal_produto" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 1, 18, 45, 45, 41, DateTimeKind.Local).AddTicks(9625), 1, 1, 99.99m, new Guid("f1e628da-1f72-48bd-987f-d3a90b15ad1b") },
                    { 2, new DateTime(2023, 5, 1, 18, 45, 45, 41, DateTimeKind.Local).AddTicks(9634), 2, 2, 55.99m, new Guid("91ae3c69-8ece-423a-acb5-b18931a93792") },
                    { 3, new DateTime(2023, 5, 1, 18, 45, 45, 41, DateTimeKind.Local).AddTicks(9636), 3, 3, 88.00m, new Guid("07ff6762-69ac-4f27-9656-6fa403cd5ef7") }
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
