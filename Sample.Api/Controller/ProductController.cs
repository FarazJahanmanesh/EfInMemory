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
    public async Task <IActionResult> CreateProduct([FromBody] ProductDto request)
    {
        var result = await _productRepository.CreateProduct(request);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProduct()
    {
        var result = await _productRepository.GetAllProduct();
        return Ok(result);
    }
    [HttpGet]
    public async Task<IActionResult> GetProductById([FromQuery] int id)
    {
        var result = await _productRepository.GetProductById(id);
        return Ok(result);
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteProduct([FromQuery]int id) 
    {
        var result = await _productRepository.DeleteProduct(id);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody] Product request)
    {
        var result = await _productRepository.UpdateProduct(request);
        return Ok(result);
    }
}
