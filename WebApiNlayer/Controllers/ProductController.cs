using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.CQRS.Products.Commands.Requests;
using Application.CQRS.Products.Queries.Request;
namespace WebApiNlayer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductRequest createCategoryRequest)
    {
        return Ok(await _sender.Send(createCategoryRequest));
    }
  
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var getProductById = new GetProductByIdRequest { Id = id };
        var response = await _sender.Send(getProductById);
        if (response.IsSuccess == false)
        {
            return NotFound(response.Errors);
        }
        return Ok(response.Data);
    }


    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllProductsRequest request)
    { 
        return Ok(await _sender.Send(request));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteProductRequest
         deleteProductRequest)
    {
        return Ok(await _sender.Send(deleteProductRequest));
    }


    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRequest updateProductRequest)
    {
        return Ok(await _sender.Send(updateProductRequest));    
    }
}
