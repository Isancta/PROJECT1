using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WelLife.Plan;

namespace WelLife.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {   
        
        ProducInfo Info = new ProducInfo();

        [HttpGet]
        [Route("listOfProducts")]
        public IActionResult ListOfAllProducts()
        {
            return Ok(Info.GetAllProducts());
        }


    }
}
