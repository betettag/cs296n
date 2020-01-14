using CommunitySite.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace CommunitySite.Repositories
{
    public class TopicRepo : ITopicRepo
    {
        public static List<Topic> topics = new List<Topic>();
        //public IQueryable<Topic>getTopics = topics.AsQueryable().Include("Comments");
        // IQuerable objects can pass on a query to the Db instead of returing a colleciton that has to be filtered
        public List<Topic> Topics => topics;


        public TopicRepo() 
        {
            //context = appDbContext;
            if (Topics.Count == 0)
            {

                Topic topic = new Topic
                {
                    Title = "Wellcome Future and Current Members!"
                };
                topic.Author = "admin";
                topic.Body = "This is a message to congratulate our \"working\" forum. " +
                             "Feel free to talk to others";

                Topics.Add(topic);
            }
        }


        public void AddTopic(Topic topic) => topics.Add(topic);

        public void AddComment(Topic topic, Message comment)
        {
            topic.Comments.Add(comment);
            //int index = topics.FindIndex(t => t.Title == topic.Title);
            //topics[index] = topic;
            //context.SaveChanges();
        }

        public Topic GetTopicByUser(string user)
        {
            Topic topic;
            topic = Topics.First(u => u.Title == user);
            return topic;
        }
        public Topic GetTopicByID(int ID)
        {
            Topic topic;
            topic = Topics.First(id => id.TopicID == ID);
            return topic;
        }
        public Topic GetTopicByTitle(string title)
        {
            Topic topic;
            topic = topics.First(t => t.Title == title);
            return topic;
        }

    }
}
