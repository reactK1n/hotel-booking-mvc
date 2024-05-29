using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http.Controllers;

namespace hotel_booking_mvc.CustomAuthorization
{
    /// <summary>
    /// Custom Authentication Class that overrides the OnActionExecuting Method in ActionFilterAttribute
    /// to provide custom control over how users are authenticated for controllers and action methods. 
    /// </summary>
    public class CustomAuthenticationFilter : ActionFilterAttribute
    {
        private readonly string[] roles;
        public HttpClient Client { get; set; }

        public CustomAuthenticationFilter(params string[] roles)
        {
            this.roles = roles;
            Client = new HttpClient
            {
                BaseAddress = new Uri(Startup.StaticConfig.GetSection("baseUrl").Value)
            };

        }


        /// <summary>
        ///  It's called before the actions decorated with the CustomAuthenticationFilter are executed to check
        ///  if the User have Authorization to Execute such actions.
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any()) return;

            var token = context.HttpContext.Session.GetString("access_token");

            if (!string.IsNullOrWhiteSpace(token))
            {
                // If token is not null, it makes an Api call to verify if Logged in User's
                // role/roles is contained in the array of permitted roles.
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage result = Client.PostAsync(
                    "api/Authentication/validate-user", 
                    new StringContent(JsonConvert.SerializeObject(new { Roles = roles }), Encoding.UTF8, "application/json")
                    ).GetAwaiter().GetResult();
                if (result.IsSuccessStatusCode)
                {
                    return;
                }
                // If User's role/roles is not contained in the array of permitted roles, it redirects User to the UnAuthorized Page
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                    { "controller", "Errors" },
                    { "action", "Error401" }
                    });

            }
            // If token is null, it redirects user to the Login Page
            context.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                { "controller", "Auth" },
                { "action", "Login" }
                });
        }


        private static bool SkipAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
        {
            Contract.Assert(filterContext != null);

            return filterContext.ActionDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute), true).Any()
                   || filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute), true).Any();
        }
    }
}




