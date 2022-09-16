using Microsoft.AspNetCore.Mvc;
using PollyPlayground.RequestService.Policies;

namespace PollyPlayground.RequestService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RequestController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;

    public RequestController(IHttpClientFactory  httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<ActionResult> MakeRequest()
    {
        var client = _httpClientFactory.CreateClient("Test");

        var response = await client.GetAsync("https://localhost:7299/api/response/25");

        if (response.IsSuccessStatusCode)
        {
            return Ok();
        }

        return StatusCode(StatusCodes.Status500InternalServerError);
    }
}
