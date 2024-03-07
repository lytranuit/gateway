using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Cors;

namespace ApplicationChart.Models
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ApplicationAuthProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            AuthRepository authRepository = new AuthRepository();
            var Valid = authRepository.ValidateUser(context.UserName.ToUpper(),
            context.Password, GetUser_IP(), string.Join(",", context.Request.Headers.GetValues("User-Agent").ToArray()));
            if (Valid.Item1 == true)
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName.ToUpper()));
                foreach (var role in Valid.Item2.Split(',').ToList())
                    identity.AddClaim(new Claim(ClaimTypes.Role, role));
                context.Validated(identity);
            }
            else if (Valid.Item1 == null)
            {
                context.SetError("invalid_grant", "Tài khoản đã bị khóa sau một thời gian dài không sử dụng!");
                return;
            }
            else
            {
                context.SetError("invalid_grant", "Tài khoản hoặc mật khẩu không chính xác");
                return;
            }
        }
        protected string GetUser_IP()
        {
            string VisitorsIPAddr = string.Empty;
            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                VisitorsIPAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
            {
                VisitorsIPAddr = HttpContext.Current.Request.UserHostAddress;
            }
            return VisitorsIPAddr;
        }

        public override Task TokenEndpointResponse(OAuthTokenEndpointResponseContext context)
        {
            context.Properties.AllowRefresh = true;
            context.Properties.IsPersistent = true;
            return base.TokenEndpointResponse(context);
        }
    }
}