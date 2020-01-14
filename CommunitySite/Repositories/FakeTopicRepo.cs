using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunitySite.Models;

namespace CommunitySite.Repositories
{
    public class FakeTopicRepo:ITopicRepo
    {
        public static List<Topic> topics = new List<Topic>();
        //public IQueryable<Topic>getTopics = topics.AsQueryable().Include("Comments");
        // IQuerable objects can pass on a query to the Db instead of returing a colleciton that has to be filtered
        public List<Topic> Topics => topics;


        public FakeTopicRepo()
        {
            //context = appDbContext;
        }


        public void AddTopic(Topic topic) => topics.Add(topic);

        public void AddComment(Topic topic, Message comment)
        {
            topic.Comments.Add(comment);
            int index = topics.FindIndex(t => t.Title == topic.Title);
            topics[index] = topic;
            //context.SaveChanges();
        }

        public Topic GetTopicByUser(string user)
        {
            int topicIndex = Topics.FindIndex(t => t.Author == user);
            return topics[topicIndex];
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
