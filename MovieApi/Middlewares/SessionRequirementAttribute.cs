using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MovieApi.Middlewares
{
    public class SessionRequirementAttribute : Attribute, IAuthorizationFilter
    {
        private List<string> _roles;
        public SessionRequirementAttribute(params string[] roles) 
        {
            _roles = roles.ToList();
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
           
             if (string.IsNullOrEmpty(token))
             {
                context.Result = new UnauthorizedResult();
                return;
             }
            

            var roles = HandleToken.HanleToken(token);
            if(roles != null)
            {
               foreach(var role in roles)
                {
                    if (!_roles.Contains(role))
                    {
                        context.HttpContext.Response.StatusCode = 401;
                        return;
                    }
                }
            }
            if(roles == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            
        }
    }
}
