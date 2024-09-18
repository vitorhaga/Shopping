using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shopping.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductDataTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Product",
                newName: "description");

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "id", "category_name", "description", "image_url", "name", "price" },
                values: new object[,]
                {
                    { 3L, "Camisa Social", "Camisa masculina social confeccionada em tecido 100% algodão. Colarinho estruturado e manga comprida acabada em punho com botão. Fecho à frente com botões. Modelagem slim. Logo D bordado na altura do peito.", "https://github.com/vitorhaga/Shopping/blob/master/Shopping.Images/camisa_social_rosa.jpg?raw=true", "Camisa Social Slim Masculina Manga Comprida Rosa Claro", 70m },
                    { 4L, "Camisa Social", "Camisa masculina social slim. Colarinho francês e manga comprida acabada em punho com botão. Fecho à frente com botões. Modelagem slim. Logo D bordado na altura do peito.", "https://github.com/vitorhaga/Shopping/blob/master/Shopping.Images/camisa_social_marrom_xadrez.jpg?raw=true", "Camisa Slim Masculina Manga Comprida Marrom Xadrez", 223.3m },
                    { 5L, "Blazer", "Blazer feminino alongado e acinturado. Gola com lapela e manga comprida. Bolsos de aba na frente. Fecho frontal com 1 botão forrado. Interno forrado. Tecido leve, crepe.", "https://github.com/vitorhaga/Shopping/blob/master/Shopping.Images/blazer-feminino-alongado-de-crepe-e-botao-forrado-preto.jpg?raw=true", "Blazer Feminino Alongado de Crepe e Botão Forrado Preto", 573.3m },
                    { 6L, "Calça", "Calça casual em sarja masculina. Bolsos na frente e detalhe de bolsos embutidos atrás. Fecho frontal com zíper e botão. Cós com passantes. Modelo slim.", "https://github.com/vitorhaga/Shopping/blob/master/Shopping.Images/calca-casual-de-sarja-masculina-slim-areia.jpg?raw=true", "Calça Casual de Sarja Masculina Slim Areia", 459m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "id",
                keyValue: 6L);

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Product",
                newName: "Description");
        }
    }
}
