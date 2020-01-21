using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunitySite.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunitySite.Repositories
{
    public interface IUserRepo
    {
        List<AppUser> Users();

        bool IsAdmin(string userName);//validation for if user is admin

        bool Exists(string userName);//validation for if user exists
        AppUser FindByUserName(string userName);//validation for if user exists
        void AddUser(AppUser user);//adding user to database
    }
}
