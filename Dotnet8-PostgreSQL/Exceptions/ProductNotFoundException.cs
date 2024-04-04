namespace Dotnet8_PostgreSQL.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException() : base("Product not found!")
        {

        }
    }
}
