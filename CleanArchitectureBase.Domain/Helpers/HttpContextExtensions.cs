using CleanArchitectureBase.Domain.Helpers;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Domain.Helpers
{
    public static class HttpContextExtensions
    {
        public static string GetCurrentUserId(this IHttpContextAccessor contextAccessor)
        {
            if (contextAccessor == null)
                throw new ArgumentNullException(nameof(contextAccessor));

            if (!contextAccessor.HttpContext.User.Identity.IsAuthenticated)
                return string.Empty;

            return contextAccessor.HttpContext.User.GetCurrentUserId();
        }

        public static string GetCurrentUserId(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal == null || !claimsPrincipal.Claims.NotNullOrEmpty())
                throw new ArgumentNullException(nameof(claimsPrincipal));

            var claim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == JwtConstant.KeyUserId);
            if (claim == null)
                return string.Empty;

            return claim.Value;
        }

        public static string GetCurrentUsername(this IHttpContextAccessor contextAccessor)
        {
            if (contextAccessor == null)
                throw new ArgumentNullException(nameof(contextAccessor));

            if (!contextAccessor.HttpContext.User.Identity.IsAuthenticated)
                return string.Empty;

            return contextAccessor.HttpContext.User.GetCurrentUsername();
        }

        public static string GetCurrentUsername(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal == null || !claimsPrincipal.Claims.NotNullOrEmpty())
                throw new ArgumentNullException(nameof(claimsPrincipal));

            var claim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == JwtConstant.KeyUsername);
            if (claim == null)
                throw new ArgumentNullException(nameof(claim));

            return claim.Value;
        }

        public static string GetCurrentCifCodeFromToken(this IHttpContextAccessor contextAccessor)
        {
            if (contextAccessor == null)
                throw new ArgumentNullException(nameof(contextAccessor));

            if (contextAccessor.HttpContext == null)
                return string.Empty;

            var token = GetToken(contextAccessor);
            if (!string.IsNullOrEmpty(token))
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = handler.ReadJwtToken(token);
                var claims = jwtSecurityToken.Claims.ToList();
                return claims.First(claims => claims.Type == JwtConstant.KeyCifCode).Value;
            }
            return string.Empty;
        }

        public static string GetCurrentUserNameFromToken(this IHttpContextAccessor contextAccessor)
        {
            if (contextAccessor == null)
                throw new ArgumentNullException(nameof(contextAccessor));

            if (contextAccessor.HttpContext == null)
                return string.Empty;

            var token = GetToken(contextAccessor);
            if (!string.IsNullOrEmpty(token))
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = handler.ReadJwtToken(token);
                var claims = jwtSecurityToken.Claims.ToList();
                return claims.First(claims => claims.Type == JwtConstant.KeyUsername).Value;
            }
            return string.Empty;
        }

        public static string GetToken(this IHttpContextAccessor contextAccessor)
        {
            if (contextAccessor == null)
                throw new ArgumentNullException(nameof(contextAccessor));

            if (contextAccessor.HttpContext == null)
                return string.Empty;

            var token = contextAccessor.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Replace("Bearer ", string.Empty);
            if (token != null)
                return token;
            return string.Empty;
        }
    }
}
