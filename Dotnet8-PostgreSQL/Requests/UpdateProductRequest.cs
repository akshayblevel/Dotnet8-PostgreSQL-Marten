namespace Dotnet8_PostgreSQL.Requests
{
    public record UpdateProductRequest(Guid Id, string Name, List<string> Category, decimal Price);
}
