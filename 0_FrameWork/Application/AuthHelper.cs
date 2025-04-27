using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using Newtonsoft.Json;

namespace _0_Framework.Application
{
    public class AuthHelper : IAuthHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public long CurrentAccountId()
        {
            throw new NotImplementedException();
        }

        public AuthViewModel CurrentAccountInfo()
        {
            var result = new AuthViewModel();
            if (!IsAuthenticated())
            {
                return result;
            }
            var clams=_contextAccessor.HttpContext.User.Claims.ToList();
            result.Id = long.Parse(clams.FirstOrDefault(x => x.Type == "AccountId").Value);
            result.Role = clams.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
            result.Fullname = clams.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
            result.Username = clams.FirstOrDefault(x => x.Type == "Username").Value;
            result.RoleId = long.Parse(clams.FirstOrDefault(x => x.Type == "RoleID").Value);
            return result;
        }

        public string CurrentAccountMobile()
        {
            throw new NotImplementedException();
        }

        public string CurrentAccountRole()
        {
            if (IsAuthenticated())
                return _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
            return null;
        }

        public List<int> GetPermissions()
        {
            throw new NotImplementedException();
        }

        public bool IsAuthenticated()
        {
            var clasms = _contextAccessor.HttpContext.User.Claims.ToList();
            return clasms.Any();
        }

        public void Signin(AuthViewModel account)
        {
            var claims = new List<Claim>
            {
                new Claim("AccountId", account.Id.ToString()),
                new Claim(ClaimTypes.Name, account.Fullname),
                new Claim(ClaimTypes.Role, account.Role),
                new Claim("RoleID",account.RoleId.ToString()),
                new Claim("Username", account.Username)
              
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new Microsoft.AspNetCore.Authentication.AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1)
            };

            _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

        public void SignOut()
        {
            _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}