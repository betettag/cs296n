using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CommunitySite.Models;
using System.Globalization;

namespace CommunitySite.Repositories
{
    public class UserRepo : IUserRepo
    {
        private static List<User> users = new List<User>();
        public UserRepo()
        {
            if (Users.Count == 0)
            {
                User user = new User();
                user.UserName = "Jave";
                user.Img = "https://www.bootdey.com/img/Content/avatar/avatar3.png";
                user.Info = "old man. likes yelling at kids";
                user.Admin = false;
                user.Phone = "123-123 1234";
                user.Email = "test@email.com";
                user.Address = "Eugene, Oregon";
                Users.Add(user);

                User user2 = new User();
                user2.UserName = "Dave";
                user2.Img = "https://www.bootdey.com/img/Content/avatar/avatar1.png";
                user2.Info = "old man. likes yelling at kids";
                user2.Admin = false;
                user2.Phone = "123-123 1234";
                user2.Email = "test@email.com";
                user2.Address = "Eugene, Oregon";
                Users.Add(user2);
                User user3 = new User();
                user3.UserName = "Name";
                user3.Img = "https://www.bootdey.com/img/Content/avatar/avatar6.png";
                user3.Info = "old man. likes yelling at kids";
                user3.Admin = false;
                user3.Phone = "123-123 1234";
                user3.Email = "test@email.com";
                user3.Address = "Eugene, Oregon";
                Users.Add(user3);


                User a = new User(true)
                {
                    UserName = "admin",
                    Pass = "pass",
                    Img = "https://www.bootdey.com/img/Content/avatar/avatar5.png",
                    Phone = "123-123 1234",
                    Email = "test@email.com",
                    Address = "Eugene, Oregon",
                    Admin = true
                };
                Users.Add(a);

                //test users
                User test = new User(false)
                {
                    UserName = "nonadmin",
                    Pass = "pass",
                    Phone = "123-123 1234",
                    Email = "test@email.com",
                    Address = "Eugene, Oregon",
                    Img = "https://www.bootdey.com/img/Content/avatar/avatar4.png",
                    Admin = false
                };
                Users.Add(test);
            }
        }
        public List<User> Users { get { return users; } }
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
