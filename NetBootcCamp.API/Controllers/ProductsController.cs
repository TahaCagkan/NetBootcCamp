using Microsoft.AspNetCore.Mvc;
using NetBootcCamp.API.Models;

namespace NetBootcCamp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService = new();

        [HttpGet]
        public IActionResult GetProducts()
        {

            return Ok(_productService.GetAllWithCalculatedTax());
        }
    }
}
