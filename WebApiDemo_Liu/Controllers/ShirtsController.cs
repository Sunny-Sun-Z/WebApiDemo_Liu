using Microsoft.AspNetCore.Mvc;
using WebApiDemo_Liu.Models;
using WebApiDemo_Liu.Models.Filters;
using WebApiDemo_Liu.Models.Repositories;

namespace WebApiDemo_Liu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]  // the controller`s name lower case first char.
    public class ShirtsController : ControllerBase
    {
       // private ShirtRepository shirtRepo;
        public ShirtsController()
        {
            
        }

        [HttpGet]
       // [Route("/shirts")] 
        public IActionResult GetShirts()
        {
            return Ok("Reading all shirts");
        }

        //[HttpGet("/shirsts/{id:int}")]  // if no above [Route("api/[controller]")]
        // if using just string color or [FromRoute]  in parameter  
        //[HttpGet("{id:int}/{color}")] 
        // if using [FromQuery] or using [FromHeader]: it should be:
        [HttpGet("{id:int}")]

        // above color parameter only primitive type
        //public string GetShirtById(int id, [FromBody] string color)
        [Shirt_ValidateShirtIdFilter]
        public IActionResult GetShirtById(int id)
        {
            //// return $"Reading shirt with id: {id}, color: {color}";
            //if(id<=0)
            //    return BadRequest();

            //var shirt = ShirtRepository.GetShirtById(id);
            //if (shirt == null)
            //    return NotFound();
            //  return Ok(shirt);

            return Ok(ShirtRepository.GetShirtById(id));
         }

        // if using [FromBody], parameter has to be an object
        // [HttpPost("/shirts")]
        [HttpPost]
        // if using [FromForm], parameter has to be an object
        public IActionResult CreateShirt([FromBody] Shirt shirt)
        {
            return Ok("Create a shirt");
        }

        //[HttpPut("/shirts/{id:int}")]
        [HttpPut("{id:int}")]
        public IActionResult UpdateShirt(int id)
        {
            return Ok($"Update a shirt with id: {id}");
        }

        //[HttpDelete("/shirts/{id}")]
        [HttpDelete("{id}")]
        public IActionResult DeleteShirt(int id)
        {
            return Ok($"delete a shirt with id: {id}");
        }
    }
}
