using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApiNlayer.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TableController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender
        ;

    [HttpPost]
    public async Task<IActionResult> AddTable(Application.CQRS.Tables.Handlers.AddTable.Command command)
    {
        return Ok(await _sender.Send(command));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTableById(int id)
    {
        var query = new Application.CQRS.Tables.Handlers
            .GetTableById.Query
        { Id = id };
        return Ok(await _sender.Send(query));

    }





}
