using Ecm.Core;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecm.Infrastructure
{
    public static class AuthorizationManagerFactory
    {
        public static AuthorizationManager Create(IConfiguration configuration)
        {
            string rawUsers = configuration["Users"];
            string rawDomains = configuration["Domains"];

            string[] users = rawUsers != null ? rawUsers.Replace(" ", "").Split(',') : new string[] { };
            string[] domains = rawDomains != null ? rawDomains.Replace(" ", "").Split(',') : new string[] { };
            
            return new AuthorizationManager(users,domains);
        }
    }
}
