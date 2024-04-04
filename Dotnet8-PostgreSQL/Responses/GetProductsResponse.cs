using Dotnet8_PostgreSQL.Models;

namespace Dotnet8_PostgreSQL.Responses
{
    public record GetProductsResponse(IEnumerable<Product> Products);
}
