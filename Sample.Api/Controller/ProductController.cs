using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Api.Models;
using Sample.Api.Repositories;

namespace Sample.Api.Controller;

[Route("api/[controller]/[action]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    [HttpPost]
    public async Task <IActionResult> CreateProduct([FromBody] ProductDto dto)
    {
        var result = await _productRepository.CreateProduct(dto);
        return Ok(result.Adapt<ProductDto>());
    }


    [HttpGet]
    public async Task<IActionResult> GetAllProduct()
    {
        var result = await _productRepository.GetAllProduct();
        return Ok(result);
    }
}
