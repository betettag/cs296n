using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunitySite.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunitySite.Repositories
{
    public class FakeUserRepo : IUserRepo
    {
        private static List<User> users = new List<User>();

        public List<User> Users => users;
        public FakeUserRepo()
        {
        }
        public void AddUser(User user)
        {
            if(user != null)
                Users.Add(user);
        }


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
