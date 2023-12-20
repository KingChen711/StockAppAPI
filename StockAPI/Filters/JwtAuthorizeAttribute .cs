using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StockAPI.BusinessLogic.Interfaces;

namespace StockAPI.Filters;

public class JwtAuthorizeAttribute : TypeFilterAttribute
{
    public JwtAuthorizeAttribute() : base(typeof(JwtAuthorizeFilter))
    {

    }

    private class JwtAuthorizeFilter : IAuthorizationFilter
    {
        private readonly IJwtService _jwtService;

        public JwtAuthorizeFilter(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var jwt = context.HttpContext.Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(jwt) || !jwt.StartsWith("Bearer "))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var token = jwt.Substring("Bearer ".Length).Trim();

            try
            {
                var userId = _jwtService.ValidateToken(token);

                if (userId == null)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }

                context.HttpContext.Items["UserId"] = userId;
            }
            catch (Exception)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}