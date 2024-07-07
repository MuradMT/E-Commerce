using E_Commerce_Backend.Application.Features.Products.Queries.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Backend.API;


[Route("api/[controller]/[action]")]
[ApiController]
public class ProductController(IMediator _mediatr):ControllerBase
{
      [HttpGet]
      public async Task<IActionResult> GetAllProducts(){
            var result=await _mediatr.Send(new GetAllProductsQueryRequest());
            return Ok(result);
      }
}
