using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WelLives.WHmodels;



namespace WelLives.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WHouseController : ControllerBase
    {
        ProductsInfo pInfo = new ProductsInfo();

        #region Warehouse product list

        [HttpGet]
        [Route("list of all our products")]
        public IActionResult listOfAllProducts()
        {
         return Ok(pInfo.GetAllProducts());
        }
        #endregion

        #region Search product by name
        [HttpGet]
        [Route ("Your search product details")]
        public IActionResult YourProductDetail(string prName)
        {
            try
            {
                return Ok(pInfo.FindPrByName (prName));
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }

            #endregion

            #region Add a custome

            [HttpPost]
            [Route("Welcome New Customer")]

            public IActionResult AddNewCustomer (ProductsInfo newCustomer)
            {
                try
                {
                    return Created(pInfo.)
                    }
                catch (System.Exception)
                {

                    throw;
                }
            }
        }

    }
}
