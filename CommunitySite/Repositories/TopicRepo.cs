using CommunitySite.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace CommunitySite.Repositories
{
    public class TopicRepo : ITopicRepo
    {
        private AppDbContext context;
        //public IQueryable<Topic>getTopics = topics.AsQueryable().Include("Comments");
        // IQuerable objects can pass on a query to the Db instead of returing a colleciton that has to be filtered
        public List<Topic> Topics
        {
            get
            {
                return context.Topics.Include(t => t.Author).ToList();
            }
        }


        public TopicRepo(AppDbContext appDbContext) 
        {
            context = appDbContext;
        }


        public void AddTopic(Topic topic) {
            if (topic.Author != null)
            {
                context.Topics.Add(topic);
                context.SaveChanges();
            }
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
            topic = Topics.First(t => t.Title == title);
            return topic;
        }
        public Topic GetComments(int TopicID)//get new and all comments form dbset/context
        {
            Topic topic = Topics.Find(t => t.TopicID == TopicID);
            topic.Comments = context.Comments.Where(c => c.TopicTitle == TopicID.ToString() && c.Author.Guest==false)
                .OrderBy(m => m.Important)
                .Include(c => c.Author)
            .ToList();
            return topic;
        }

    }
}
