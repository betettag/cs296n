using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CommunitySite.Models;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Microsoft.AspNetCore.Identity;

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
        private readonly UserManager<AppUser> userManager; //this is wrong and i need to move code to the admin controller
        public List<AppUser> Users => userManager.Users.ToList();

        public void AddUser(AppUser user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public AppUser FindByUserName(string userName)
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
