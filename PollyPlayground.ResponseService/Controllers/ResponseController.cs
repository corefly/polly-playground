using Microsoft.AspNetCore.Mvc;

namespace PollyPlayground.ResponseService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResponseController : ControllerBase
{
    [Route("{id:int}")]
    [HttpGet]
    public ActionResult GetResponse(int id)
    {
        var rnd = new Random();
        var rndInteger = rnd.Next(1, 101);

        if (rndInteger >= id)
        {
            Console.WriteLine("Fail");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        
        Console.WriteLine("Good");
        return Ok();
    }
}
