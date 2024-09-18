using Microsoft.EntityFrameworkCore;

namespace Shopping.ProductAPI.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(){}
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options){}
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Camisa Social Slim Masculina Manga Comprida Rosa Claro",
                Price = new decimal(70),
                Description = "Camisa masculina social confeccionada em tecido 100% algodão. Colarinho estruturado e manga comprida acabada em punho com botão. Fecho à frente com botões. Modelagem slim. Logo D bordado na altura do peito.",
                ImageUrl = "https://github.com/vitorhaga/Shopping/blob/master/Shopping.Images/camisa_social_rosa.jpg?raw=true",
                CategoryName = "Camisa Social"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Name = "Camisa Slim Masculina Manga Comprida Marrom Xadrez",
                Price = new decimal(223.3),
                Description = "Camisa masculina social slim. Colarinho francês e manga comprida acabada em punho com botão. Fecho à frente com botões. Modelagem slim. Logo D bordado na altura do peito.",
                ImageUrl = "",
                CategoryName = "Camisa Social"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 5,
                Name = "Blazer Feminino Alongado de Crepe e Botão Forrado Preto",
                Price = new decimal(573.3),
                Description = "Blazer feminino alongado e acinturado. Gola com lapela e manga comprida. Bolsos de aba na frente. Fecho frontal com 1 botão forrado. Interno forrado. Tecido leve, crepe.",
                ImageUrl = "",
                CategoryName = "Blazer"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 6,
                Name = "Calça Casual de Sarja Masculina Slim Areia",
                Price = new decimal(459),
                Description = "Calça casual em sarja masculina. Bolsos na frente e detalhe de bolsos embutidos atrás. Fecho frontal com zíper e botão. Cós com passantes. Modelo slim.",
                ImageUrl = "",
                CategoryName = "Calça"
            });

        }
    }
}
