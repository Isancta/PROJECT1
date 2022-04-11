using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Depot.MODELS;
using System;

namespace Depot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        Order order = new Order();

        [HttpPost]
        [Route("AddOrder")]
        public IActionResult AddOrder(Order NewOrder)
        {
            try
            {
                return Created("", order.AddOrder(NewOrder));
            }
            catch (Exception searchex)
            {

                return BadRequest(searchex.Message);
            }
        }

        [HttpGet]
        [Route("GetOrder")]
        public IActionResult GetOrder(int OrderId)
        {
            Order order = new Order();
            try
            {
                return Ok(order.GetOrderById(OrderId));
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }

        }



        //[HttpPut]
        //[Route("UpdateOrder")]
        //public IActionResult UpdateOrder(Order NewOrder)
        //{
        //    try
        //    {
        //        return Accepted(order.EditOrder(NewOrder));
        //    }
        //    catch (Exception searchex)
        //    {

        //        return BadRequest(searchex.Message);
        //    }

        //}
    }
}

