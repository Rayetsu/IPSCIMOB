using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IPSCIMOB.Models
{
    public static class MyUserPrincipalExtension
    {
        public static string Nome(this ClaimsPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {
                return user.Claims.FirstOrDefault(v => v.Type == ClaimTypes.Name).Value;
            }
            return "";
        }
    }
}
