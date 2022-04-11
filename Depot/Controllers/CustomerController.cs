using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Depot.MODELS;
namespace Depot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        #region Create Account 

        Customer user = new Customer();

        [HttpPost]
        [Route("Create account")]
        public IActionResult AddNewAccount(Customer NewCustomer)
        {
            try
            {
                return Created("", user.AddNewCustomer(NewCustomer));
            }
            catch (System.Exception searchex)
            {

                return BadRequest(searchex.Message);
            }
        }

        #endregion

        #region List of Customer

        [HttpGet]
        [Route("list of customer")]
        public IActionResult GetlistOfCustomers()
        {
            try
            {
                return Ok(user.GetListOfCustomer());
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        #endregion

        #region Search Customer Info by name

        [HttpGet]
        [Route(" Find Customer Info by name")]
        public IActionResult YourProductDetail(string prName)
        {
            try
            {
                return Ok(user.FindCustoByName(prName));
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }


            #endregion
        }

    }

}
