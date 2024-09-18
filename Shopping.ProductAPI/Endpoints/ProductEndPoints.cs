using Shopping.ProductAPI.Data.Dto;
using Shopping.ProductAPI.Repository;

namespace Shopping.ProductAPI.EndPoints
{
    internal static class ProductEndPoints
    {
        public static void ProductsEndpoints(this WebApplication app)
        {
            var productEndpoint = app.MapGroup(prefix: "api/v1/product");

            productEndpoint.MapGet(pattern: "FindById", handler: async (IProductRepository repository, long id) => 
            {
                var product = await repository.FindById(id);
                if (product is ProductDto and { Id: <= 0})
                    return Results.NotFound();

                return Results.Ok(product);
            });
            
            productEndpoint.MapGet(pattern: "FindAll", handler: async (IProductRepository repository) =>
            {
                var product = await repository.FindAll();
                if (product is null)
                    return Results.NotFound();

                return Results.Ok(product);
            });

            productEndpoint.MapPost(pattern: "Create", handler: async (IProductRepository repository, ProductDto productDto) =>
            {
                if (productDto is null)
                    return Results.BadRequest();

                var product = await repository.Create(productDto);

                return Results.Ok(product);
            }); 
            
            productEndpoint.MapPut(pattern: "Update", handler: async (IProductRepository repository, ProductDto productDto) =>
            {
                if (productDto is null)
                    return Results.BadRequest();

                var product = await repository.Update(productDto);

                return Results.Ok(product);
            });

            productEndpoint.MapDelete(pattern: "Delete", handler: async (IProductRepository repository, long id) =>
            {
                var response = await repository.Delete(id);
                if (response is false)
                    return Results.BadRequest();
                return Results.Ok(response);
            });
        }
    }
}
