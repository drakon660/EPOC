using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecm.Model
{
    public class UserModel
    {
        public string Name { get; private set; }
        public bool IsAuthenticated { get; private set; }

        protected UserModel(string name, bool isAuthenticated)
        {
            Name = name;
            IsAuthenticated = isAuthenticated;
        }

        public static UserModel CreateNew(string name, bool isAuthenticated) => new UserModel(name, isAuthenticated);
    }
}
