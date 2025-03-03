using Application.CQRS.Users.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Application.CQRS.Users.Handlers.GetById;

namespace WebApiNlayer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(ISender sender) : ControllerBase
{


    [HttpGet]
    public async Task<IActionResult> GetById([FromQuery]int id )
    { 
        var request = new Query() { Id = id };  
        return Ok(await sender.Send(request));

    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] Application.CQRS.Users.Handlers.Register.Command request)
    {
       return Ok(await sender.Send(request)); 
    }


    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Update.Command command)
    {
        return Ok(await sender.Send(command));
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] Application.CQRS.Users.Handlers.Login.LoginRequest request)
    {
        return Ok(await sender.Send(request));
    }
}
