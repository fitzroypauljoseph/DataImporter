using DataImporter.Core.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DataImporter.Core;
using DataImporter.Core.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace DataImporter.Api.Controllers
{
    [ApiController]

    public class ProductController : ControllerBase
    {
        IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        [Route("api/Products")]
        public IActionResult Get([FromQuery]  int CompanyId, [FromQuery] int FeedId)
    {
          IEnumerable<ProductVM> list= _productService.GetProducts(CompanyId, FeedId);

       string json = JsonConvert.SerializeObject(list);

            return Ok(json);
    }

    private readonly ILogger<ProductController> _logger;
  }
}
