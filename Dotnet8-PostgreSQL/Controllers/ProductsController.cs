using Dotnet8_PostgreSQL.Interfaces;
using Dotnet8_PostgreSQL.Models;
using Dotnet8_PostgreSQL.Requests;
using Dotnet8_PostgreSQL.Responses;
using Microsoft.AspNetCore.Mvc;


namespace Dotnet8_PostgreSQL.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController(IProductService productService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<GetProductsResponse>> GetAllProducts()
        {
            var products = await productService.Get();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetProductByIdResponse>> GetProductById(Guid id)
        {
            var product = await productService.Get(id);
            return Ok(product);
        }

        [HttpGet("category/{category}")]
        public async Task<ActionResult<GetProductbyCategoryResponse>> GetProductsByCategory(string category)
        {
            var product = await productService.Get(category);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<CreateProductResponse>> Add(CreateProductRequest createProductRequest)
        {
            var response = await productService.Create(createProductRequest);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateProductResponse>> UpdateProduct(UpdateProductRequest updateProductRequest)
        {
            var response = await productService.Update(updateProductRequest);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            var response = await productService.Delete(id);
            return Ok(response);
        }
    }
}
