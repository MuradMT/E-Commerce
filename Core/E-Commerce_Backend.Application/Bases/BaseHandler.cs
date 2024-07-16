using System.Security.Claims;
using E_Commerce_Backend.Application.Interfaces.AutoMapper;
using E_Commerce_Backend.Application.UnitOfWorks;
using Microsoft.AspNetCore.Http;

namespace E_Commerce_Backend.Application.Bases;

public class BaseHandler
{
    public readonly IUnitOfWork _unitOfWork;
    public readonly IMapper _mapper;
    public readonly IHttpContextAccessor _context;
    public readonly string userId;

    public BaseHandler(IUnitOfWork unitOfWork,IMapper mapper,IHttpContextAccessor context)
    {
        _unitOfWork = _unitOfWork;
        _mapper = _mapper;
        _context = _context;
        userId = _context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}