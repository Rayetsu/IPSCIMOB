using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace IPSCIMOB.Models
{
    public class MyUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public MyUserClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> optionsAcessor) : base(userManager, roleManager, optionsAcessor)
        {

        }
            public async override Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            var principal = await base.CreateAsync(user);

            ((ClaimsIdentity)principal.Identity).AddClaims(new[]
            {
                //ClaimType é unico cada tipo para uma property 
                //new Claim(ClaimTypes.Name, user.Nome),
                //new Claim(ClaimTypes.Country, user.NumeroInterno.ToString()),
                //new Claim(ClaimTypes.MobilePhone, user.NumeroDoBI.ToString()),
                //new Claim(ClaimTypes.DateOfBirth, user.DataDeNascimento.ToString()),
                //new Claim(ClaimTypes.StreetAddress, user.Morada),
                //new Claim(ClaimTypes.MobilePhone, user.Telefone.ToString()),
                //new Claim(ClaimTypes.MobilePhone, user.NumeroInterno.ToString()),
                //new Claim(ClaimTypes.MobilePhone, user.PartilhaMobilidade.ToString()),
                //new Claim(ClaimTypes.MobilePhone, user.NumeroInterno.ToString()),
                //new Claim(ClaimTypes.MobilePhone, user.IsFuncionario.ToString()),
                new Claim(ClaimTypes.MobilePhone, user.IsDadosVerificados.ToString())

            });

            return principal;
        }
    }
}
