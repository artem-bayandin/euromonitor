using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace WebAPI.Infrastructure
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private List<Claim> _claimsList => _httpContextAccessor?.HttpContext?.User?.Claims.ToList();

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool IsAuthenticated => _httpContextAccessor?.HttpContext?.User?.Identity?.IsAuthenticated ?? false;

        public Guid? UserId
        {
            get
            {
                var value = GetClaimValue(ClaimTypes.NameIdentifier);

                if (value != null
                    && Guid.TryParse(value, out Guid id)
                    && id != Guid.Empty)
                    return id;

                return null;
            }
        }

        public string Email
        {
            get
            {
                return GetClaimValue(ClaimTypes.Email);
            }
        }

        private string GetClaimValue(string schema)
        {
            return _claimsList?.FirstOrDefault(c => c.Type == schema)?.Value;
        }

        private List<string> GetClaimValues(string schema)
        {
            return _claimsList?.Where(c => c.Type == schema).Select(c => c.Value)?.ToList();
        }
    }
}
