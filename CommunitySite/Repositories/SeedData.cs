using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunitySite.Models;

namespace CommunitySite.Repositories
{
    public class SeedData
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Users.Any())
            {
                User user = new User();
                user.UserName = "Jave";
                user.Img = "https://www.bootdey.com/img/Content/avatar/avatar3.png";
                user.Info = "old man. likes yelling at kids";
                user.Admin = false;
                user.Phone = "123-123 1234";
                user.Email = "test@email.com";
                user.Address = "Eugene, Oregon";
                user.Pass = "test";
                context.Users.Add(user);

                User user2 = new User();
                user2.UserName = "Dave";
                user2.Img = "https://www.bootdey.com/img/Content/avatar/avatar1.png";
                user2.Info = "old man. likes yelling at kids";
                user2.Admin = false;
                user2.Phone = "123-123 1234";
                user2.Email = "test@email.com";
                user2.Address = "Eugene, Oregon";
                user2.Pass = "test";
                context.Users.Add(user2);
                User user3 = new User();
                user3.UserName = "Name";
                user3.Img = "https://www.bootdey.com/img/Content/avatar/avatar6.png";
                user3.Info = "old man. likes yelling at kids";
                user3.Admin = false;
                user3.Phone = "123-123 1234";
                user3.Email = "test@email.com";
                user3.Address = "Eugene, Oregon";
                user3.Pass = "test";
                context.Users.Add(user3);


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
                context.Users.Add(a);

                //Guest User to be used with guest responses
                User testUser = new User(false)
                {
                    UserName = "Guest",
                    Guest = true,
                    Pass = "pass",
                    Phone = "123-123 1234",
                    Email = "test@email.com",
                    Address = "Eugene, Oregon",
                    Img = "https://www.bootdey.com/img/Content/avatar/avatar4.png",
                    Admin = false
                };
                
                Topic topic = new Topic();
                topic.Title = "Wellcome Future and Current Members!";
                topic.Author = a;
                topic.Body = "This is a message to congratulate our \"working\" forum. " +
                            "Feel free to talk to others";

                
                context.Users.Add(testUser);
                context.Topics.Add(topic);


                Message message = new Message()
                {
                    Body = "seed data comment",
                    User = testUser.UserID.ToString(),
                    Author = testUser,
                    Address = "test",
                    Email = testUser.Email,
                    MemberCheck = true,
                    Phone = testUser.Phone,
                    TopicTitle = topic.Title,
                };
                message.User = testUser.UserName;
                context.Comments.Add(message);//1st
                
                context.SaveChanges(); // save all the data 3rd
            }
        }
    }
}
