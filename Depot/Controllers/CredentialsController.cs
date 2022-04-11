using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Depot.MODELS;

namespace Depot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CredentialsController : ControllerBase
    {
        Customer user = new Customer();

        [HttpPost]
        [Route(" sign In")]

        public IActionResult Authentification(string userN, string passW)
        {
            try
            {
                return Ok(user.SignIn(userN, passW);
            }
            catch (System.Exception)
            {

                throw;
            }

        }

    }
}
