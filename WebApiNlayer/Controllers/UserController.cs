using Application.CQRS.Users.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
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
}
