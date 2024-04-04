using Dotnet8_PostgreSQL.Exceptions;
using Dotnet8_PostgreSQL.Models;
using Dotnet8_PostgreSQL.Requests;
using Dotnet8_PostgreSQL.Responses;
using Marten;

namespace Dotnet8_PostgreSQL.Interfaces
{
    public interface IProductService
    {
        Task<GetProductsResponse> Get();
        Task<GetProductByIdResponse> Get(Guid id);
        Task<GetProductbyCategoryResponse> Get(string category);
        Task<CreateProductResponse> Create(CreateProductRequest createProductRequest);
        Task<UpdateProductResponse> Update(UpdateProductRequest updateProductRequest);
        Task<DeleteProductResponse> Delete(Guid id);
    }
}
