using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.Common.Authentication
{
    public class JwtSettings
    {
        public const string SectionName = "JwtSettings";

        public string Secret { get; init; } = default!;

        public int ExpirationTimeInMinutes { get; init; }

        public string Issuer { get; init; } = default!;

        public string Audience { get; init; } = default!;
    }
}
