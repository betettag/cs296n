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
        private static List<AppUser> users = new List<AppUser>();

        public List<AppUser> Users => users;

        //List<AppUser> IUserRepo.Users { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public FakeUserRepo()
        {
        }
        public void AddUser(AppUser user)
        {
            if(user != null)
                users.Add(user);
        }


        public bool IsAdmin(string userName)
        {
            if (users.Exists(u => (u.UserName == userName && u.Admin == true)))
                return true;
            return false;
        }

        public bool Exists(string userName)
        {
            if (users.Exists(x => x.UserName == userName))
                return true;
            return false;
        }
        public AppUser FindByUserName(string userName)
        {
            return users.Find(u => u.UserName == userName);
        }
    }
}
