using E_Commerce_Backend.Application.Features.Brands.Commands.CreateBrand;
using E_Commerce_Backend.Application.Features.Brands.Queries.GetAllBrands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Backend.API;

[Route("api/[controller]/[action]")]
[ApiController]
public class BrandController(IMediator _mediator): Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAllBrands()
    {
        var response = await _mediator.Send(new GetAllBrandsRequest());
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> CreateBrand(CreateBrandCommandRequest request)
    {
        await _mediator.Send(request);
        return Ok();
    }
}