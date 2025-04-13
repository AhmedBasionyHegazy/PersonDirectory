using Microsoft.AspNetCore.Mvc;
using PersonDirectory.Core.Service;

namespace PersonDirectory.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonsController : ControllerBase
{
    private readonly PersonService _service;

    public PersonsController(PersonService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string? search)
    {
        var persons = await _service.GetPersonsAsync(search);
        return Ok(persons);
    }
}
