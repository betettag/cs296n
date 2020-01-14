using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunitySite.Models;

namespace CommunitySite.Repositories
{
    public interface IUserRepo
    {
        List<User> Users { get; }

        bool IsAdmin(string userName);//validation for if user is admin

        bool Exists(string userName);//validation for if user exists
        User FindByUserName(string userName);//validation for if user exists
    }
}
