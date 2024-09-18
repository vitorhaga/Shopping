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
                ImageUrl = "",
                CategoryName = "Camisa Social"
            });

        }
    }
}
