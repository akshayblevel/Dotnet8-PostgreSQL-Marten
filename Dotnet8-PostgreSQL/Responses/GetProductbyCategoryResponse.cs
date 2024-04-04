using Dotnet8_PostgreSQL.Models;

namespace Dotnet8_PostgreSQL.Responses
{
    public record GetProductbyCategoryResponse(IEnumerable<Product> Products);
}
