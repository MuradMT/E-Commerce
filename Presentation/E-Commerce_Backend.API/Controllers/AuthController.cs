
using E_Commerce_Backend.Application.Features.Auth.Commands.Login;
using E_Commerce_Backend.Application.Features.Auth.Commands.RefreshToken;
using E_Commerce_Backend.Application.Features.Auth.Commands.Register;
using E_Commerce_Backend.Application.Features.Auth.Commands.Revoke;
using E_Commerce_Backend.Application.Features.Auth.Commands.RevokeAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Backend.API;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController(IMediator _mediator): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register(RegisterCommandRequest request)
    {
        await _mediator.Send(request);
        return StatusCode(StatusCodes.Status201Created);
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(LoginCommandRequest request)
    {
        var response=await _mediator.Send(request);
        return StatusCode(StatusCodes.Status200OK,response);
    }
    
    [HttpPost]
    public async Task<IActionResult> RefreshToken(RefreshTokenCommandRequest request)
    {
        var response=await _mediator.Send(request);
        return StatusCode(StatusCodes.Status200OK,response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Revoke(RevokeCommandRequest request)
    {
        await _mediator.Send(request);
        return StatusCode(StatusCodes.Status200OK);
    }
    [HttpPost]
    public async Task<IActionResult> RevokeAll( )
    {
       await _mediator.Send(new RevokeAllCommandRequest());
        return StatusCode(StatusCodes.Status200OK);
    }
}