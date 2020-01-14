using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunitySite.Models;

namespace CommunitySite.Repositories
{
    public class FakeUserRepo : IUserRepo
    {
        private static List<User> users = new List<User>();

        public List<User> Users { get { return users; } }

        public bool IsAdmin(string userName)
        {
            if (Users.Exists(u => (u.UserName == userName && u.Admin == true)))
                return true;
            return false;
        }

        public bool Exists(string userName)
        {
            if (Users.Exists(x => x.UserName == userName))
                return true;
            return false;
        }
        public User FindByUserName(string userName)
        {
            return Users.Find(u => u.UserName == userName);
        }
    }
}
