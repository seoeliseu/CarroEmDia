using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using CarroEmDia.Application.Shared.Common.Interfaces;

namespace CarroEmDia.Infrastructure.Auth
{
    public class CurrentUser(IHttpContextAccessor httpContextAccessor) : ICurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public int? Id
        {
            get
            {
                var idClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier);
                return int.TryParse(idClaim?.Value, out var id) ? id : null;
            }
        }

        public string? Name => _httpContextAccessor.HttpContext?.User?.Identity?.Name;

        public string? Email => _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value;

        public bool IsAuthenticated => _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
    }
}
