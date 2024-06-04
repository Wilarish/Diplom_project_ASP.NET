using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Text;

public class BasicAuthAttribute : TypeFilterAttribute
{
    public BasicAuthAttribute() : base(typeof(BasicAuthFilter))
    {
    }

    private class BasicAuthFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string authHeader = context.HttpContext.Request.Headers["Authorization"];
            if (authHeader == null || !authHeader.StartsWith("Basic"))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var encodedCredentials = authHeader.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)[1]?.Trim();
            var decodedCredentials = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCredentials));
            var credentials = decodedCredentials.Split(':', 2);

            var username = credentials[0];
            var password = credentials[1];

            if (username != "admin" || password != "12345")
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            return;



        }
    }
}