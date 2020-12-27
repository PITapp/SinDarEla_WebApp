using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace SinDarEla.Authentication
{
    public class TokenProviderOptions
    {
        public static string Audience { get; } = "SinDarElaAudience";
        public static string Issuer { get; } = "SinDarEla";
        public static SymmetricSecurityKey Key { get; } = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("SinDarElaSecretSecurityKeySinDarEla"));
        public static TimeSpan Expiration { get; } = TimeSpan.FromMinutes(10000);
        public static SigningCredentials SigningCredentials { get; } = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
    }
}
