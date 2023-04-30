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
                name: "tb_celular",
                columns: table => new
                {
                    cod_celular = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    celular_numero = table.Column<string>(type: "varchar(20)", nullable: false),
                    fk_cod_cliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_celular", x => x.cod_celular)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_tb_celular_tb_cliente_fk_cod_cliente",
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
                    { 1, "Cliente 1", new Guid("e6b4c469-6d09-4181-8af4-50251113052f") },
                    { 2, "Cliente 2", new Guid("f20eda52-1e24-4bee-96fd-e3fe01afe650") },
                    { 3, "Cliente 3", new Guid("eea7d355-9a0a-4a3f-a52d-609fe01e0f60") }
                });

            migrationBuilder.InsertData(
                table: "tb_produto",
                columns: new[] { "cod_produto", "des_produto", "preco_produto", "uid_produto" },
                values: new object[,]
                {
                    { 1, "Produto Teste 1", 99.99m, new Guid("80a49885-ec96-4343-b2d0-89390c863359") },
                    { 2, "Produto Teste 2", 55.99m, new Guid("40d70913-d22c-4daa-b1e6-04d46cff8d04") },
                    { 3, "Produto Teste 3", 88.00m, new Guid("32ce4fa5-6f2a-43f0-b3a8-9fc4ca8eda9f") }
                });

            migrationBuilder.InsertData(
                table: "tb_celular",
                columns: new[] { "cod_celular", "celular_numero", "fk_cod_cliente" },
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
                    { 1, "84815641816", 1, new DateTime(2023, 4, 29, 22, 4, 23, 0, DateTimeKind.Local).AddTicks(891), "12346578415", new Guid("b276c5d2-6e12-47d6-9e9f-c08e763224f9") },
                    { 2, "32433241816", 2, new DateTime(2023, 4, 29, 22, 4, 23, 0, DateTimeKind.Local).AddTicks(905), "12346578415", new Guid("09b5bc1f-204a-4c7e-85d2-1c81086e31b6") },
                    { 3, "67545634636", 3, new DateTime(2023, 4, 29, 22, 4, 23, 0, DateTimeKind.Local).AddTicks(906), "12341231231", new Guid("fd9fd30e-4044-49eb-a0ce-dea3bb3cce3f") }
                });

            migrationBuilder.InsertData(
                table: "tb_nota_fiscal_produto",
                columns: new[] { "cod_nota_fiscal_produto", "data_compra_produto", "fk_nota_fiscal", "fk_produto", "preco_produto", "uid_nota_fiscal_produto" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 29, 22, 4, 23, 0, DateTimeKind.Local).AddTicks(3137), 1, 1, 99.99m, new Guid("245a557a-adf9-40dd-9427-bcf5ca51429b") },
                    { 2, new DateTime(2023, 4, 29, 22, 4, 23, 0, DateTimeKind.Local).AddTicks(3148), 2, 2, 55.99m, new Guid("81039b0e-e786-49ec-ae45-d2286a89797b") },
                    { 3, new DateTime(2023, 4, 29, 22, 4, 23, 0, DateTimeKind.Local).AddTicks(3155), 3, 3, 88.00m, new Guid("70854145-b50d-47f1-ba71-a2148eedd18d") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_celular_fk_cod_cliente",
                table: "tb_celular",
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
                name: "tb_celular");

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
