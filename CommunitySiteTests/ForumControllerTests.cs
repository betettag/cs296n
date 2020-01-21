using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CommunitySite.Repositories;
using CommunitySite.Models;
using System.Linq;
using CommunitySite.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CommunitySiteTests
{
    public class ForumControllerTests
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
            AppUser user = new AppUser();
            user.Name = "Test";
            user.Img = "https://www.bootdey.com/img/Content/avatar/avatar3.png";
            user.Info = "old man. likes yelling at kids";
            user.Admin = true;
            user.Guest = false;
            user.Phone = "123-123 1234";
            user.Email = "test@email.com";
            user.Address = "Eugene, Oregon";
            userRepo.Users.Add(user);

            AppUser a = new AppUser(true)
            {
                Name = "admin",
                Pass = "pass",
                Img = "https://www.bootdey.com/img/Content/avatar/avatar5.png",
                Phone = "123-123 1234",
                Email = "test@email.com",
                Address = "Eugene, Oregon",
                Admin = true
            };
            userRepo.Users.Add(a);

            AppUser user2 = new AppUser();
            user2.Name = "Test2";
            user2.Admin = false;
            user2.Guest = true;
            userRepo.AddUser(user2);

            AppUser user3 = new AppUser();
            user3.Name = "Test2";
            user3.Admin = false;
            user3.Guest = false;
            userRepo.AddUser(user3);

            //Guest User to be used with guest responses
            AppUser guest = new AppUser(false)
            {
                Name = "Guest",
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
            ArrangeTopics();
            ForumController forumController = new ForumController(userRepo, topicRepo,commentRepo);
            //Act
            var forum = forumController.Index(userRepo.Users[0]) as ViewResult;//user is not important
            //Assert
            Assert.True(topicRepo.Topics.First().Author.UserName == "Test");
            Assert.True(topicRepo.Topics.First().PubDate == new DateTime(2016, 7, 15, 3, 15, 0));
            Assert.NotEqual(topicRepo.Topics, forum.ViewData["Topics"]);
            Assert.NotEqual(userRepo.Users[0], forum.ViewData["user"]);

        }
        [Fact]
        public void NewMessageTest2()
        {
            //Arrange
            ArrangeTopics();
            ForumController forumController = new ForumController(userRepo, topicRepo, commentRepo);
            Message message = new Message();
            message.User = "1";
            userRepo.Users[0].Id = "1";
            var prevValue = commentRepo.Comments.Count();


            //Act
            var newmsg = forumController.NewMessage(message) as ViewResult;
            //Assert
            Assert.Equal(commentRepo.Comments[2].User, message.User);
            Assert.NotEqual(commentRepo.Comments.Count(), prevValue); //adds comment

            //Arrange
            Message message2 = new Message();
            message2.User = "2";
            prevValue = commentRepo.Comments.Count();
            //Act
            var newmsg2 = forumController.NewMessage(message2) as ViewResult;
            //Assert
            Assert.Equal(commentRepo.Comments.Count(), prevValue);//comments dont change
        }
        [Fact]
        public void NewMessageTest()
        {
            //Arrange
            ArrangeTopics();
            ForumController forumController = new ForumController(userRepo, topicRepo, commentRepo);

            //userRepo.Users[0].Id = "1";
            //Act
            var newMsg = forumController.NewMessage(userRepo.Users[0]) as ViewResult;

            //Assert
            Assert.Equal(newMsg.Model.GetType(),new Message().GetType());

            //arrange
            //userRepo.Users[0].Id = 0;
            //Act
            var newMsg2 = forumController.NewMessage(userRepo.Users[0]) as ViewResult;

            //Assert
            Assert.NotEqual(newMsg2.Model, userRepo.Users[0]);
        }

        [Fact]
        public void NewMessageVal()
        {
            //Arrange
            ArrangeTopics();
            ForumController forumController = new ForumController(userRepo, topicRepo, commentRepo);

            //userRepo.Users[0].UserID = 1;
            //Act
            var newMsg = forumController.NewMsgValidation(userRepo.Users[0]) as ViewResult;

            //Assert
            Assert.Equal(newMsg.Model.GetType(), new Message().GetType());


            //arrange
            AppUser user = new AppUser();
            //Act
            var newMsg2 = forumController.NewMsgValidation(user) as ViewResult;

            //Assert
            Assert.NotEqual(newMsg2.Model.GetType(), new Message().GetType());
        }

        [Fact]
        public void NewTopicTest()
        {
            //Arrange
            ArrangeTopics();
            Topic testTopic = new Topic
            {
                Title = "TestTitle",
                Author = userRepo.Users[0],
                Body = "TestBody"
            };
            ForumController forumController = new ForumController(userRepo, topicRepo, commentRepo);
            var prevCount = topicRepo.Topics.Count();
            //Act
            var testTitle = forumController.NewTopic(testTopic) as ViewResult ;
            
            //Assert
            Assert.True(prevCount!=topicRepo.Topics.Count());

            //arrange
            Topic testTopic2 = new Topic();
            prevCount = topicRepo.Topics.Count();
            //act
            var testTitle2 = forumController.NewTopic(testTopic2) as ViewResult;

            Assert.Equal(testTitle2.Model.GetType(), testTopic2.GetType());
            Assert.True(topicRepo.Topics.Count() == prevCount);
        }
    }
}
