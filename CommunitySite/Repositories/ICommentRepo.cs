using System.Linq;
using CommunitySite.Models;
using System.Collections.Generic;

namespace CommunitySite.Repositories
{
    public interface ICommentRepo
    {
        List<Message> Comments { get; }
        void AddComment(Message comment);
    }
}
