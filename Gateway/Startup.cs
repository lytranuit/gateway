using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using Microsoft.Owin;
using Microsoft.AspNet.SignalR;
using System.Web.Http;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Cors;
using ApplicationChart.Models;
using ApplicationChart.App_Start;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.Owin.Extensions;

[assembly: OwinStartup(typeof(ApplicationChart.Startup))]
namespace ApplicationChart
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            //ConfigureAuth(app);
            app.UseStageMarker(PipelineStage.Authenticate);
            app.MapSignalR();
            GlobalHost.HubPipeline.RequireAuthentication();

            app.UseCors(CorsOptions.AllowAll);
            OAuthAuthorizationServerOptions option = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
                Provider = new ApplicationAuthProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(30),
                AllowInsecureHttp = true,
                RefreshTokenProvider = new RefreshTokenProvider()
            };

            app.UseOAuthAuthorizationServer(option);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        
        }
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }
    }
}