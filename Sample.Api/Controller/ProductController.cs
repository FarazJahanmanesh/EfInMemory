using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sample.Api.Controller;

[Route("api/[controller]/[action]")]
[ApiController]
public class ProductController : ControllerBase
{

    public ProductController()
    {
        
    }
}
