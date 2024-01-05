using Microsoft.AspNetCore.Mvc;
using LocalLib.Model;
using LocalLib.Services;

namespace LocalLib.Controllers;

[ApiController]
[Route("local-api")]
public class LocalController : ControllerBase
{
    private readonly LocalService _service;
    public LocalController(LocalService service)
    {
        _service = service;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] User user) {
        bool successfulRegistration = await _service.Register(user);

        if (successfulRegistration) return Ok();
        else return BadRequest();
    }


    [HttpPost("borrow")]
    public async Task<IActionResult> Borrow([FromBody] Loan newLoan) {
        bool successful = await _service.Borrow(newLoan);
        if(successful) return Ok();
        return BadRequest();   
    }

    [HttpPut("return/{id}")]
    public async Task<IActionResult> Return(int id){
        await _service.Return(id);
        return Ok();
    }
}
