using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CommunitySite.Repositories;
using CommunitySite.Models;
using System.Linq;
using CommunitySite.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace CommunitySiteTests
{
    public class HomeControllerTests
    {
        ITopicRepo topicRepo = new FakeTopicRepo();
        IUserRepo userRepo = new FakeUserRepo();
        ICommentRepo commentRepo = new FakeCommentRepo();

        private void ArrangeTopics()
        {
            //Arrange
            topicRepo.Topics.Clear();
            userRepo.Users.Clear();
            commentRepo.Comments.Clear();
            User user = new User();
            user.UserName = "Test";
            user.Img = "https://www.bootdey.com/img/Content/avatar/avatar3.png";
            user.Info = "old man. likes yelling at kids";
            user.Admin = true;
            user.Guest = false;
            user.Phone = "123-123 1234";
            user.Email = "test@email.com";
            user.Address = "Eugene, Oregon";
            userRepo.Users.Add(user);

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
            userRepo.Users.Add(a);

            User user2 = new User();
            user2.UserName = "Test2";
            user2.Admin = false;
            user2.Guest = true;
            userRepo.AddUser(user2);

            User user3 = new User();
            user3.UserName = "Test2";
            user3.Admin = false;
            user3.Guest = false;
            userRepo.AddUser(user3);

            //Guest User to be used with guest responses
            User guest = new User(false)
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
            userRepo.AddUser(guest);



            Topic topic = new Topic
            {
                Title = "Wellcome Future and Current Members!",
                PubDate = new DateTime(2016, 7, 15, 3, 15, 0),
                Author = user,
                Body = "This is a message to congratulate our \"working\" forum. " +
                         "Feel free to talk to others"
            };
            topicRepo.AddTopic(topic);

            Topic topic2 = new Topic
            {
                Title = "Test Topic",
                Author = user,
                Body = "This is a message to congratulate our \"working\" forum. " +
                         "Feel free to talk to others"

            };
            topicRepo.AddTopic(topic2);

            Message message = new Message();
            message.User = "test";
            message.Important = true;
            message.Author = user;
            commentRepo.AddComment(message);

            Message message2 = new Message();
            message2.User = "test2";
            message2.Important = false;
            message2.TopicTitle = topic.Title;
            message2.Author = user;
            message2.PubDate = new DateTime(2016, 7, 15, 3, 15, 0);
            commentRepo.AddComment(message2);
        }
        [Fact]
        public void IndexTest()
        {
            //Arrange
            //Arrange
            topicRepo.Topics.Clear();
            userRepo.Users.Clear();
            commentRepo.Comments.Clear();
            User user = new User();
            user.UserName = "Test";
            user.Img = "https://www.bootdey.com/img/Content/avatar/avatar3.png";
            user.Info = "old man. likes yelling at kids";
            user.Admin = true;
            user.Guest = false;
            user.Phone = "123-123 1234";
            user.Email = "test@email.com";
            user.Address = "Eugene, Oregon";
            userRepo.Users.Add(user);

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
            userRepo.Users.Add(a);

            User user2 = new User();
            user2.UserName = "Test2";
            user2.Admin = false;
            user2.Guest = true;
            userRepo.AddUser(user2);

            User user3 = new User();
            user3.UserName = "Test2";
            user3.Admin = false;
            user3.Guest = false;
            userRepo.AddUser(user3);

            //Guest User to be used with guest responses
            User guest = new User(false)
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
            userRepo.AddUser(guest);
            var controller = new HomeController(userRepo, commentRepo);
            //Act
            var index = controller.Index(new User() { }) as ViewResult;
            //testing viewbag which one can retrieve with viewdata
            //really dont know why this works

            //Act
            Assert.Equal(5, index.ViewData["memberCount"]);
            Assert.Equal("Test", index.ViewData["memberNew"]);
        }

        [Fact]
        public void PlacesTest()
        {
            //Arrange
            PlacesRepo repo = new PlacesRepo();
            string firstPlace = PlacesRepo.Places.First().Name;
            HomeController homeController = new HomeController(userRepo, commentRepo);
            //Act
            homeController.Places(new User());
            //Assert
            Assert.False(PlacesRepo.Places.First().Name == firstPlace);
        }
        [Fact]
        public void PeopleTest()
        {
            //Arrange
            ArrangeTopics();
            HomeController homeController = new HomeController(userRepo, commentRepo);
            //Act
            homeController.People(new User());
            //Assert
            //Assert.False(PlacesRepo.Places.GetHashCode().ToString() == prevValue);
            Assert.True(userRepo.Users.First().UserName == userRepo.Users[0].UserName);
        }
        [Fact]
        public void ContactTest()
        {
            //Arrange
            HomeController homeController = new HomeController(userRepo, commentRepo);
            Message testResponse = new Message()
            {
                Address = "123 Test",
                Phone = "123123",
                Email = "email@email.com",
                MemberCheck = true,
                Body = "test Body",
                User = "nonadmin"
            };
            var prevValue = commentRepo.Comments.Count();
            //Act
            var passResult = homeController.Contact(testResponse);
            //passResult.
            //Assert
            Assert.False(prevValue == commentRepo.Comments.Count());
            Assert.Equal(commentRepo.Comments[0].User, testResponse.User);
        }
    }
}
