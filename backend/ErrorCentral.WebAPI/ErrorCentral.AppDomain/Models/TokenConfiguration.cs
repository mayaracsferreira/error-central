using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCentral.AppDomain.Models
{
    namespace FSL.ApiCustomIdentity.Models
    {
        public sealed class TokenConfiguration
        {
            public const string Policy = "Bearer";
            public string ValidAudience { get; set; }
            public string ValidIssuer { get; set; }
            public int ExpirationInSeconds { get; set; }
            public bool ValidateLifetime { get; set; }
            public bool ValidateIssuerSigningKey { get; set; }
        }
    }
}
