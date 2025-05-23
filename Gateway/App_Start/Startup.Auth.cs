﻿using Microsoft.AspNet.Identity;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Host.SystemWeb;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Notifications;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Web;

namespace ApplicationChart
{
    //public partial class Startup
    //{
    //    // Load configuration settings from PrivateSettings.config
    //    private static string appId = ConfigurationManager.AppSettings["ida:AppId"];
    //    private static string appSecret = ConfigurationManager.AppSettings["ida:AppSecret"];
    //    private static string redirectUri = ConfigurationManager.AppSettings["ida:RedirectUri"];
    //    private static string graphScopes = ConfigurationManager.AppSettings["ida:AppScopes"];

    //    public void ConfigureAuth(IAppBuilder app)
    //    {
    //        app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

    //        app.UseCookieAuthentication(new CookieAuthenticationOptions
    //        {
    //            //AuthenticationType = DefaultAuthenticationTypes.ExternalCookie,
    //            //AuthenticationMode = AuthenticationMode.Passive,
    //            //CookieName = ".AspNet." + DefaultAuthenticationTypes.ExternalCookie,
    //            //ExpireTimeSpan = TimeSpan.FromMinutes(5),
              
    //        });

    //        app.UseOpenIdConnectAuthentication(
    //            new OpenIdConnectAuthenticationOptions
    //            {
    //                ClientId = appId,
    //                Authority = " ",
    //                Scope = $"openid email profile offline_access {graphScopes}",
    //                RedirectUri = redirectUri,
    //                PostLogoutRedirectUri = redirectUri,
    //                TokenValidationParameters = new TokenValidationParameters
    //                {
    //                    // For demo purposes only, see below
    //                    ValidateIssuer = false

    //                    // In a real multi-tenant app, you would add logic to determine whether the
    //                    // issuer was from an authorized tenant
    //                    //ValidateIssuer = true,
    //                    //IssuerValidator = (issuer, token, tvp) =>
    //                    //{
    //                    //  if (MyCustomTenantValidation(issuer))
    //                    //  {
    //                    //    return issuer;
    //                    //  }
    //                    //  else
    //                    //  {
    //                    //    throw new SecurityTokenInvalidIssuerException("Invalid issuer");
    //                    //  }
    //                    //}
    //                },
    //                Notifications = new OpenIdConnectAuthenticationNotifications
    //                {
    //                    AuthenticationFailed = OnAuthenticationFailedAsync,
    //                    AuthorizationCodeReceived = OnAuthorizationCodeReceivedAsync
    //                }
    //            }
    //        );
    //    }

    //    private static Task OnAuthenticationFailedAsync(AuthenticationFailedNotification<OpenIdConnectMessage,
    //        OpenIdConnectAuthenticationOptions> notification)
    //    {
    //        notification.HandleResponse();
    //        string redirect = $"/Home/Error?message={notification.Exception.Message}";
    //        if (notification.ProtocolMessage != null && !string.IsNullOrEmpty(notification.ProtocolMessage.ErrorDescription))
    //        {
    //            redirect += $"&debug={notification.ProtocolMessage.ErrorDescription}";
    //        }
    //        notification.Response.Redirect(redirect);
    //        return Task.FromResult(0);
    //    }

    //    private async Task OnAuthorizationCodeReceivedAsync(AuthorizationCodeReceivedNotification notification)
    //    {
    //        var idClient = ConfidentialClientApplicationBuilder.Create(appId)
    //            .WithRedirectUri(redirectUri)
    //            .WithClientSecret(appSecret)
    //            .Build();

    //        string message;
    //        string debug;

    //        try
    //        {
    //            string[] scopes = graphScopes.Split(' ');

    //            var result = await idClient.AcquireTokenByAuthorizationCode(
    //                scopes, notification.Code).ExecuteAsync();

    //            message = "Access token retrieved.";
    //            debug = result.AccessToken;
    //        }
    //        catch (MsalException ex)
    //        {
    //            message = "AcquireTokenByAuthorizationCodeAsync threw an exception";
    //            debug = ex.Message;
    //        }

    //        var queryString = $"message={message}&debug={debug}";
    //        if (queryString.Length > 2048)
    //        {
    //            queryString = queryString.Substring(0, 2040) + "...";
    //        }

    //        notification.HandleResponse();
    //        notification.Response.Redirect($"/Home/Error?{queryString}");
    //    }
    //}
}