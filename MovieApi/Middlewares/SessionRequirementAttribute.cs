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
        private readonly List<string> _roles;
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
                    return;
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
