using System.Linq;
using CommunitySite.Models;
using System.Collections.Generic;

namespace CommunitySite.Repositories
{
    public interface ITopicRepo
    {
        //IQueryable<Topic> Topics { get; }
        List<Topic> Topics { get; }
        void AddTopic(Topic topic);
        Topic GetTopicByUser(string user);
        Topic GetTopicByID(int ID);
        Topic GetTopicByTitle(string title);
        Topic GetComments(int TopicID);
    }
}
