using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecm.Core
{
    public sealed class AuthorizationManager
    {
        private string[] _users;
        private string[] _domains;

        public AuthorizationManager(string[] users, string[] domains)
        {
            _users = users;
            _domains = domains;
        }

        public bool IsUserOrDomainAuthorized(string email)
        {
            bool found = false;
            string userDomain = email.Split('@')[1];

            found = _domains.Contains(userDomain, StringComparer.OrdinalIgnoreCase);
            if (!found)
            {
                found = _users.Contains(email, StringComparer.OrdinalIgnoreCase);
            }

            return found;
        }
    }
}
