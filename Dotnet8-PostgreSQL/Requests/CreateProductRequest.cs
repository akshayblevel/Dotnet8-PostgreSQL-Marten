namespace Dotnet8_PostgreSQL.Requests
{
    public record CreateProductRequest(string Name, List<string> Category, decimal Price);
}
