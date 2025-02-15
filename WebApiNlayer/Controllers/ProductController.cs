using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application;
using Application.CQRS.Products.Commands.Requests;
using Application.CQRS.Products.Queries.Requests;
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
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _sender.Send(new GetProductByIdRequest { Id = id }));

    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllProductsRequest getAllProducts)
    {
        return Ok(await _sender.Send(getAllProducts));
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
