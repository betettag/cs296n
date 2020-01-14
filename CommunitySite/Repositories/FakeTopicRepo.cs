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

        public Topic GetTopicByUser(string user)
        {
            int topicIndex = Topics.FindIndex(t => t.Author.UserName == user);
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
        public Topic GetComments(int TopicID)
        {
            Topic topic = Topics.Find(t => t.TopicID == TopicID);
            FakeCommentRepo commentRepo = new FakeCommentRepo();
            List<Message>comments = commentRepo.Comments;
            topic.Comments = comments.Where(c => c.TopicTitle == TopicID.ToString())
                .OrderBy(m => m.Important)
                .ToList();
            return topic;
        }
    }
}
