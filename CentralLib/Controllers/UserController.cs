using Microsoft.AspNetCore.Mvc;

using CentralLib.Model;
using CentralLib.Services; 

namespace CentralLib.Controllers;

[ApiController]
[Route("")]
public class UserController : ControllerBase
{
    private readonly UserService _service;

    public UserController(UserService service) {
        _service = service;
    }

    
    [HttpPost("register")]
    public IActionResult RegisterUser([FromBody] User user)
    {
        try {
            _service.Register(user);
            
            return Ok();
        }
        catch  {
            return BadRequest();
        }
    }

    [HttpPut("borrow/{id}")]
    public IActionResult Borrow(int id) {
        try {
            _service.Borrow(id);
            return Ok();
        }
        catch (Exception ex){
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("return/{id}")]
    public IActionResult Return(int id) {
        try {
            _service.ReturnBook(id);
            return Ok();
        }
        catch {
            return BadRequest("user not found");
        }
    }
}
