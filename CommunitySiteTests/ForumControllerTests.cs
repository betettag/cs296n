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
        IGuestRepo guestRepo = new FakeGuestRepo();
        private void ArrangeTopics()
        {
            //Arrange
            topicRepo.Topics.Clear();
            userRepo.Users.Clear();
            guestRepo.Responses.Clear();
            User user = new User();
            user.UserName = "Test";
            user.Img = "https://www.bootdey.com/img/Content/avatar/avatar3.png";
            user.Info = "old man. likes yelling at kids";
            user.Admin = false;
            user.Phone = "123-123 1234";
            user.Email = "test@email.com";
            user.Address = "Eugene, Oregon";
            userRepo.Users.Add(user);
            Message message = new Message();
            message.User = "test";
            message.Important = true;
            Message message2 = new Message();
            message2.User = "test2";
            message2.Important = false;
            message2.PubDate = new DateTime(2016, 7, 15, 3, 15, 0);
            Topic topic = new Topic
            {
                Title = "Wellcome Future and Current Members!",
                PubDate = new DateTime(2016, 7, 15, 3, 15, 0)
        };
            topic.Author = "past topic";
            topic.Body = "This is a message to congratulate our \"working\" forum. " +
                         "Feel free to talk to others";

            topicRepo.Topics.Add(topic);
            Topic topic2 = new Topic
            {
                Title = "Test Topic"

            };
            topic2.Author = "current topic";
            topic2.Body = "This is a message to congratulate our \"working\" forum. " +
                         "Feel free to talk to others";

            topicRepo.Topics.Add(topic2);
            topicRepo.Topics[0].Comments.Add(message);
            topicRepo.Topics[0].Comments.Add(message2);
        }
        [Fact]
        public void IndexTest()
        {
            //Arrange
            ArrangeTopics();
            ForumController forumController = new ForumController(userRepo, topicRepo,guestRepo);
            //Act
            forumController.Index();
            //Assert
            Assert.True(topicRepo.Topics.First().Author == "past topic");
            Assert.False(topicRepo.Topics.First().Author == "current topic");
            Assert.False(topicRepo.Topics[0].Comments.First().User == "test");
            Assert.True(topicRepo.Topics[0].Comments.First().User == "test2");
        }
        [Fact]
        public void NewMessageTestPost()
        {
            //Arrange
            ArrangeTopics();
            ForumController forumController = new ForumController(userRepo, topicRepo, guestRepo);
            Message message = new Message();
            message.User = userRepo.Users[0].UserName;
            message.TopicTitle = topicRepo.Topics[1].Title;
            Message message2 = new Message();
            message2.User = "test";
            message2.TopicTitle = topicRepo.Topics[1].Title;

            //Act
            forumController.NewMessage(message);
            forumController.NewMessage(message2);//fail message
            //Assert
            Assert.True(topicRepo.Topics[1].Comments[0].Equals(message));
            Assert.True(topicRepo.Topics[1].Comments.Count() == 1);
        }
        [Fact]
        public void NewMessageTest()
        {
            //Arrange
            ArrangeTopics();
            ForumController forumController = new ForumController(userRepo, topicRepo, guestRepo);
            string goodTitle = topicRepo.Topics[0].Title;
            string badTitle = "badTitle";
            //Act
            forumController.NewMessage(goodTitle);

            //Assert
            Assert.Throws<Exception>(()=>forumController.NewMessage(badTitle));
            Assert.NotNull(forumController.NewMessage(goodTitle));
        }
        [Fact]
        public void NewTopicTest()
        {
            //Arrange
            ArrangeTopics();
            Topic testTopic = new Topic
            {
                Title = "TestTitle",
                Author = "TestAuthor",
                Body = "TestBody"
            };
            Topic testTopic2 = new Topic();
            ForumController forumController = new ForumController(userRepo, topicRepo, guestRepo);
            var prevValue = topicRepo.Topics.Count();
            //Act
            forumController.NewTopic(testTopic);
            forumController.NewTopic(testTopic2);
            //Assert
            Assert.Equal(topicRepo.Topics[2], testTopic);
            Assert.True(topicRepo.Topics.Count() != prevValue);
        }
    }
}
