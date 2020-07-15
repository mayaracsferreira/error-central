using ErrorCentral.AppDomain.Models;
using Microsoft.AspNetCore.Authorization;

namespace ErrorCentral.WebAPI.Controllers
{
    public sealed class MyAuthorizeAttribute : AuthorizeAttribute
    {
        public MyAuthorizeAttribute() : base(TokenConfiguration.Policy)
        {

        }
    }
}