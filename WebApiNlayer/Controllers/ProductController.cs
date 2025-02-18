using Application.CQRS.Products.Commands.Requests;
using Application.CQRS.Products.Queries.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
    
    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetById([FromRoute]int id)
    {
        var getProductRequest = new GetProductByIdRequest { Id = id };
        var response = await _sender.Send(getProductRequest);
        if (response.IsSuccess == false || response.Data == null)
        {
            return NotFound(response.Errors);                                    
        }
        return Ok(response.Data);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery]GetAllProductsRequest getAllProductsRequest)
    {
        return Ok(await _sender.Send(getAllProductsRequest));
    }


    [HttpGet("search")]
    public async Task<IActionResult> GetByKey([FromQuery] string key)
    {
    
        return  Ok( await _sender.Send(new GetProductsByKeyRequest { Key=key}));
    }
      
    //[HttpDelete()]
    //public async Task<IActionResult> Delete([FromBody] DeleteProductRequest
    //     deleteProductRequest)
    //{
    //    return Ok(await _sender.Send(deleteProductRequest));
    //}

    [HttpDelete("id/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)  
         
    {
        DeleteProductRequest request = new DeleteProductRequest { Id = id };    
        return Ok(await _sender.Send(request));
    } 

    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRequest updateProductRequest)
    {
        return Ok(await _sender.Send(updateProductRequest));
    }


} 







