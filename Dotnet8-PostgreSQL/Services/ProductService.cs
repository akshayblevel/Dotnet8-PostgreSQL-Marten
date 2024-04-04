using Dotnet8_PostgreSQL.Exceptions;
using Dotnet8_PostgreSQL.Interfaces;
using Dotnet8_PostgreSQL.Models;
using Dotnet8_PostgreSQL.Requests;
using Dotnet8_PostgreSQL.Responses;
using Mapster;
using Marten;

namespace Dotnet8_PostgreSQL.Services
{
    public class ProductService(IDocumentSession documentSession) : IProductService
    {
        public async Task<GetProductsResponse> Get()
        {
            var products = await documentSession.Query<Product>().ToListAsync();
            var response = new GetProductsResponse(products);
            return response;
        }

        public async Task<GetProductByIdResponse> Get(Guid id)
        {
            var product = await documentSession.LoadAsync<Product>(id);
            if (product is null)
            {
                throw new ProductNotFoundException();
            }
            var response  = new GetProductByIdResponse(product);
            return response;
        }

        public async Task<GetProductbyCategoryResponse> Get(string category)
        {
            var products = await documentSession.Query<Product>()
                .Where(p => p.Category.Contains(category))
                .ToListAsync();
            var response = new GetProductbyCategoryResponse(products);
            return response;
        }

        public async Task<CreateProductResponse> Create(CreateProductRequest createProductRequest)
        {
            var product = new Product
            {
                Name = createProductRequest.Name,
                Category = createProductRequest.Category,
                price = createProductRequest.Price
            };

            documentSession.Store(product);
            await documentSession.SaveChangesAsync();

            var response = new CreateProductResponse(product.Id);

            return response;
        }

        public async Task<UpdateProductResponse> Update(UpdateProductRequest updateProductRequest)
        {
            var product = await documentSession.LoadAsync<Product>(updateProductRequest.Id);
            if (product is null)
            {
                throw new ProductNotFoundException();
            }

            product.Name = updateProductRequest.Name;
            product.Category = updateProductRequest.Category;
            product.price = updateProductRequest.Price;

            documentSession.Update(product);
            await documentSession.SaveChangesAsync();

            return new UpdateProductResponse(true);
        }

        public async Task<DeleteProductResponse> Delete(Guid id)
        {
            documentSession.Delete(id);
            await documentSession.SaveChangesAsync();

            return new DeleteProductResponse(true);
        }
    }
}
