using E_Commerce_Backend.Application.Features.Products.Commands.CreateProduct;
using E_Commerce_Backend.Application.Features.Products.Commands.DeleteProduct;
using E_Commerce_Backend.Application.Features.Products.Commands.UpdateProduct;
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

      [HttpPost]
      public async Task<IActionResult> CreateProduct(CreateProductCommandRequest request){
            await _mediatr.Send(request);
            return Ok();
      }

      [HttpPut]
      public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest request){
            await _mediatr.Send(request);
            return Ok();
      }

      [HttpDelete]
      public async Task<IActionResult> DeleteProduct(DeleteProductCommandRequest request){
            await _mediatr.Send(request);
            return Ok();
      }

}
