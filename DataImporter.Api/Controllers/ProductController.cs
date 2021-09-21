using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DataImporter.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProductController : ControllerBase
  {
    public ProductController(ILogger<ProductController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
      return Ok();
    }

    private readonly ILogger<ProductController> _logger;
  }
}
