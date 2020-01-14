using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CommunitySite.Repositories;
using CommunitySite.Models;
using System.Linq;

namespace CommunitySiteTests
{
    public class UserRepoTests
    {
        public IUserRepo CreateUsers()
        {
            //Arrange
            IUserRepo userRepo = new FakeUserRepo();
            User user = new User();
            user.UserName = "Jave";
            user.Img = "https://www.bootdey.com/img/Content/avatar/avatar3.png";
            user.Info = "old man. likes yelling at kids";
            user.Admin = false;
            user.Phone = "123-123 1234";
            user.Email = "test@email.com";
            user.Address = "Eugene, Oregon";
            userRepo.Users.Add(user);

            User user2 = new User();
            user2.UserName = "Dave";
            user2.Img = "https://www.bootdey.com/img/Content/avatar/avatar1.png";
            user2.Info = "old man. likes yelling at kids";
            user2.Admin = false;
            user2.Phone = "123-123 1234";
            user2.Email = "test@email.com";
            user2.Address = "Eugene, Oregon";
            userRepo.Users.Add(user2);

            return userRepo;
        }
        [Fact]
        public void AddUserTest()
        {
            //Arrange
            IUserRepo userRepo = new FakeUserRepo();
            int prevValue = userRepo.Users.Count();
            User user = new User();
            user.UserName = "test";
            user.Img = "test.jpg";
            user.Info = "infotest";
            user.Admin = false;
            user.Phone = "123";
            user.Email = "test@email.com";
            user.Address = "addresstest";
            user.Pass = "passtest";
            user.UserID = 7;
            user.Guest = false;
            User user2 = new User(true);
            //Act
            userRepo.Users.Add(user);
            userRepo.Users.Add(user2);
            //Assert
            Assert.True(userRepo.Users.Count() > prevValue);
            Assert.True(userRepo.Users[0].Equals(user));
            Assert.Contains(userRepo.Users[0].UserName, user.UserName);
            Assert.Contains(userRepo.Users[0].Img, user.Img);
            Assert.Contains(userRepo.Users[0].Info, user.Info);
            Assert.Contains(userRepo.Users[0].Admin.ToString(), user.Admin.ToString());
            Assert.Contains(userRepo.Users[0].Phone, user.Phone);
            Assert.Contains(userRepo.Users[0].Email, user.Email);
            Assert.Contains(userRepo.Users[0].Address, user.Address);
            Assert.Contains(userRepo.Users[0].Pass, user.Pass);
            Assert.Contains(userRepo.Users[0].UserID.ToString(), user.UserID.ToString());
            Assert.Contains(userRepo.Users[1].Admin.ToString(), user2.Admin.ToString());
        }
        [Fact]
        public void FindByUserName()
        {
            //Arrange
            IUserRepo userRepo = CreateUsers();
            string testString = userRepo.Users[0].UserName;
            string testString2 = userRepo.Users[1].UserName;
            //Act
            User user1 = userRepo.FindByUserName(testString);
            User user2 = userRepo.FindByUserName(testString2);
            //Assert
            Assert.False(user1.Equals(user2));
            Assert.True(user1.UserName == userRepo.Users[0].UserName);
            Assert.True(user2.UserName == userRepo.Users[1].UserName);

        }
        [Fact]
        public void IsAdmin()
        {            
            //Arrange
            IUserRepo userRepo = CreateUsers();
            string testString = userRepo.Users[0].UserName;
            userRepo.Users[0].Admin = true;
            string testString2 = userRepo.Users[1].UserName;
            //Act
            bool resultTrue = userRepo.IsAdmin(testString);
            bool resultFalse = userRepo.IsAdmin(testString2);
            //Assert
            Assert.False(resultFalse);
            Assert.True(resultTrue);
        }
        [Fact]
        public void Exists()
        {
            //Arrange
            IUserRepo userRepo = CreateUsers();
            string testString = userRepo.Users[0].UserName;
            userRepo.Users[0].UserName = "Changed";
            string testString2 = testString;
            testString = userRepo.Users[0].UserName;
            //Act
            bool resultTrue = userRepo.Exists(testString);
            bool resultFalse = userRepo.Exists(testString2);
            //Assert
            Assert.False(resultFalse);
            Assert.True(resultTrue);

        }
    }
}
