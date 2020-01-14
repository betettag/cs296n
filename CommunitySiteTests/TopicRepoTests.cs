using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CommunitySite.Repositories;
using CommunitySite.Models;
using System.Linq;

namespace CommunitySiteTests
{
    public class TopicRepoTests
    {
        public Topic CreateTopic()
        {
            //Arrange
            User user = new User
            {
                UserName = "testUser",
                Pass = "pass",
                Guest = true
            };
            Topic topic = new Topic
            {
                Title = "Wellcome Future and Current Members!",
                Author = user,
                Body = "This is a message to congratulate our \"working\" forum. " +
                         "Feel free to talk to others",
                TopicID = 1
                    
            };
            return topic;
        }
        [Fact]
        public void AddTopicTest()
        {
            //Arrange
            ITopicRepo topics = new FakeTopicRepo();
            int prevValue = topics.Topics.Count();
            Topic topic = CreateTopic();
            //Act
            topics.AddTopic(topic);
            //Assert
            Assert.True(topics.Topics.Count() > prevValue);
            Assert.Contains(topics.Topics[0].Title, topic.Title);
            Assert.Contains(topics.Topics[0].Author.UserName, topic.Author.UserName);
            Assert.Contains(topics.Topics[0].Body, topic.Body);
            Assert.Contains(topics.Topics[0].TopicID.ToString(), topic.TopicID.ToString());
        }
        //[Fact]
        //public void AddCommentTest()
        //{
        //    //Arrange
        //    ITopicRepo topics = new FakeTopicRepo();
        //    Topic topic1 = CreateTopic();
        //    Topic topic2 = CreateTopic();
        //    topics.AddTopic(topic1);
        //    topics.Topics[0].Comments = new List<Message>();
        //    int prevValue = topics.Topics[0].Comments.Count();
        //    Message message = new Message()
        //    {
        //        Body = "BodyTest",
        //        UserName = "CommentUser",
        //        PubDate = DateTime.Now,
        //        //ReplyTo = "ReplyTest",
        //        MessageID = 1
                
        //    };
        //    topic2.Comments.Add(message);
        //    //Act
        //    topics.AddComment(topic1, message);
        //    //Assert
        //    Assert.True(topics.Topics[0].Comments.Count() > prevValue);
        //    Assert.False(topics.Topics[0].GetHashCode() != topic1.GetHashCode());
        //    Assert.True(topics.Topics[0].GetHashCode() != topic2.GetHashCode());
        //    Assert.Contains(topics.Topics[0].Comments[0].Body, topic2.Comments[0].Body);
        //    Assert.Contains(topics.Topics[0].Comments[0].UserName, topic2.Comments[0].UserName);
        //    Assert.Contains(topics.Topics[0].Comments[0].PubDate.ToString(), topic2.Comments[0].PubDate.ToString());
        //    //Assert.Contains(topics.Topics[0].Comments[0].ReplyTo, topic2.Comments[0].ReplyTo);
        //    Assert.Contains(topics.Topics[0].Comments[0].MessageID.ToString(), topic2.Comments[0].MessageID.ToString());
        //}
        [Fact]
        public void GetTopicByUserTest()
        {
            //Arrange
            ITopicRepo topics = new FakeTopicRepo();
            Topic topic1 = CreateTopic();
            Topic topic2 = CreateTopic();
            topics.AddTopic(topic1);
            topics.AddTopic(topic2);
            string prevValue = topics.Topics[0].Author.UserName;
            string changedValue = "Changed";
            //Act
            topics.Topics[1].Author.UserName = changedValue;
            //Assert
            Assert.True(topics.GetTopicByUser(changedValue).Author == topic2.Author);
            Assert.False(topics.GetTopicByUser(changedValue).Author == topic1.Author);

        }
        [Fact]
        public void GetTopicByIDTest()
        {
            //Arrange
            ITopicRepo topics = new FakeTopicRepo();
            Topic topic1 = CreateTopic();
            Topic topic2 = CreateTopic();
            topics.AddTopic(topic1);
            topics.AddTopic(topic2);
            int prevValue = topics.Topics[0].TopicID;
            int changedValue = 2;
            //Act
            topics.Topics[1].TopicID = changedValue;
            var topicid = topics.GetTopicByID(changedValue).TopicID;
            //Assert
            Assert.True(topicid == topic2.TopicID);
            Assert.False(topicid == topic1.TopicID);
        }
        [Fact]
        public void GetTopicByTitleTest()
        {
            //Arrange
            ITopicRepo topics = new FakeTopicRepo();
            Topic topic1 = CreateTopic();
            Topic topic2 = CreateTopic();
            topics.AddTopic(topic1);
            topics.AddTopic(topic2);
            string prevValue = topics.Topics[0].Title;
            string changedValue = "ChangedTitle";
            //Act
            topics.Topics[1].Title = changedValue;
            //Assert
            Assert.True(topics.GetTopicByTitle(changedValue).Title == topic2.Title);
            Assert.False(topics.GetTopicByTitle(changedValue).Title == topic1.Title);
        }
        [Fact]
        public void GetCommentsAndAddComment()
        {
            Topic topic = CreateTopic();
            ITopicRepo topics = new FakeTopicRepo();
            ICommentRepo comments = new FakeCommentRepo();
            var newComment = new Message()
            {
                MessageID = 1,
                Body = "test",
                User = "TEST",
                TopicTitle = "1"
            };
            var newComment2 = new Message()
            {
                MessageID = 1,
                Body = "test2",
                User = "TEST2",
                TopicTitle = "2"
            };
            var prevCount = comments.Comments.Count();
            //Act
            comments.AddComment(newComment);
            comments.AddComment(newComment2);
            topics.AddTopic(topic);
            //Assert
            Assert.True(comments.Comments.Count() != prevCount);
            Assert.True(topics.GetComments(1).Comments.Count() != comments.Comments.Count());
            Assert.Equal(topics.GetComments(1).Comments[0], newComment);
            
        }
    }
}
