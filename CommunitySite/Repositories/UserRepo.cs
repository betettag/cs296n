using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CommunitySite.Models;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace CommunitySite.Repositories
{
    public class UserRepo : IUserRepo
    {
        //private static List<User> users = new List<User>();
        private AppDbContext context;
        public UserRepo(AppDbContext appDbContext)
        {
            context = appDbContext;
        }
        public List<User> Users => context.Users.ToList();

        public void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public User FindByUserName(string userName)
        {
            return Users.Find(u => u.UserName == userName);
        }

        public bool IsAdmin(string userName)//validation for if user is admin
        {
            if (Users.Exists(u => (u.UserName == userName && u.Admin ==true)))
                return true;
            return false;
        }

        public bool Exists(string userName)//validation for if user exists
        {
            if (Users.Exists(x => x.UserName == userName))
                return true;
            return false;
        }
    }
}
