using ErrorCentral.AppDomain.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ErrorCentral.AppDomain.Services
{
    public sealed class IdentityLoggedUserService : ILoggedUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IdentityLoggedUserService(
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public BaseResult<T> GetLoggedUser<T>()
            where T : class, IUser
        {
            var identity = _httpContextAccessor.HttpContext?.User?.Identity as ClaimsIdentity;
            var result = new BaseResult<T>();

            if (identity?.IsAuthenticated ?? false)
            {
                result.Data = FromJson<T>(identity?.FindFirst("Data")?.Value);
                result.Success = result.Data != null;
            }

            return result;
        }

        private T FromJson<T>(
            string json)
        {
            if (json == null || json.Length == 0)
                return default;

            return JsonConvert.DeserializeObject<T>(
                json, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
        }
    }
}
