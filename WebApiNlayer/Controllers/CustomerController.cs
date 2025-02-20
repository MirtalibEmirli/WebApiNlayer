using Application.CQRS.Customers.Commands.Requests;
using Application.CQRS.Customers.Queries.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApiNlayer.Controllers;

[ApiController]
[Route("api[controller]")]
public class CustomerController(ISender sender) : Controller
{
    private readonly ISender _sender= sender;

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllCustomersRequest getAllCustomersRequest)
    {
        return Ok(await _sender.Send(getAllCustomersRequest));
    }

    [HttpPost]
    public async Task<IActionResult> AddCustomer(AddCustomerRequest request)
    {
        return Ok( await _sender.Send(request));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var request = new GetCustomerByIdRequest { Id = id };    
        return Ok(await _sender.Send(request));
    }

    [HttpGet("search")]
    public async Task<IActionResult> GetByKey([FromQuery] string key)
    {
        var request = new GetCustomerByKeyRequest { Key = key };    
        return Ok(await sender.Send(request)); 
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteById([FromQuery] int id)
    {
        var response =await _sender.Send(new DeleteCustomerRequest { Id = id });     
        return Ok(response);    
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerRequest updateCustomerRequest)
    {
        return Ok( await _sender.Send(updateCustomerRequest)); 
    }

}
