using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> Products = new List<Product>
        {
        };

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return Ok(Products);
        }
    }


}
