using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Depot.MODELS;
namespace Depot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        Products prInfo = new Products();

        #region EXPLORE STOCK CONTENT

        [HttpGet]
        [Route("List")]
        public IActionResult GetAllProducts()
        {
            try
            {
                return Ok(prInfo.GetAllProducts());
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        #endregion

        #region GET PRODUCT BY NAME
        [HttpGet]
        [Route("Search")]
        public IActionResult GetProductByName(string prName)
        {
            try
            {
                return Ok(prInfo.FindPrByName(prName));
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }

            #endregion

        }

        #region
        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteProducts(int Id)
        {
            try
            {
                return Accepted(prInfo.DeleteProduct(Id));
            }
            catch (System.Exception delex)
            {

                return BadRequest(delex.Message);
            }
        }
        #endregion
    }

}